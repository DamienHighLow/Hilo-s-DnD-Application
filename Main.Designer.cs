namespace DnDApplication
{
    partial class Main
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
            CharacterFormButton = new Button();
            DisplayCharacterInfo = new Button();
            SuspendLayout();
            // 
            // CharacterFormButton
            // 
            CharacterFormButton.Location = new Point(98, 48);
            CharacterFormButton.Name = "CharacterFormButton";
            CharacterFormButton.Size = new Size(198, 23);
            CharacterFormButton.TabIndex = 0;
            CharacterFormButton.Text = "Open Character Form";
            CharacterFormButton.UseVisualStyleBackColor = true;
            CharacterFormButton.Click += CharacterFormButton_Click;
            // 
            // DisplayCharacterInfo
            // 
            DisplayCharacterInfo.Location = new Point(98, 99);
            DisplayCharacterInfo.Name = "DisplayCharacterInfo";
            DisplayCharacterInfo.Size = new Size(198, 23);
            DisplayCharacterInfo.TabIndex = 1;
            DisplayCharacterInfo.Text = "Display Character Information";
            DisplayCharacterInfo.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 450);
            Controls.Add(DisplayCharacterInfo);
            Controls.Add(CharacterFormButton);
            Name = "Main";
            Text = "Soulbound DND: Home";
            ResumeLayout(false);
        }

        #endregion

        private Button CharacterFormButton;
        private Button DisplayCharacterInfo;
    }
}
