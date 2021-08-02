using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using FX3Api;
using AdisApi;

namespace imu_thermo_controller
{
    class RelayPWM
    {
        /// <summary>
        /// FX3 control pin for relay
        /// </summary>
        public IPinObject ControlPin;

        /// <summary>
        /// Desired PWM freq, in Hz
        /// </summary>
        public double PWMFreq
        {
            get
            {
                return m_freq;
            }
            set
            {
                m_freq = value;
                UpdateIntervals();
            }
        }
        private double m_freq;

        /// <summary>
        /// PWM duty cycle (0.0 - 1.0)
        /// </summary>
        public double DutyCycle
        {
            get
            {
                return m_dutycycle;
            }
            set
            {
                m_dutycycle = value;
                UpdateIntervals();
            }
        }
        private double m_dutycycle;

        //Period for each timer (ms)
        long m_on_period, m_off_period;

        //Two timers for PWM control
        private Timer OnTimer;
        private Timer OffTimer;

        //Handle to FX3 object
        private FX3Connection m_FX3;

        public RelayPWM(ref FX3Connection FX3)
        {
            m_FX3 = FX3;
            //Default control pin DIO4
            ControlPin = m_FX3.DIO4;
            // Default freq 0.5Hz, 50% duty cycle
            m_freq = 0.5;
            m_dutycycle = 0.5;
        }

        public void Start()
        {
            Stop();
            //Timer setup
            OnTimer = new Timer();
            OffTimer = new Timer();
            UpdateIntervals();
            OnTimer.Interval = m_on_period;
            OffTimer.Interval = m_off_period;
            OnTimer.AutoReset = false;
            OffTimer.AutoReset = false;
            OnTimer.Elapsed += OnTimerHandler;
            OffTimer.Elapsed += OffTimerHandler;

            //Turn on and enable on timer
            m_FX3.SetPin(ControlPin, 1);
            OnTimer.Enabled = true;
        }

        public void Stop()
        {
            //make sure we have previously started
            if(OffTimer == null)
            {
                return;
            }
            //clean up timers
            OnTimer.Elapsed -= OnTimerHandler;
            OffTimer.Elapsed -= OffTimerHandler;
            OnTimer.Stop();
            OnTimer.Dispose();
            OffTimer.Stop();
            OffTimer.Dispose();
            //ensure relay is off
            m_FX3.SetPin(ControlPin, 0);
        }

        private void UpdateIntervals()
        {
            m_on_period = (long)((DutyCycle * 1000.0) / PWMFreq);
            m_off_period = (long)(((1.0 - DutyCycle) * 1000.0) / PWMFreq);
            /* Ensure min period of 1ms */
            m_off_period = Math.Max(m_off_period, 1);
            m_on_period = Math.Max(m_on_period, 1);
        }

        private void OnTimerHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Enable off timer and disable this timer
            OffTimer.Enabled = true;
            OnTimer.Enabled = false;
            //Update interval for on timer for next run 
            OnTimer.Interval = m_on_period;
            //set relay off (finished on period)
            m_FX3.SetPin(ControlPin, 0);
        }

        private void OffTimerHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Enable on timer and disable this timer
            OnTimer.Enabled = true;
            OffTimer.Enabled = false;
            //Update interval for off timer for next run 
            OffTimer.Interval = m_off_period;
            //set relay on (finished off period)
            m_FX3.SetPin(ControlPin, 1);
        }

    }
}
