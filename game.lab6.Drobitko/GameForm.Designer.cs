namespace game.lab6.Drobitko
{
    partial class GameForm
    {
        private System.Windows.Forms.ListBox shipListBox;
        private System.Windows.Forms.Panel player1BoardPanel;
        private System.Windows.Forms.Panel player2BoardPanel;
        private System.Windows.Forms.Label player1NameLabel;
        private System.Windows.Forms.Label player2NameLabel;
        private System.Windows.Forms.Label currentPlayerLabel;
        private System.Windows.Forms.Button readyButton;
        private System.Windows.Forms.RadioButton horizontalRadioButton;
        private System.Windows.Forms.RadioButton verticalRadioButton;
        private System.Windows.Forms.Button clearBoardButton; // Добавлено

        private void InitializeComponent()
        {
            this.shipListBox = new System.Windows.Forms.ListBox();
            this.player1BoardPanel = new System.Windows.Forms.Panel();
            this.player2BoardPanel = new System.Windows.Forms.Panel();
            this.player1NameLabel = new System.Windows.Forms.Label();
            this.player2NameLabel = new System.Windows.Forms.Label();
            this.currentPlayerLabel = new System.Windows.Forms.Label();
            this.readyButton = new System.Windows.Forms.Button();
            this.horizontalRadioButton = new System.Windows.Forms.RadioButton();
            this.verticalRadioButton = new System.Windows.Forms.RadioButton();
            this.clearBoardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // shipListBox
            // 
            this.shipListBox.FormattingEnabled = true;
            this.shipListBox.Location = new System.Drawing.Point(12, 12);
            this.shipListBox.Name = "shipListBox";
            this.shipListBox.Size = new System.Drawing.Size(137, 95);
            this.shipListBox.TabIndex = 0;
            this.shipListBox.SelectedIndexChanged += new System.EventHandler(this.ShipListBox_SelectedIndexChanged);
            // 
            // player1BoardPanel
            // 
            this.player1BoardPanel.Location = new System.Drawing.Point(155, 12);
            this.player1BoardPanel.Name = "player1BoardPanel";
            this.player1BoardPanel.Size = new System.Drawing.Size(300, 300);
            this.player1BoardPanel.TabIndex = 1;
            // 
            // player2BoardPanel
            // 
            this.player2BoardPanel.Location = new System.Drawing.Point(461, 12);
            this.player2BoardPanel.Name = "player2BoardPanel";
            this.player2BoardPanel.Size = new System.Drawing.Size(300, 300);
            this.player2BoardPanel.TabIndex = 2;
            this.player2BoardPanel.Visible = false;
            // 
            // player1NameLabel
            // 
            this.player1NameLabel.AutoSize = true;
            this.player1NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player1NameLabel.Location = new System.Drawing.Point(276, 315);
            this.player1NameLabel.Name = "player1NameLabel";
            this.player1NameLabel.Size = new System.Drawing.Size(56, 16);
            this.player1NameLabel.TabIndex = 3;
            this.player1NameLabel.Text = "Player 1";
            // 
            // player2NameLabel
            // 
            this.player2NameLabel.AutoSize = true;
            this.player2NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.player2NameLabel.Location = new System.Drawing.Point(583, 315);
            this.player2NameLabel.Name = "player2NameLabel";
            this.player2NameLabel.Size = new System.Drawing.Size(56, 16);
            this.player2NameLabel.TabIndex = 4;
            this.player2NameLabel.Text = "Player 2";
            // 
            // currentPlayerLabel
            // 
            this.currentPlayerLabel.AutoSize = true;
            this.currentPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentPlayerLabel.Location = new System.Drawing.Point(8, 227);
            this.currentPlayerLabel.Name = "currentPlayerLabel";
            this.currentPlayerLabel.Size = new System.Drawing.Size(109, 20);
            this.currentPlayerLabel.TabIndex = 8;
            this.currentPlayerLabel.Text = "Current Player";
            // 
            // readyButton
            // 
            this.readyButton.Location = new System.Drawing.Point(12, 113);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(120, 23);
            this.readyButton.TabIndex = 5;
            this.readyButton.Text = "Ready";
            this.readyButton.UseVisualStyleBackColor = true;
            this.readyButton.Click += new System.EventHandler(this.ReadyButton_Click);
            // 
            // horizontalRadioButton
            // 
            this.horizontalRadioButton.AutoSize = true;
            this.horizontalRadioButton.Location = new System.Drawing.Point(12, 142);
            this.horizontalRadioButton.Name = "horizontalRadioButton";
            this.horizontalRadioButton.Size = new System.Drawing.Size(72, 17);
            this.horizontalRadioButton.TabIndex = 6;
            this.horizontalRadioButton.TabStop = true;
            this.horizontalRadioButton.Text = "Horizontal";
            this.horizontalRadioButton.UseVisualStyleBackColor = true;
            this.horizontalRadioButton.CheckedChanged += new System.EventHandler(this.HorizontalRadioButton_CheckedChanged);
            // 
            // verticalRadioButton
            // 
            this.verticalRadioButton.AutoSize = true;
            this.verticalRadioButton.Location = new System.Drawing.Point(12, 165);
            this.verticalRadioButton.Name = "verticalRadioButton";
            this.verticalRadioButton.Size = new System.Drawing.Size(60, 17);
            this.verticalRadioButton.TabIndex = 7;
            this.verticalRadioButton.TabStop = true;
            this.verticalRadioButton.Text = "Vertical";
            this.verticalRadioButton.UseVisualStyleBackColor = true;
            this.verticalRadioButton.CheckedChanged += new System.EventHandler(this.VerticalRadioButton_CheckedChanged);
            // 
            // clearBoardButton
            // 
            this.clearBoardButton.Location = new System.Drawing.Point(12, 188);
            this.clearBoardButton.Name = "clearBoardButton";
            this.clearBoardButton.Size = new System.Drawing.Size(120, 23);
            this.clearBoardButton.TabIndex = 9;
            this.clearBoardButton.Text = "Clear Board";
            this.clearBoardButton.UseVisualStyleBackColor = true;
            this.clearBoardButton.Click += new System.EventHandler(this.ClearBoardButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 357);
            this.Controls.Add(this.clearBoardButton);
            this.Controls.Add(this.currentPlayerLabel);
            this.Controls.Add(this.verticalRadioButton);
            this.Controls.Add(this.horizontalRadioButton);
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.player2NameLabel);
            this.Controls.Add(this.player1NameLabel);
            this.Controls.Add(this.player2BoardPanel);
            this.Controls.Add(this.player1BoardPanel);
            this.Controls.Add(this.shipListBox);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
