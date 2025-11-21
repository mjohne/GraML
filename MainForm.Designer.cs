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
			buttonSelectTextFile = new Button();
			openFileDialog = new OpenFileDialog();
			listViewToken = new ListView();
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
			groupBoxTextFile = new GroupBox();
			textBoxTextFilePath = new TextBox();
			groupBoxNgram = new GroupBox();
			buttonRebuild = new Button();
			groupBoxProgress = new GroupBox();
			groupBoxTokenFrequency = new GroupBox();
			buttonSaveTokenListAsCsv = new Button();
			groupBoxProperties = new GroupBox();
			groupBoxModelText = new GroupBox();
			buttonSaveAsTextFile = new Button();
			saveFileDialogTokenList = new SaveFileDialog();
			saveFileDialogModelText = new SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)numericUpDownNGram).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownModelTextLength).BeginInit();
			groupBoxTextFile.SuspendLayout();
			groupBoxNgram.SuspendLayout();
			groupBoxProgress.SuspendLayout();
			groupBoxTokenFrequency.SuspendLayout();
			groupBoxProperties.SuspendLayout();
			groupBoxModelText.SuspendLayout();
			SuspendLayout();
			// 
			// buttonSelectTextFile
			// 
			buttonSelectTextFile.Location = new Point(520, 22);
			buttonSelectTextFile.Name = "buttonSelectTextFile";
			buttonSelectTextFile.Size = new Size(115, 23);
			buttonSelectTextFile.TabIndex = 1;
			buttonSelectTextFile.Text = "Select text file";
			buttonSelectTextFile.UseVisualStyleBackColor = true;
			buttonSelectTextFile.Click += ButtonSelectTextFile_Click;
			// 
			// openFileDialog
			// 
			openFileDialog.DefaultExt = "txt";
			openFileDialog.Filter = "text files|*.txt|all files|*.*";
			openFileDialog.OkRequiresInteraction = true;
			// 
			// listViewToken
			// 
			listViewToken.Columns.AddRange(new ColumnHeader[] { columnHeaderToken, columnHeaderFrequency });
			listViewToken.FullRowSelect = true;
			listViewToken.Location = new Point(6, 22);
			listViewToken.MultiSelect = false;
			listViewToken.Name = "listViewToken";
			listViewToken.ShowItemToolTips = true;
			listViewToken.Size = new Size(163, 188);
			listViewToken.TabIndex = 0;
			listViewToken.UseCompatibleStateImageBehavior = false;
			listViewToken.View = View.Details;
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
			numericUpDownNGram.Location = new Point(99, 15);
			numericUpDownNGram.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			numericUpDownNGram.Name = "numericUpDownNGram";
			numericUpDownNGram.Size = new Size(51, 23);
			numericUpDownNGram.TabIndex = 1;
			numericUpDownNGram.TextAlign = HorizontalAlignment.Center;
			numericUpDownNGram.Value = new decimal(new int[] { 3, 0, 0, 0 });
			// 
			// listViewProperties
			// 
			listViewProperties.Columns.AddRange(new ColumnHeader[] { columnHeaderProperty, columnHeaderValue });
			listViewProperties.FullRowSelect = true;
			listViewProperties.Location = new Point(6, 22);
			listViewProperties.MultiSelect = false;
			listViewProperties.Name = "listViewProperties";
			listViewProperties.ShowItemToolTips = true;
			listViewProperties.Size = new Size(446, 217);
			listViewProperties.TabIndex = 0;
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
			progressBar.Location = new Point(67, 15);
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(105, 23);
			progressBar.Step = 1;
			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.TabIndex = 1;
			// 
			// labelProgressPercent
			// 
			labelProgressPercent.AutoEllipsis = true;
			labelProgressPercent.AutoSize = true;
			labelProgressPercent.Location = new Point(178, 19);
			labelProgressPercent.Name = "labelProgressPercent";
			labelProgressPercent.Size = new Size(17, 15);
			labelProgressPercent.TabIndex = 2;
			labelProgressPercent.Text = "%";
			// 
			// labelNgramLength
			// 
			labelNgramLength.AutoEllipsis = true;
			labelNgramLength.AutoSize = true;
			labelNgramLength.Location = new Point(6, 19);
			labelNgramLength.Name = "labelNgramLength";
			labelNgramLength.Size = new Size(87, 15);
			labelNgramLength.TabIndex = 0;
			labelNgramLength.Text = "n-gram length:";
			// 
			// labelProgress
			// 
			labelProgress.AutoEllipsis = true;
			labelProgress.AutoSize = true;
			labelProgress.Location = new Point(6, 19);
			labelProgress.Name = "labelProgress";
			labelProgress.Size = new Size(55, 15);
			labelProgress.TabIndex = 0;
			labelProgress.Text = "progress:";
			// 
			// textBoxModelText
			// 
			textBoxModelText.Location = new Point(6, 51);
			textBoxModelText.MaxLength = int.MaxValue;
			textBoxModelText.Multiline = true;
			textBoxModelText.Name = "textBoxModelText";
			textBoxModelText.PlaceholderText = "Create a text model...";
			textBoxModelText.ScrollBars = ScrollBars.Vertical;
			textBoxModelText.Size = new Size(629, 210);
			textBoxModelText.TabIndex = 4;
			// 
			// buttonCreateModelText
			// 
			buttonCreateModelText.Location = new Point(200, 22);
			buttonCreateModelText.Name = "buttonCreateModelText";
			buttonCreateModelText.Size = new Size(137, 23);
			buttonCreateModelText.TabIndex = 2;
			buttonCreateModelText.Text = "Create model text";
			buttonCreateModelText.UseVisualStyleBackColor = true;
			buttonCreateModelText.Click += ButtonCreateModelText_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(246, 15);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(115, 23);
			buttonCancel.TabIndex = 3;
			buttonCancel.Text = "Cancel progress";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// labelModelTextLength
			// 
			labelModelTextLength.AutoEllipsis = true;
			labelModelTextLength.AutoSize = true;
			labelModelTextLength.Location = new Point(6, 25);
			labelModelTextLength.Name = "labelModelTextLength";
			labelModelTextLength.Size = new Size(67, 15);
			labelModelTextLength.TabIndex = 0;
			labelModelTextLength.Text = "text length:";
			// 
			// numericUpDownModelTextLength
			// 
			numericUpDownModelTextLength.Location = new Point(79, 22);
			numericUpDownModelTextLength.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
			numericUpDownModelTextLength.Name = "numericUpDownModelTextLength";
			numericUpDownModelTextLength.Size = new Size(115, 23);
			numericUpDownModelTextLength.TabIndex = 1;
			numericUpDownModelTextLength.TextAlign = HorizontalAlignment.Center;
			numericUpDownModelTextLength.Value = new decimal(new int[] { 100000, 0, 0, 0 });
			// 
			// groupBoxTextFile
			// 
			groupBoxTextFile.Controls.Add(textBoxTextFilePath);
			groupBoxTextFile.Controls.Add(buttonSelectTextFile);
			groupBoxTextFile.Location = new Point(12, 12);
			groupBoxTextFile.Name = "groupBoxTextFile";
			groupBoxTextFile.Size = new Size(641, 59);
			groupBoxTextFile.TabIndex = 0;
			groupBoxTextFile.TabStop = false;
			groupBoxTextFile.Text = "Select text file";
			// 
			// textBoxTextFilePath
			// 
			textBoxTextFilePath.Location = new Point(6, 22);
			textBoxTextFilePath.Name = "textBoxTextFilePath";
			textBoxTextFilePath.PlaceholderText = "Select a text file...";
			textBoxTextFilePath.ReadOnly = true;
			textBoxTextFilePath.Size = new Size(508, 23);
			textBoxTextFilePath.TabIndex = 0;
			// 
			// groupBoxNgram
			// 
			groupBoxNgram.Controls.Add(buttonRebuild);
			groupBoxNgram.Controls.Add(numericUpDownNGram);
			groupBoxNgram.Controls.Add(labelNgramLength);
			groupBoxNgram.Location = new Point(12, 77);
			groupBoxNgram.Name = "groupBoxNgram";
			groupBoxNgram.Size = new Size(268, 45);
			groupBoxNgram.TabIndex = 1;
			groupBoxNgram.TabStop = false;
			groupBoxNgram.Text = "N-gram";
			// 
			// buttonRebuild
			// 
			buttonRebuild.Location = new Point(156, 15);
			buttonRebuild.Name = "buttonRebuild";
			buttonRebuild.Size = new Size(106, 23);
			buttonRebuild.TabIndex = 2;
			buttonRebuild.Text = "Rebuild token list";
			buttonRebuild.UseVisualStyleBackColor = true;
			buttonRebuild.Click += ButtonRebuildTokenList_Click;
			// 
			// groupBoxProgress
			// 
			groupBoxProgress.Controls.Add(progressBar);
			groupBoxProgress.Controls.Add(labelProgressPercent);
			groupBoxProgress.Controls.Add(labelProgress);
			groupBoxProgress.Controls.Add(buttonCancel);
			groupBoxProgress.Location = new Point(286, 77);
			groupBoxProgress.Name = "groupBoxProgress";
			groupBoxProgress.Size = new Size(367, 45);
			groupBoxProgress.TabIndex = 2;
			groupBoxProgress.TabStop = false;
			groupBoxProgress.Text = "Progress";
			// 
			// groupBoxTokenFrequency
			// 
			groupBoxTokenFrequency.Controls.Add(buttonSaveTokenListAsCsv);
			groupBoxTokenFrequency.Controls.Add(listViewToken);
			groupBoxTokenFrequency.Location = new Point(12, 128);
			groupBoxTokenFrequency.Name = "groupBoxTokenFrequency";
			groupBoxTokenFrequency.Size = new Size(177, 245);
			groupBoxTokenFrequency.TabIndex = 3;
			groupBoxTokenFrequency.TabStop = false;
			groupBoxTokenFrequency.Text = "Token Frequency";
			// 
			// buttonSaveTokenListAsCsv
			// 
			buttonSaveTokenListAsCsv.Location = new Point(6, 216);
			buttonSaveTokenListAsCsv.Name = "buttonSaveTokenListAsCsv";
			buttonSaveTokenListAsCsv.Size = new Size(163, 23);
			buttonSaveTokenListAsCsv.TabIndex = 1;
			buttonSaveTokenListAsCsv.Text = "Save as CSV";
			buttonSaveTokenListAsCsv.UseVisualStyleBackColor = true;
			buttonSaveTokenListAsCsv.Click += ButtonSaveTokenListAsCsv_Click;
			// 
			// groupBoxProperties
			// 
			groupBoxProperties.Controls.Add(listViewProperties);
			groupBoxProperties.Location = new Point(195, 128);
			groupBoxProperties.Name = "groupBoxProperties";
			groupBoxProperties.Size = new Size(458, 245);
			groupBoxProperties.TabIndex = 4;
			groupBoxProperties.TabStop = false;
			groupBoxProperties.Text = "Properties";
			// 
			// groupBoxModelText
			// 
			groupBoxModelText.Controls.Add(buttonSaveAsTextFile);
			groupBoxModelText.Controls.Add(textBoxModelText);
			groupBoxModelText.Controls.Add(labelModelTextLength);
			groupBoxModelText.Controls.Add(numericUpDownModelTextLength);
			groupBoxModelText.Controls.Add(buttonCreateModelText);
			groupBoxModelText.Location = new Point(12, 379);
			groupBoxModelText.Name = "groupBoxModelText";
			groupBoxModelText.Size = new Size(641, 267);
			groupBoxModelText.TabIndex = 5;
			groupBoxModelText.TabStop = false;
			groupBoxModelText.Text = "Model text";
			// 
			// buttonSaveAsTextFile
			// 
			buttonSaveAsTextFile.Location = new Point(343, 22);
			buttonSaveAsTextFile.Name = "buttonSaveAsTextFile";
			buttonSaveAsTextFile.Size = new Size(126, 23);
			buttonSaveAsTextFile.TabIndex = 3;
			buttonSaveAsTextFile.Text = "Save as text file";
			buttonSaveAsTextFile.UseVisualStyleBackColor = true;
			buttonSaveAsTextFile.Click += ButtonSaveModelText_Click;
			// 
			// saveFileDialogTokenList
			// 
			saveFileDialogTokenList.DefaultExt = "csv";
			saveFileDialogTokenList.Filter = "CSV files|*.csv|all files|*.*";
			saveFileDialogTokenList.OkRequiresInteraction = true;
			// 
			// saveFileDialogModelText
			// 
			saveFileDialogModelText.DefaultExt = "txt";
			saveFileDialogModelText.Filter = "text files|*.txt|all files|*.*";
			saveFileDialogModelText.OkRequiresInteraction = true;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(665, 658);
			Controls.Add(groupBoxModelText);
			Controls.Add(groupBoxProperties);
			Controls.Add(groupBoxTokenFrequency);
			Controls.Add(groupBoxProgress);
			Controls.Add(groupBoxNgram);
			Controls.Add(groupBoxTextFile);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "GraML";
			Load += MainForm_Load;
			((System.ComponentModel.ISupportInitialize)numericUpDownNGram).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownModelTextLength).EndInit();
			groupBoxTextFile.ResumeLayout(false);
			groupBoxTextFile.PerformLayout();
			groupBoxNgram.ResumeLayout(false);
			groupBoxNgram.PerformLayout();
			groupBoxProgress.ResumeLayout(false);
			groupBoxProgress.PerformLayout();
			groupBoxTokenFrequency.ResumeLayout(false);
			groupBoxProperties.ResumeLayout(false);
			groupBoxModelText.ResumeLayout(false);
			groupBoxModelText.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button buttonSelectTextFile;
		private OpenFileDialog openFileDialog;
		private ListView listViewToken;
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
		private GroupBox groupBoxTextFile;
		private TextBox textBoxTextFilePath;
		private GroupBox groupBoxNgram;
		private GroupBox groupBoxProgress;
		private GroupBox groupBoxTokenFrequency;
		private GroupBox groupBoxProperties;
		private Button buttonRebuild;
		private Button buttonSaveTokenListAsCsv;
		private GroupBox groupBoxModelText;
		private Button buttonSaveAsTextFile;
		private SaveFileDialog saveFileDialogTokenList;
		private SaveFileDialog saveFileDialogModelText;
	}
}
