namespace GraML
{
    partial class MainForm
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
			buttonOpenTextFile = new Button();
			openFileDialog = new OpenFileDialog();
			listView = new ListView();
			columnHeaderToken = new ColumnHeader();
			columnHeaderFrequency = new ColumnHeader();
			numericUpDownNGram = new NumericUpDown();
			((System.ComponentModel.ISupportInitialize)numericUpDownNGram).BeginInit();
			SuspendLayout();
			// 
			// buttonOpenTextFile
			// 
			buttonOpenTextFile.Location = new Point(68, 43);
			buttonOpenTextFile.Name = "buttonOpenTextFile";
			buttonOpenTextFile.Size = new Size(115, 23);
			buttonOpenTextFile.TabIndex = 0;
			buttonOpenTextFile.Text = "Open text file";
			buttonOpenTextFile.UseVisualStyleBackColor = true;
			buttonOpenTextFile.Click += ButtonOpenTextFile_Click;
			// 
			// openFileDialog
			// 
			openFileDialog.DefaultExt = "*.txt";
			openFileDialog.OkRequiresInteraction = true;
			// 
			// listView
			// 
			listView.Columns.AddRange(new ColumnHeader[] { columnHeaderToken, columnHeaderFrequency });
			listView.FullRowSelect = true;
			listView.Location = new Point(68, 82);
			listView.MultiSelect = false;
			listView.Name = "listView";
			listView.ShowItemToolTips = true;
			listView.Size = new Size(326, 208);
			listView.TabIndex = 1;
			listView.UseCompatibleStateImageBehavior = false;
			listView.View = View.Details;
			// 
			// columnHeaderToken
			// 
			columnHeaderToken.Text = "Token";
			columnHeaderToken.Width = 200;
			// 
			// columnHeaderFrequency
			// 
			columnHeaderFrequency.Text = "Frequency";
			columnHeaderFrequency.Width = 100;
			// 
			// numericUpDownNGram
			// 
			numericUpDownNGram.Location = new Point(208, 43);
			numericUpDownNGram.Name = "numericUpDownNGram";
			numericUpDownNGram.Size = new Size(96, 23);
			numericUpDownNGram.TabIndex = 2;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(538, 402);
			Controls.Add(numericUpDownNGram);
			Controls.Add(listView);
			Controls.Add(buttonOpenTextFile);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "GraML";
			((System.ComponentModel.ISupportInitialize)numericUpDownNGram).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button buttonOpenTextFile;
		private OpenFileDialog openFileDialog;
		private ListView listView;
		private ColumnHeader columnHeaderToken;
		private ColumnHeader columnHeaderFrequency;
		private NumericUpDown numericUpDownNGram;
	}
}
