namespace MovieGenerator
{
    partial class Form1
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.randomBtn = new System.Windows.Forms.Button();
            this.movietxtBox = new System.Windows.Forms.RichTextBox();
            this.categoryA = new System.Windows.Forms.ComboBox();
            this.categoryB = new System.Windows.Forms.ComboBox();
            this.instructions = new System.Windows.Forms.Label();
            this.selectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // randomBtn
            // 
            this.randomBtn.Location = new System.Drawing.Point(196, 40);
            this.randomBtn.Name = "randomBtn";
            this.randomBtn.Size = new System.Drawing.Size(75, 23);
            this.randomBtn.TabIndex = 2;
            this.randomBtn.Text = "Random";
            this.randomBtn.UseVisualStyleBackColor = true;
            this.randomBtn.Click += new System.EventHandler(this.randomBtn_Click);
            // 
            // movietxtBox
            // 
            this.movietxtBox.Location = new System.Drawing.Point(359, 42);
            this.movietxtBox.Name = "movietxtBox";
            this.movietxtBox.Size = new System.Drawing.Size(151, 233);
            this.movietxtBox.TabIndex = 4;
            this.movietxtBox.Text = "";
            // 
            // categoryA
            // 
            this.categoryA.FormattingEnabled = true;
            this.categoryA.Location = new System.Drawing.Point(36, 138);
            this.categoryA.Name = "categoryA";
            this.categoryA.Size = new System.Drawing.Size(92, 21);
            this.categoryA.TabIndex = 5;
            this.categoryA.Text = "Main";
            this.categoryA.SelectedIndexChanged += new System.EventHandler(this.categoryA_SelectedIndexChanged);
            // 
            // categoryB
            // 
            this.categoryB.FormattingEnabled = true;
            this.categoryB.Location = new System.Drawing.Point(196, 138);
            this.categoryB.Name = "categoryB";
            this.categoryB.Size = new System.Drawing.Size(92, 21);
            this.categoryB.TabIndex = 6;
            this.categoryB.Text = "Secondary";
            this.categoryB.SelectedIndexChanged += new System.EventHandler(this.categoryB_SelectedIndexChanged);
            // 
            // instructions
            // 
            this.instructions.AutoSize = true;
            this.instructions.Location = new System.Drawing.Point(12, 98);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(328, 13);
            this.instructions.TabIndex = 7;
            this.instructions.Text = "Choose a main category then a secondary OR randomize everything";
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(68, 42);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(75, 23);
            this.selectBtn.TabIndex = 8;
            this.selectBtn.Text = "Select";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 300);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.categoryB);
            this.Controls.Add(this.categoryA);
            this.Controls.Add(this.movietxtBox);
            this.Controls.Add(this.randomBtn);
            this.Name = "Form1";
            this.Text = "What movie?";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button randomBtn;
        private System.Windows.Forms.RichTextBox movietxtBox;
        private System.Windows.Forms.ComboBox categoryA;
        private System.Windows.Forms.ComboBox categoryB;
        private System.Windows.Forms.Label instructions;
        private System.Windows.Forms.Button selectBtn;
    }
}

