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
			labelProgressPercent = new Label();
			labelNgramLength = new Label();
			labelProgress = new Label();
			textBoxModelText = new TextBox();
			buttonCreateModelText = new Button();
			buttonCancel = new Button();
			labelModelTextLength = new Label();
			numericUpDownModelTextLength = new NumericUpDown();
			((System.ComponentModel.ISupportInitialize)numericUpDownNGram).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownModelTextLength).BeginInit();
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
			listViewNgram.Size = new Size(169, 208);
			listViewNgram.TabIndex = 6;
			listViewNgram.UseCompatibleStateImageBehavior = false;
			listViewNgram.View = View.Details;
			// 
			// columnHeaderToken
			// 
			columnHeaderToken.Text = "Token";
			columnHeaderToken.Width = 70;
			// 
			// columnHeaderFrequency
			// 
			columnHeaderFrequency.Text = "Frequency";
			columnHeaderFrequency.Width = 70;
			// 
			// numericUpDownNGram
			// 
			numericUpDownNGram.Location = new Point(243, 12);
			numericUpDownNGram.Name = "numericUpDownNGram";
			numericUpDownNGram.Size = new Size(51, 23);
			numericUpDownNGram.TabIndex = 2;
			numericUpDownNGram.TextAlign = HorizontalAlignment.Center;
			numericUpDownNGram.Value = new decimal(new int[] { 3, 0, 0, 0 });
			// 
			// listViewProperties
			// 
			listViewProperties.Columns.AddRange(new ColumnHeader[] { columnHeaderProperty, columnHeaderValue });
			listViewProperties.FullRowSelect = true;
			listViewProperties.Location = new Point(187, 41);
			listViewProperties.MultiSelect = false;
			listViewProperties.Name = "listViewProperties";
			listViewProperties.ShowItemToolTips = true;
			listViewProperties.Size = new Size(466, 208);
			listViewProperties.TabIndex = 7;
			listViewProperties.UseCompatibleStateImageBehavior = false;
			listViewProperties.View = View.Details;
			// 
			// columnHeaderProperty
			// 
			columnHeaderProperty.Text = "Properties";
			columnHeaderProperty.Width = 300;
			// 
			// columnHeaderValue
			// 
			columnHeaderValue.Text = "Values";
			columnHeaderValue.Width = 150;
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
			progressBar.Location = new Point(394, 12);
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(100, 23);
			progressBar.Step = 1;
			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.TabIndex = 4;
			// 
			// labelProgressPercent
			// 
			labelProgressPercent.AutoSize = true;
			labelProgressPercent.Location = new Point(500, 16);
			labelProgressPercent.Name = "labelProgressPercent";
			labelProgressPercent.Size = new Size(17, 15);
			labelProgressPercent.TabIndex = 5;
			labelProgressPercent.Text = "%";
			// 
			// labelNgramLength
			// 
			labelNgramLength.AutoSize = true;
			labelNgramLength.Location = new Point(150, 16);
			labelNgramLength.Name = "labelNgramLength";
			labelNgramLength.Size = new Size(87, 15);
			labelNgramLength.TabIndex = 1;
			labelNgramLength.Text = "n-gram length:";
			// 
			// labelProgress
			// 
			labelProgress.AutoSize = true;
			labelProgress.Location = new Point(333, 16);
			labelProgress.Name = "labelProgress";
			labelProgress.Size = new Size(55, 15);
			labelProgress.TabIndex = 3;
			labelProgress.Text = "Progress:";
			// 
			// textBoxModelText
			// 
			textBoxModelText.Location = new Point(187, 255);
			textBoxModelText.MaxLength = int.MaxValue;
			textBoxModelText.Multiline = true;
			textBoxModelText.Name = "textBoxModelText";
			textBoxModelText.ScrollBars = ScrollBars.Vertical;
			textBoxModelText.Size = new Size(466, 243);
			textBoxModelText.TabIndex = 9;
			// 
			// buttonCreateModelText
			// 
			buttonCreateModelText.Location = new Point(12, 475);
			buttonCreateModelText.Name = "buttonCreateModelText";
			buttonCreateModelText.Size = new Size(169, 23);
			buttonCreateModelText.TabIndex = 8;
			buttonCreateModelText.Text = "Create model text";
			buttonCreateModelText.UseVisualStyleBackColor = true;
			buttonCreateModelText.Click += ButtonCreateModelText_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(548, 12);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(105, 23);
			buttonCancel.TabIndex = 10;
			buttonCancel.Text = "Cancel progress";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// labelModelTextLength
			// 
			labelModelTextLength.AutoSize = true;
			labelModelTextLength.Location = new Point(12, 428);
			labelModelTextLength.Name = "labelModelTextLength";
			labelModelTextLength.Size = new Size(104, 15);
			labelModelTextLength.TabIndex = 11;
			labelModelTextLength.Text = "model text length:";
			// 
			// numericUpDownModelTextLength
			// 
			numericUpDownModelTextLength.Location = new Point(12, 446);
			numericUpDownModelTextLength.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
			numericUpDownModelTextLength.Name = "numericUpDownModelTextLength";
			numericUpDownModelTextLength.Size = new Size(115, 23);
			numericUpDownModelTextLength.TabIndex = 12;
			numericUpDownModelTextLength.TextAlign = HorizontalAlignment.Center;
			numericUpDownModelTextLength.Value = new decimal(new int[] { 100000, 0, 0, 0 });
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(665, 510);
			Controls.Add(labelModelTextLength);
			Controls.Add(numericUpDownModelTextLength);
			Controls.Add(buttonCancel);
			Controls.Add(buttonCreateModelText);
			Controls.Add(textBoxModelText);
			Controls.Add(labelProgress);
			Controls.Add(labelNgramLength);
			Controls.Add(labelProgressPercent);
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
			((System.ComponentModel.ISupportInitialize)numericUpDownModelTextLength).EndInit();
			ResumeLayout(false);
			PerformLayout();
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
		private Label labelProgressPercent;
		private Label labelNgramLength;
		private Label labelProgress;
		private TextBox textBoxModelText;
		private Button buttonCreateModelText;
		private Button buttonCancel;
		private Label labelModelTextLength;
		private NumericUpDown numericUpDownModelTextLength;
	}
}
