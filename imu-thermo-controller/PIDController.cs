using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imu_thermo_controller
{
    class PIDController
    {
        /// <summary>
        /// Proportional coefficient
        /// </summary>
        public double kP;

        /// <summary>
        /// Integral coefficient
        /// </summary>
        public double kI;

        /// <summary>
        /// Derivative coefficient
        /// </summary>
        public double kD;

        /// <summary>
        /// PID controller set point for input
        /// </summary>
        public double SetPoint;

        /// <summary>
        /// Minimum output from controller
        /// </summary>
        public double MinOutput;

        /// <summary>
        /// Maximum output from controller
        /// </summary>
        public double MaxOutput;

        /// <summary>
        /// Number of samples to integrate
        /// </summary>
        public int NumIntegratorSamples;

        /// <summary>
        /// The current output from the PID controller
        /// </summary>
        public double Output
        {
            get
            {
                return m_output;
            }
        }
        private double m_output;

        /// <summary>
        /// Prior sample error for derivative
        /// </summary>
        private double m_lasterror;

        /// <summary>
        /// list of error terms for integrator
        /// </summary>
        private List<double> errorfifo;

        /// <summary>
        /// PID controller constructor. Sets default values to push output
        /// nominally in range of 0.0 - 1.0. The controller must be tuned 
        /// for the particular setup in which it is used. Key parameters are
        /// 
        /// IMU type (thermal capacity of package)
        /// Directed air heater power
        /// Distance from heater to IMU
        /// 
        /// General tuning process:
        /// 
        /// Start with only kP and adjust until results seem reasonable, and
        /// the IMU will get near the desired temperature at the desired rate, 
        /// without too much overshoot.
        /// 
        /// Tune kI to prevent getting "stuck" at temperature just below the
        /// set point. Avoid very large kI terms - this will cause overshoot
        /// if starting from a temperature very far away from set point
        /// 
        /// Tune kD to minimize overshoot.
        /// 
        /// In general, this should be a predominantly P-driver controller,
        /// once tuned.
        /// 
        /// Tuning terms:
        /// 
        /// ADIS1650x
        /// kP: 0.03
        /// kI: 0.001
        /// kD: -0.003
        /// 
        /// ADIS1649x
        /// kP: 0.03
        /// kI: 0.001
        /// kD: -0.003
        /// </summary>
        public PIDController()
        {
            //Default range 0-1
            MinOutput = 0.0;
            MaxOutput = 1.0;
            //Integrate for past 120 seconds (assuming 1Hz update rate)
            NumIntegratorSamples = 120;
            //Tuned for ADIS1650x using hair dryer ~3inches from IMU!
            kP = 0.03;
            kI = 0.001;
            kD = -0.003;
            SetPoint = 0.0;
            Reset();
            UpdateInput(0.0);
        }

        /// <summary>
        /// Reset the PID controller memory
        /// </summary>
        public void Reset()
        {
            errorfifo = new List<double>();
            m_lasterror = 0.0;
        }

        /// <summary>
        /// Apply a new process value input and update the state of the PID
        /// </summary>
        /// <param name="input">New input value</param>
        public void UpdateInput(double input)
        {
            double error;
            double p, i, d;

            //error term is difference between setpoint and current process value
            error = SetPoint - input;

            //Calculate P, I, D terms
            p = error * kP;
            errorfifo.Add(error);
            i = UpdateIntegrator(error) * kI;
            d = (error - m_lasterror) * kD;
            m_lasterror = error;

            //sum to find output term
            m_output = p + i + d;

            //clamp
            if (m_output > MaxOutput)
                m_output = MaxOutput;
            if (m_output < MinOutput)
                m_output = MinOutput;
        }

        private double UpdateIntegrator(double error)
        {
            double sum = 0;
            //Add new sample to end
            errorfifo.Add(error);
            //Remove old samples
            while (errorfifo.Count > NumIntegratorSamples)
                errorfifo.RemoveAt(0);
            //return sum of error terms
            foreach (double term in errorfifo)
                sum += term;
            return sum;
        }
    }
}
