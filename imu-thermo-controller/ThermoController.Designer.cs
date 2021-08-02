namespace imu_thermo_controller
{
    partial class ThermoController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fx3_status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.kP = new System.Windows.Forms.TextBox();
            this.kD = new System.Windows.Forms.TextBox();
            this.kI = new System.Windows.Forms.TextBox();
            this.IMUTemp = new System.Windows.Forms.TextBox();
            this.DutyCycle = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.setpoint = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fx3_status
            // 
            this.fx3_status.Location = new System.Drawing.Point(80, 12);
            this.fx3_status.Name = "fx3_status";
            this.fx3_status.Size = new System.Drawing.Size(91, 20);
            this.fx3_status.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "FX3 Status:";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(191, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 47);
            this.btn_start.TabIndex = 2;
            this.btn_start.Text = "Start Controller";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(272, 12);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 47);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Stop Controller";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // kP
            // 
            this.kP.Location = new System.Drawing.Point(37, 92);
            this.kP.Name = "kP";
            this.kP.Size = new System.Drawing.Size(60, 20);
            this.kP.TabIndex = 4;
            this.kP.TextChanged += new System.EventHandler(this.kP_TextChanged);
            // 
            // kD
            // 
            this.kD.Location = new System.Drawing.Point(37, 144);
            this.kD.Name = "kD";
            this.kD.Size = new System.Drawing.Size(60, 20);
            this.kD.TabIndex = 5;
            this.kD.TextChanged += new System.EventHandler(this.kD_TextChanged);
            // 
            // kI
            // 
            this.kI.Location = new System.Drawing.Point(37, 118);
            this.kI.Name = "kI";
            this.kI.Size = new System.Drawing.Size(60, 20);
            this.kI.TabIndex = 6;
            this.kI.TextChanged += new System.EventHandler(this.kI_TextChanged);
            // 
            // IMUTemp
            // 
            this.IMUTemp.Location = new System.Drawing.Point(191, 118);
            this.IMUTemp.Name = "IMUTemp";
            this.IMUTemp.Size = new System.Drawing.Size(60, 20);
            this.IMUTemp.TabIndex = 7;
            // 
            // DutyCycle
            // 
            this.DutyCycle.Location = new System.Drawing.Point(191, 144);
            this.DutyCycle.Name = "DutyCycle";
            this.DutyCycle.Size = new System.Drawing.Size(60, 20);
            this.DutyCycle.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "kP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "kI:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "kD:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "IMU Temp:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Duty Cycle:";
            // 
            // setpoint
            // 
            this.setpoint.Location = new System.Drawing.Point(191, 92);
            this.setpoint.Name = "setpoint";
            this.setpoint.Size = new System.Drawing.Size(60, 20);
            this.setpoint.TabIndex = 14;
            this.setpoint.TextChanged += new System.EventHandler(this.setpoint_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(126, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Setpoint:";
            // 
            // ThermoController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 178);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.setpoint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.DutyCycle);
            this.Controls.Add(this.IMUTemp);
            this.Controls.Add(this.kI);
            this.Controls.Add(this.kD);
            this.Controls.Add(this.kP);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fx3_status);
            this.Name = "ThermoController";
            this.Text = "IMU Thermo Controller";
            this.Load += new System.EventHandler(this.ThermoController_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fx3_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.TextBox kP;
        private System.Windows.Forms.TextBox kD;
        private System.Windows.Forms.TextBox kI;
        private System.Windows.Forms.TextBox IMUTemp;
        private System.Windows.Forms.TextBox DutyCycle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox setpoint;
        private System.Windows.Forms.Label label6;
    }
}

