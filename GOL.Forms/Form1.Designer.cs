namespace GOL.Forms
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
            buttonPanel = new Panel();
            widthInput = new TextBox();
            heightInput = new TextBox();
            labelWidth = new Label();
            labelHeight = new Label();
            startButton = new Button();
            startSim = new Button();
            resetAll = new Button();
            intervalInput = new TextBox();
            intervalSped = new Label();
            gliderLabel = new Button();
            spaceshipButton = new Button();
            fpentoButton = new Button();
            SuspendLayout();
            // 
            // buttonPanel
            // 
            buttonPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonPanel.BackColor = SystemColors.ControlLight;
            buttonPanel.Location = new Point(224, 16);
            buttonPanel.Margin = new Padding(3, 4, 3, 4);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(469, 475);
            buttonPanel.TabIndex = 0;
            // 
            // widthInput
            // 
            widthInput.Location = new Point(103, 16);
            widthInput.Margin = new Padding(3, 4, 3, 4);
            widthInput.Name = "widthInput";
            widthInput.Size = new Size(114, 27);
            widthInput.TabIndex = 1;
            // 
            // heightInput
            // 
            heightInput.Location = new Point(103, 55);
            heightInput.Margin = new Padding(3, 4, 3, 4);
            heightInput.Name = "heightInput";
            heightInput.Size = new Size(114, 27);
            heightInput.TabIndex = 2;
            // 
            // labelWidth
            // 
            labelWidth.AutoSize = true;
            labelWidth.Location = new Point(54, 20);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(48, 20);
            labelWidth.TabIndex = 3;
            labelWidth.Text = "Breite";
            // 
            // labelHeight
            // 
            labelHeight.AutoSize = true;
            labelHeight.Location = new Point(54, 59);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(45, 20);
            labelHeight.TabIndex = 4;
            labelHeight.Text = "Höhe";
            // 
            // startButton
            // 
            startButton.Location = new Point(54, 132);
            startButton.Margin = new Padding(3, 4, 3, 4);
            startButton.Name = "startButton";
            startButton.Size = new Size(163, 31);
            startButton.TabIndex = 5;
            startButton.Text = "Initialisiere Spielfeld";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // startSim
            // 
            startSim.Enabled = false;
            startSim.Location = new Point(54, 170);
            startSim.Name = "startSim";
            startSim.Size = new Size(163, 29);
            startSim.TabIndex = 6;
            startSim.Text = "Simulation Starten";
            startSim.UseVisualStyleBackColor = true;
            startSim.Click += startSim_Click;
            // 
            // resetAll
            // 
            resetAll.Location = new Point(54, 205);
            resetAll.Name = "resetAll";
            resetAll.Size = new Size(163, 29);
            resetAll.TabIndex = 7;
            resetAll.Text = "Reset";
            resetAll.UseVisualStyleBackColor = true;
            resetAll.Click += resetAll_Click;
            // 
            // intervalInput
            // 
            intervalInput.Location = new Point(161, 89);
            intervalInput.Name = "intervalInput";
            intervalInput.Size = new Size(57, 27);
            intervalInput.TabIndex = 8;
            // 
            // intervalSped
            // 
            intervalSped.AutoSize = true;
            intervalSped.Location = new Point(54, 92);
            intervalSped.Name = "intervalSped";
            intervalSped.Size = new Size(101, 20);
            intervalSped.TabIndex = 9;
            intervalSped.Text = "Intervall in ms";
            intervalSped.Click += intervalSped_Click;
            // 
            // gliderLabel
            // 
            gliderLabel.Location = new Point(112, 288);
            gliderLabel.Name = "gliderLabel";
            gliderLabel.Size = new Size(106, 29);
            gliderLabel.TabIndex = 10;
            gliderLabel.Text = "Gleiter";
            gliderLabel.UseVisualStyleBackColor = true;
            gliderLabel.Click += gliderLabel_Click;
            // 
            // spaceshipButton
            // 
            spaceshipButton.Location = new Point(112, 322);
            spaceshipButton.Name = "spaceshipButton";
            spaceshipButton.Size = new Size(106, 29);
            spaceshipButton.TabIndex = 11;
            spaceshipButton.Text = "Segler";
            spaceshipButton.UseVisualStyleBackColor = true;
            spaceshipButton.Click += spaceshipButton_Click;
            // 
            // fpentoButton
            // 
            fpentoButton.Location = new Point(112, 355);
            fpentoButton.Name = "fpentoButton";
            fpentoButton.Size = new Size(106, 29);
            fpentoButton.TabIndex = 12;
            fpentoButton.Text = "f-Pentomino";
            fpentoButton.UseVisualStyleBackColor = true;
            fpentoButton.Click += fpentoButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(fpentoButton);
            Controls.Add(spaceshipButton);
            Controls.Add(gliderLabel);
            Controls.Add(intervalSped);
            Controls.Add(intervalInput);
            Controls.Add(resetAll);
            Controls.Add(startSim);
            Controls.Add(startButton);
            Controls.Add(labelHeight);
            Controls.Add(labelWidth);
            Controls.Add(heightInput);
            Controls.Add(widthInput);
            Controls.Add(buttonPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel buttonPanel;
        private TextBox widthInput;
        private TextBox heightInput;
        private Label labelWidth;
        private Label labelHeight;
        private Button startButton;
        private Button startSim;
        private Button resetAll;
        private TextBox intervalInput;
        private Label intervalSped;
        private Button gliderLabel;
        private Button spaceshipButton;
        private Button fpentoButton;
    }
}
