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
            labelWidth = new Label();
            labelHeight = new Label();
            startButton = new Button();
            startSim = new Button();
            resetAll = new Button();
            intervalSped = new Label();
            gliderLabel = new Button();
            spaceshipButton = new Button();
            fpentoButton = new Button();
            label1 = new Label();
            golLink = new LinkLabel();
            widthInput = new NumericUpDown();
            heightInput = new NumericUpDown();
            intervalInput = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)widthInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)heightInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)intervalInput).BeginInit();
            SuspendLayout();
            // 
            // buttonPanel
            // 
            buttonPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonPanel.AutoScroll = true;
            buttonPanel.BackColor = SystemColors.ControlLight;
            buttonPanel.Location = new Point(196, 12);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(602, 436);
            buttonPanel.TabIndex = 0;
            // 
            // labelWidth
            // 
            labelWidth.AutoSize = true;
            labelWidth.Location = new Point(47, 15);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(37, 15);
            labelWidth.TabIndex = 3;
            labelWidth.Text = "Breite";
            // 
            // labelHeight
            // 
            labelHeight.AutoSize = true;
            labelHeight.Location = new Point(47, 44);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(36, 15);
            labelHeight.TabIndex = 4;
            labelHeight.Text = "Höhe";
            // 
            // startButton
            // 
            startButton.Location = new Point(47, 99);
            startButton.Name = "startButton";
            startButton.Size = new Size(143, 23);
            startButton.TabIndex = 5;
            startButton.Text = "Initialisiere Spielfeld";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // startSim
            // 
            startSim.Enabled = false;
            startSim.Location = new Point(47, 128);
            startSim.Margin = new Padding(3, 2, 3, 2);
            startSim.Name = "startSim";
            startSim.Size = new Size(143, 22);
            startSim.TabIndex = 6;
            startSim.Text = "Simulation Starten";
            startSim.UseVisualStyleBackColor = true;
            startSim.Click += startSim_Click;
            // 
            // resetAll
            // 
            resetAll.Location = new Point(47, 154);
            resetAll.Margin = new Padding(3, 2, 3, 2);
            resetAll.Name = "resetAll";
            resetAll.Size = new Size(143, 22);
            resetAll.TabIndex = 7;
            resetAll.Text = "Reset";
            resetAll.UseVisualStyleBackColor = true;
            resetAll.Click += resetAll_Click;
            // 
            // intervalSped
            // 
            intervalSped.AutoSize = true;
            intervalSped.Location = new Point(46, 72);
            intervalSped.Name = "intervalSped";
            intervalSped.Size = new Size(81, 15);
            intervalSped.TabIndex = 9;
            intervalSped.Text = "Intervall in ms";
            intervalSped.Click += intervalSped_Click;
            // 
            // gliderLabel
            // 
            gliderLabel.Location = new Point(98, 216);
            gliderLabel.Margin = new Padding(3, 2, 3, 2);
            gliderLabel.Name = "gliderLabel";
            gliderLabel.Size = new Size(93, 22);
            gliderLabel.TabIndex = 10;
            gliderLabel.Text = "Gleiter";
            gliderLabel.UseVisualStyleBackColor = true;
            gliderLabel.Click += gliderLabel_Click;
            // 
            // spaceshipButton
            // 
            spaceshipButton.Location = new Point(98, 242);
            spaceshipButton.Margin = new Padding(3, 2, 3, 2);
            spaceshipButton.Name = "spaceshipButton";
            spaceshipButton.Size = new Size(93, 22);
            spaceshipButton.TabIndex = 11;
            spaceshipButton.Text = "Segler";
            spaceshipButton.UseVisualStyleBackColor = true;
            spaceshipButton.Click += spaceshipButton_Click;
            // 
            // fpentoButton
            // 
            fpentoButton.Location = new Point(98, 266);
            fpentoButton.Margin = new Padding(3, 2, 3, 2);
            fpentoButton.Name = "fpentoButton";
            fpentoButton.Size = new Size(93, 22);
            fpentoButton.TabIndex = 12;
            fpentoButton.Text = "f-Pentomino";
            fpentoButton.UseVisualStyleBackColor = true;
            fpentoButton.Click += fpentoButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 192);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 13;
            label1.Text = "Startelemente";
            // 
            // golLink
            // 
            golLink.AutoSize = true;
            golLink.Location = new Point(10, 428);
            golLink.Name = "golLink";
            golLink.Size = new Size(102, 15);
            golLink.TabIndex = 14;
            golLink.TabStop = true;
            golLink.Text = "Game Of Life Wiki";
            golLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            golLink.LinkClicked += golLink_LinkClicked;
            // 
            // widthInput
            // 
            widthInput.Location = new Point(90, 13);
            widthInput.Name = "widthInput";
            widthInput.Size = new Size(101, 23);
            widthInput.TabIndex = 15;
            widthInput.Value = WIDTH; 
            widthInput.Minimum = 1;
            widthInput.Maximum = 50;
            // 
            // heightInput
            // 
            heightInput.Location = new Point(89, 42);
            heightInput.Name = "heightInput";
            heightInput.Size = new Size(101, 23);
            heightInput.TabIndex = 16;
            heightInput.Value = HEIGHT;
            heightInput.Minimum = 1;
            heightInput.Maximum = 50;
            // 
            // intervalInput
            // 
            intervalInput.Minimum = 1;
            intervalInput.Maximum = 10000;
            intervalInput.Location = new Point(133, 70);
            intervalInput.Name = "intervalInput";
            intervalInput.Size = new Size(57, 23);
            intervalInput.TabIndex = 17;
            intervalInput.Value = INTERVAL;
        
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(intervalInput);
            Controls.Add(heightInput);
            Controls.Add(widthInput);
            Controls.Add(golLink);
            Controls.Add(label1);
            Controls.Add(fpentoButton);
            Controls.Add(spaceshipButton);
            Controls.Add(gliderLabel);
            Controls.Add(intervalSped);
            Controls.Add(resetAll);
            Controls.Add(startSim);
            Controls.Add(startButton);
            Controls.Add(labelHeight);
            Controls.Add(labelWidth);
            Controls.Add(buttonPanel);
            Name = "Form1";
            Text = "Game Of Life";
            ((System.ComponentModel.ISupportInitialize)widthInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)heightInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)intervalInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel buttonPanel;
        private Label labelWidth;
        private Label labelHeight;
        private Button startButton;
        private Button startSim;
        private Button resetAll;
        private Label intervalSped;
        private Button gliderLabel;
        private Button spaceshipButton;
        private Button fpentoButton;
        private Label label1;
        private LinkLabel golLink;
        private NumericUpDown widthInput;
        private NumericUpDown heightInput;
        private NumericUpDown intervalInput;
    }
}
