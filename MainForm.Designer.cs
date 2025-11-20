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
			listViewNgram = new ListView();
			columnHeaderToken = new ColumnHeader();
			columnHeaderFrequency = new ColumnHeader();
			numericUpDownNGram = new NumericUpDown();
			listViewProperties = new ListView();
			columnHeaderProperty = new ColumnHeader();
			columnHeaderValue = new ColumnHeader();
			backgroundWorker = new System.ComponentModel.BackgroundWorker();
			progressBar = new ProgressBar();
			((System.ComponentModel.ISupportInitialize)numericUpDownNGram).BeginInit();
			SuspendLayout();
			// 
			// buttonOpenTextFile
			// 
			buttonOpenTextFile.Location = new Point(12, 12);
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
			// listViewNgram
			// 
			listViewNgram.Columns.AddRange(new ColumnHeader[] { columnHeaderToken, columnHeaderFrequency });
			listViewNgram.FullRowSelect = true;
			listViewNgram.Location = new Point(12, 41);
			listViewNgram.MultiSelect = false;
			listViewNgram.Name = "listViewNgram";
			listViewNgram.ShowItemToolTips = true;
			listViewNgram.Size = new Size(315, 208);
			listViewNgram.TabIndex = 1;
			listViewNgram.UseCompatibleStateImageBehavior = false;
			listViewNgram.View = View.Details;
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
			numericUpDownNGram.Location = new Point(152, 12);
			numericUpDownNGram.Name = "numericUpDownNGram";
			numericUpDownNGram.Size = new Size(96, 23);
			numericUpDownNGram.TabIndex = 2;
			numericUpDownNGram.Value = new decimal(new int[] { 3, 0, 0, 0 });
			// 
			// listViewProperties
			// 
			listViewProperties.Columns.AddRange(new ColumnHeader[] { columnHeaderProperty, columnHeaderValue });
			listViewProperties.FullRowSelect = true;
			listViewProperties.Location = new Point(333, 41);
			listViewProperties.MultiSelect = false;
			listViewProperties.Name = "listViewProperties";
			listViewProperties.ShowItemToolTips = true;
			listViewProperties.Size = new Size(315, 208);
			listViewProperties.TabIndex = 3;
			listViewProperties.UseCompatibleStateImageBehavior = false;
			listViewProperties.View = View.Details;
			// 
			// columnHeaderProperty
			// 
			columnHeaderProperty.Text = "Properties";
			columnHeaderProperty.Width = 200;
			// 
			// columnHeaderValue
			// 
			columnHeaderValue.Text = "Values";
			columnHeaderValue.Width = 100;
			// 
			// backgroundWorker
			// 
			backgroundWorker.WorkerReportsProgress = true;
			backgroundWorker.WorkerSupportsCancellation = true;
			backgroundWorker.DoWork += BackgroundWorker_DoWork;
			backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
			backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
			// 
			// progressBar
			// 
			progressBar.Location = new Point(333, 12);
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(100, 23);
			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.TabIndex = 4;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(665, 263);
			Controls.Add(progressBar);
			Controls.Add(listViewProperties);
			Controls.Add(numericUpDownNGram);
			Controls.Add(listViewNgram);
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
		private ListView listViewNgram;
		private ColumnHeader columnHeaderToken;
		private ColumnHeader columnHeaderFrequency;
		private NumericUpDown numericUpDownNGram;
		private ListView listViewProperties;
		private ColumnHeader columnHeaderProperty;
		private ColumnHeader columnHeaderValue;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private ProgressBar progressBar;
	}
}
