using System;
using System.Drawing;
using System.Windows.Forms;
using FX3Api;
using adisInterface;
using RegMapClasses;

namespace imu_thermo_controller
{
    public partial class ThermoController : Form
    {
        private Timer ConnectionTimer;
        private Timer ControllerTimer;
        FX3Connection FX3;
        adbfInterface Dut;
        RegClass tempReg;

        PIDController controller;
        RelayPWM pwm;

        public ThermoController()
        {
            InitializeComponent();
        }

        private void ThermoController_Load(object sender, EventArgs e)
        {
            //Set up FX3 object
            string FX3Path = AppDomain.CurrentDomain.BaseDirectory;
            FX3 = new FX3Connection(FX3Path, FX3Path, FX3Path, DeviceType.IMU);

            //Set up connection timer
            ConnectionTimer = new Timer();
            ConnectionTimer.Interval = 1000;
            ConnectionTimer.Tick += CheckFX3Connection;
            ConnectionTimer.Enabled = true;

            //Set up PID controller timer (runs at twice the rate of the PWM)
            ControllerTimer = new Timer();
            ControllerTimer.Interval = 1000;
            ControllerTimer.Tick += UpdateController;
            ControllerTimer.Enabled = false;

            //Set up temp register for 50x
            tempReg = new RegClass();
            tempReg.Address = 28;
            tempReg.Page = 0;
            tempReg.Scale = 0.1;
            tempReg.ReadLen = 16;
            tempReg.NumBytes = 2;

            //Set up PID controller
            controller = new PIDController();

            //Set up PWM controller
            pwm = new RelayPWM(ref FX3);

            //label properties
            fx3_status.ReadOnly = true;

            kP.Text = controller.kP.ToString();
            kI.Text = controller.kI.ToString();
            kD.Text = controller.kD.ToString();

            setpoint.Text = "50";
        }

        /// <summary>
        /// Update the state of the controller
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        private void UpdateController(Object myObject, EventArgs myEventArgs)
        {
            double temp = Dut.ReadScaledValue(tempReg);
            controller.UpdateInput(temp);
            pwm.DutyCycle = controller.Output;
            DutyCycle.Text = pwm.DutyCycle.ToString();
            IMUTemp.Text = temp.ToString();
        }

        /// <summary>
        /// Check the status of the FX3 connection. This application connects to an 
        /// already programmed FX3 board (via Matlab, Eval GUI, etc)
        /// </summary>
        /// <param name="myObject"></param>
        /// <param name="myEventArgs"></param>
        private void CheckFX3Connection(Object myObject, EventArgs myEventArgs)
        {
            /* Is FX3 already connected? */
            if (FX3.ActiveFX3 != null)
            {
                fx3_status.Text = "Connected";
                fx3_status.BackColor = Color.LightGreen;
                return;
            }
            string sn;
            /* Is there an FX3 available to connect to? */
            if (FX3.BusyFX3s.Count > 0)
                sn = FX3.BusyFX3s[0];
            else
            {
                fx3_status.Text = "Waiting for FX3";
                fx3_status.BackColor = Color.LightYellow;
                return;
            }
            /* Try and connect */
            try
            {
                FX3.Connect(sn);
                Dut = new adbfInterface(FX3, null);
                fx3_status.Text = "Connected";
                fx3_status.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                fx3_status.Text = "Connection Lost!";
                fx3_status.BackColor = Color.Red;
            }
        }

        private void UpdateInputs()
        {
            try
            {
                controller.SetPoint = Convert.ToDouble(setpoint.Text);
                controller.kP = Convert.ToDouble(kP.Text);
                controller.kI = Convert.ToDouble(kI.Text);
                controller.kD = Convert.ToDouble(kD.Text);
            }
            catch(Exception ex)
            {
                //squash
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            UpdateInputs();
            controller.Reset();
            pwm.ControlPin = FX3.DIO4;
            pwm.Start();
            ControllerTimer.Enabled = true;
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            ControllerTimer.Enabled = false;
            pwm.Stop();
        }

        private void kP_TextChanged(object sender, EventArgs e)
        {
            UpdateInputs();
        }

        private void kI_TextChanged(object sender, EventArgs e)
        {
            UpdateInputs();
        }

        private void kD_TextChanged(object sender, EventArgs e)
        {
            UpdateInputs();
        }

        private void setpoint_TextChanged(object sender, EventArgs e)
        {
            UpdateInputs();
        }
    }
}
