namespace PoeDun
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDisplay = new Label();
            lblHealth = new Label();
            lblAttack = new Label();
            btnAttackLeft = new Button();
            btnAttackUp = new Button();
            btnAttackRight = new Button();
            btnAttackDown = new Button();
            SuspendLayout();
            // 
            // lblDisplay
            // 
            lblDisplay.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDisplay.Location = new Point(36, 32);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(440, 341);
            lblDisplay.TabIndex = 0;
            lblDisplay.Text = "Display";
            lblDisplay.Click += lblDisplay_Click;
            // 
            // lblHealth
            // 
            lblHealth.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHealth.Location = new Point(600, 32);
            lblHealth.Name = "lblHealth";
            lblHealth.Size = new Size(72, 41);
            lblHealth.TabIndex = 1;
            lblHealth.Text = "Health";
            // 
            // lblAttack
            // 
            lblAttack.BackColor = SystemColors.ActiveBorder;
            lblAttack.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAttack.Location = new Point(543, 134);
            lblAttack.Name = "lblAttack";
            lblAttack.Size = new Size(194, 35);
            lblAttack.TabIndex = 2;
            lblAttack.Text = "Attack";
            lblAttack.TextAlign = ContentAlignment.MiddleCenter;
            lblAttack.Click += label1_Click;
            // 
            // btnAttackLeft
            // 
            btnAttackLeft.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAttackLeft.Location = new Point(543, 172);
            btnAttackLeft.Name = "btnAttackLeft";
            btnAttackLeft.Size = new Size(45, 50);
            btnAttackLeft.TabIndex = 0;
            btnAttackLeft.TabStop = false;
            btnAttackLeft.Text = "←";
            btnAttackLeft.TextAlign = ContentAlignment.TopCenter;
            btnAttackLeft.UseVisualStyleBackColor = true;
            btnAttackLeft.Click += button1_Click;
            // 
            // btnAttackUp
            // 
            btnAttackUp.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAttackUp.Location = new Point(594, 172);
            btnAttackUp.Name = "btnAttackUp";
            btnAttackUp.Size = new Size(45, 50);
            btnAttackUp.TabIndex = 0;
            btnAttackUp.TabStop = false;
            btnAttackUp.Text = " ↑";
            btnAttackUp.UseVisualStyleBackColor = true;
            btnAttackUp.Click += btnAttackUp_Click;
            // 
            // btnAttackRight
            // 
            btnAttackRight.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAttackRight.Location = new Point(692, 172);
            btnAttackRight.Name = "btnAttackRight";
            btnAttackRight.Size = new Size(45, 50);
            btnAttackRight.TabIndex = 0;
            btnAttackRight.TabStop = false;
            btnAttackRight.Text = "→";
            btnAttackRight.TextAlign = ContentAlignment.TopCenter;
            btnAttackRight.UseVisualStyleBackColor = true;
            btnAttackRight.Click += btnAttackRight_Click;
            // 
            // btnAttackDown
            // 
            btnAttackDown.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAttackDown.Location = new Point(645, 172);
            btnAttackDown.Name = "btnAttackDown";
            btnAttackDown.Size = new Size(45, 50);
            btnAttackDown.TabIndex = 0;
            btnAttackDown.TabStop = false;
            btnAttackDown.Text = " ↓";
            btnAttackDown.UseVisualStyleBackColor = true;
            btnAttackDown.Click += btnAttackDown_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAttackDown);
            Controls.Add(btnAttackRight);
            Controls.Add(btnAttackUp);
            Controls.Add(btnAttackLeft);
            Controls.Add(lblAttack);
            Controls.Add(lblHealth);
            Controls.Add(lblDisplay);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Label lblDisplay;
        private Label lblHealth;
        private Label lblAttack;
        private Button btnAttackLeft;
        private Button btnAttackUp;
        private Button btnAttackRight;
        private Button btnAttackDown;
    }
}
