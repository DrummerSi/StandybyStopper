
namespace StandbyStopper
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.volumeMeter = new NAudio.Gui.VolumeMeter();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerUI = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.notice = new System.Windows.Forms.Label();
            this.infoBox = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.isPlayingControl = new StandbyStopper.IsPlayingControl();
            this.btnBeep = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.elementHost = new System.Windows.Forms.Integration.ElementHost();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // volumeMeter
            // 
            this.volumeMeter.Amplitude = 5F;
            this.volumeMeter.Location = new System.Drawing.Point(19, 113);
            this.volumeMeter.MaxDb = 18F;
            this.volumeMeter.MinDb = -30F;
            this.volumeMeter.Name = "volumeMeter";
            this.volumeMeter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.volumeMeter.Size = new System.Drawing.Size(356, 23);
            this.volumeMeter.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerUI
            // 
            this.timerUI.AutoSize = true;
            this.timerUI.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerUI.Location = new System.Drawing.Point(24, 208);
            this.timerUI.Name = "timerUI";
            this.timerUI.Size = new System.Drawing.Size(208, 41);
            this.timerUI.TabIndex = 3;
            this.timerUI.Text = "00:00:00.0";
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(278, 510);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(97, 13);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "Version {}";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // notice
            // 
            this.notice.Location = new System.Drawing.Point(28, 255);
            this.notice.Name = "notice";
            this.notice.Size = new System.Drawing.Size(251, 45);
            this.notice.TabIndex = 7;
            this.notice.Text = "This application is for testing purposes only and doesn\'t need running under norm" +
    "al circumstances by the end-user\r\n";
            // 
            // infoBox
            // 
            this.infoBox.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoBox.Appearance.Options.UseFont = true;
            this.infoBox.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.infoBox.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.infoBox.Location = new System.Drawing.Point(19, 44);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(363, 21);
            this.infoBox.TabIndex = 8;
            this.infoBox.Text = "Default output device";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(363, 25);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Default output device ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 82);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(363, 25);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Debugging";
            // 
            // isPlayingControl
            // 
            this.isPlayingControl.IsPlaying = false;
            this.isPlayingControl.Location = new System.Drawing.Point(19, 142);
            this.isPlayingControl.Name = "isPlayingControl";
            this.isPlayingControl.Size = new System.Drawing.Size(139, 35);
            this.isPlayingControl.TabIndex = 2;
            // 
            // btnBeep
            // 
            this.btnBeep.Location = new System.Drawing.Point(300, 208);
            this.btnBeep.Name = "btnBeep";
            this.btnBeep.Size = new System.Drawing.Size(75, 23);
            this.btnBeep.TabIndex = 11;
            this.btnBeep.Text = "Beep";
            this.btnBeep.Click += new System.EventHandler(this.btnBeep_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 180);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(363, 25);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Time since last audio";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(300, 237);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 11;
            this.simpleButton2.Text = "Break";
            this.simpleButton2.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(300, 266);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 23);
            this.simpleButton3.TabIndex = 11;
            this.simpleButton3.Text = "Low tone";
            this.simpleButton3.Click += new System.EventHandler(this.btnSilence_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 482);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(363, 25);
            this.labelControl4.TabIndex = 12;
            // 
            // elementHost
            // 
            this.elementHost.Location = new System.Drawing.Point(19, 334);
            this.elementHost.Name = "elementHost";
            this.elementHost.Size = new System.Drawing.Size(356, 142);
            this.elementHost.TabIndex = 14;
            this.elementHost.Child = null;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.LineVisible = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 303);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(363, 25);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "Spectrum analyser";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 542);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.elementHost);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btnBeep);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.notice);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.timerUI);
            this.Controls.Add(this.isPlayingControl);
            this.Controls.Add(this.volumeMeter);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmMain.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Standby Stopper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NAudio.Gui.VolumeMeter volumeMeter;
        private IsPlayingControl isPlayingControl;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timerUI;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label notice;
        private DevExpress.XtraEditors.LabelControl infoBox;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnBeep;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Integration.ElementHost elementHost;
        private VisControl visControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private VisControl visControl2;
    }
}

