# IMU Thermal Controller

This application implements a thermal control system for an ADIS IMU (connected via EVAL-ADIS-FX3) using a directed air jet (hot air gun).

Temperature control is accomplished using a PID loop where the process variable is the current IMU temperature (measured using an EVAL-ADIS-FX3) and the controller output is a duty cycle for the directed air jet.

The air jet control PWM control is implemented using a software PWM signal fed into a relay. The EVAL-ADIS-FX3 provides the control signal for the relay.

The EVAL-ADIS-FX3 connection is automatically managed, by piggybacking onto a programmed

EVAL-ADIS-FX3 board. For example, if you connect to the EVAL-ADIS-FX3 through the iSensor FX3 Eval GUI, this application will connect to that board as well and use the same settings.

