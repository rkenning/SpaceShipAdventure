namespace SpaceshipCommander
{
    partial class GameWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.time_GameTick = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.lblPower = new System.Windows.Forms.Label();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // time_GameTick
            // 
            this.time_GameTick.Interval = 1;
            this.time_GameTick.Tick += new System.EventHandler(this.time_GameTick_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "RUN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblPower
            // 
            this.lblPower.AutoSize = true;
            this.lblPower.Font = new System.Drawing.Font("Agency FB", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPower.Location = new System.Drawing.Point(425, 32);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(0, 32);
            this.lblPower.TabIndex = 4;
            // 
            // txtDebug
            // 
            this.txtDebug.Location = new System.Drawing.Point(9, 676);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(1050, 64);
            this.txtDebug.TabIndex = 5;
            this.txtDebug.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(183, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "TEST WIN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Location = new System.Drawing.Point(106, 31);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(74, 23);
            this.cmdStop.TabIndex = 10;
            this.cmdStop.Text = "STOP";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1184, 562);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.lblPower);
            this.Controls.Add(this.button1);
            this.Name = "GameWindow";
            this.Text = "Space Ship Adventure";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameWindow_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer time_GameTick;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button cmdStop;
    }
}

