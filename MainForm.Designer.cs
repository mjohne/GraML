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
			components = new System.ComponentModel.Container();
			buttonSelectTextFile = new Button();
			openFileDialog = new OpenFileDialog();
			listViewToken = new ListView();
			columnHeaderToken = new ColumnHeader();
			columnHeaderFrequency = new ColumnHeader();
			numericUpDownNGram = new NumericUpDown();
			listViewMetrics = new ListView();
			columnHeaderMetrics = new ColumnHeader();
			columnHeaderValue = new ColumnHeader();
			backgroundWorker = new System.ComponentModel.BackgroundWorker();
			progressBar = new ProgressBar();
			labelProgressPercent = new Label();
			labelNgramLength = new Label();
			labelProgress = new Label();
			textBoxModelText = new TextBox();
			buttonGenerateModelText = new Button();
			buttonCancel = new Button();
			labelModelTextLength = new Label();
			numericUpDownModelTextLength = new NumericUpDown();
			groupBoxTextFile = new GroupBox();
			textBoxTextFilePath = new TextBox();
			groupBoxNgram = new GroupBox();
			buttonBuildTokenList = new Button();
			groupBoxProgress = new GroupBox();
			groupBoxTokenFrequency = new GroupBox();
			buttonSaveTokenListAsCsv = new Button();
			groupBoxMetrics = new GroupBox();
			groupBoxModelText = new GroupBox();
			buttonSaveAsTextFile = new Button();
			saveFileDialogTokenList = new SaveFileDialog();
			saveFileDialogModelText = new SaveFileDialog();
			toolTip = new ToolTip(components);
			((System.ComponentModel.ISupportInitialize)numericUpDownNGram).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDownModelTextLength).BeginInit();
			groupBoxTextFile.SuspendLayout();
			groupBoxNgram.SuspendLayout();
			groupBoxProgress.SuspendLayout();
			groupBoxTokenFrequency.SuspendLayout();
			groupBoxMetrics.SuspendLayout();
			groupBoxModelText.SuspendLayout();
			SuspendLayout();
			// 
			// buttonSelectTextFile
			// 
			buttonSelectTextFile.AccessibleRole = AccessibleRole.PushButton;
			buttonSelectTextFile.AutoEllipsis = true;
			buttonSelectTextFile.Location = new Point(520, 22);
			buttonSelectTextFile.Name = "buttonSelectTextFile";
			buttonSelectTextFile.Size = new Size(115, 23);
			buttonSelectTextFile.TabIndex = 1;
			buttonSelectTextFile.Text = "Se&lect text file";
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
			listViewToken.AccessibleRole = AccessibleRole.List;
			listViewToken.Columns.AddRange(new ColumnHeader[] { columnHeaderToken, columnHeaderFrequency });
			listViewToken.FullRowSelect = true;
			listViewToken.Location = new Point(6, 22);
			listViewToken.MultiSelect = false;
			listViewToken.Name = "listViewToken";
			listViewToken.ShowItemToolTips = true;
			listViewToken.Size = new Size(165, 188);
			listViewToken.TabIndex = 0;
			toolTip.SetToolTip(listViewToken, "Token frequency");
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
			numericUpDownNGram.AccessibleRole = AccessibleRole.SpinButton;
			numericUpDownNGram.Location = new Point(99, 15);
			numericUpDownNGram.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			numericUpDownNGram.Name = "numericUpDownNGram";
			numericUpDownNGram.Size = new Size(51, 23);
			numericUpDownNGram.TabIndex = 1;
			numericUpDownNGram.TextAlign = HorizontalAlignment.Center;
			toolTip.SetToolTip(numericUpDownNGram, "n-gram length");
			numericUpDownNGram.Value = new decimal(new int[] { 3, 0, 0, 0 });
			// 
			// listViewMetrics
			// 
			listViewMetrics.AccessibleRole = AccessibleRole.List;
			listViewMetrics.Columns.AddRange(new ColumnHeader[] { columnHeaderMetrics, columnHeaderValue });
			listViewMetrics.FullRowSelect = true;
			listViewMetrics.Location = new Point(6, 22);
			listViewMetrics.MultiSelect = false;
			listViewMetrics.Name = "listViewMetrics";
			listViewMetrics.ShowItemToolTips = true;
			listViewMetrics.Size = new Size(446, 217);
			listViewMetrics.TabIndex = 0;
			toolTip.SetToolTip(listViewMetrics, "Metrics");
			listViewMetrics.UseCompatibleStateImageBehavior = false;
			listViewMetrics.View = View.Details;
			// 
			// columnHeaderMetrics
			// 
			columnHeaderMetrics.Text = "Metrics";
			columnHeaderMetrics.Width = 300;
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
			progressBar.AccessibleRole = AccessibleRole.ProgressBar;
			progressBar.Location = new Point(67, 15);
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(105, 23);
			progressBar.Step = 1;
			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.TabIndex = 1;
			toolTip.SetToolTip(progressBar, "progress bar");
			// 
			// labelProgressPercent
			// 
			labelProgressPercent.AccessibleRole = AccessibleRole.StaticText;
			labelProgressPercent.AutoEllipsis = true;
			labelProgressPercent.AutoSize = true;
			labelProgressPercent.Location = new Point(178, 19);
			labelProgressPercent.Name = "labelProgressPercent";
			labelProgressPercent.Size = new Size(17, 15);
			labelProgressPercent.TabIndex = 2;
			labelProgressPercent.Text = "%";
			toolTip.SetToolTip(labelProgressPercent, "progress in percent (%)");
			// 
			// labelNgramLength
			// 
			labelNgramLength.AccessibleRole = AccessibleRole.StaticText;
			labelNgramLength.AutoEllipsis = true;
			labelNgramLength.AutoSize = true;
			labelNgramLength.Location = new Point(6, 19);
			labelNgramLength.Name = "labelNgramLength";
			labelNgramLength.Size = new Size(87, 15);
			labelNgramLength.TabIndex = 0;
			labelNgramLength.Text = "n-gra&m length:";
			toolTip.SetToolTip(labelNgramLength, "n-gram length");
			// 
			// labelProgress
			// 
			labelProgress.AccessibleRole = AccessibleRole.StaticText;
			labelProgress.AutoEllipsis = true;
			labelProgress.AutoSize = true;
			labelProgress.Location = new Point(6, 19);
			labelProgress.Name = "labelProgress";
			labelProgress.Size = new Size(55, 15);
			labelProgress.TabIndex = 0;
			labelProgress.Text = "pro&gress:";
			toolTip.SetToolTip(labelProgress, "progress");
			// 
			// textBoxModelText
			// 
			textBoxModelText.AccessibleRole = AccessibleRole.Text;
			textBoxModelText.Location = new Point(6, 51);
			textBoxModelText.MaxLength = int.MaxValue;
			textBoxModelText.Multiline = true;
			textBoxModelText.Name = "textBoxModelText";
			textBoxModelText.PlaceholderText = "Create a text model...";
			textBoxModelText.ScrollBars = ScrollBars.Vertical;
			textBoxModelText.Size = new Size(629, 210);
			textBoxModelText.TabIndex = 4;
			toolTip.SetToolTip(textBoxModelText, "Generated model text");
			// 
			// buttonGenerateModelText
			// 
			buttonGenerateModelText.AccessibleRole = AccessibleRole.PushButton;
			buttonGenerateModelText.AutoEllipsis = true;
			buttonGenerateModelText.Location = new Point(200, 22);
			buttonGenerateModelText.Name = "buttonGenerateModelText";
			buttonGenerateModelText.Size = new Size(137, 23);
			buttonGenerateModelText.TabIndex = 2;
			buttonGenerateModelText.Text = "Gene&rate model text";
			buttonGenerateModelText.UseVisualStyleBackColor = true;
			buttonGenerateModelText.Click += ButtonGenerateModelText_Click;
			// 
			// buttonCancel
			// 
			buttonCancel.AccessibleRole = AccessibleRole.PushButton;
			buttonCancel.AutoEllipsis = true;
			buttonCancel.Location = new Point(246, 15);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(115, 23);
			buttonCancel.TabIndex = 3;
			buttonCancel.Text = "&Cancel progress";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// labelModelTextLength
			// 
			labelModelTextLength.AccessibleRole = AccessibleRole.StaticText;
			labelModelTextLength.AutoEllipsis = true;
			labelModelTextLength.AutoSize = true;
			labelModelTextLength.Location = new Point(6, 25);
			labelModelTextLength.Name = "labelModelTextLength";
			labelModelTextLength.Size = new Size(67, 15);
			labelModelTextLength.TabIndex = 0;
			labelModelTextLength.Text = "text lengt&h:";
			toolTip.SetToolTip(labelModelTextLength, "text length");
			// 
			// numericUpDownModelTextLength
			// 
			numericUpDownModelTextLength.AccessibleRole = AccessibleRole.SpinButton;
			numericUpDownModelTextLength.Location = new Point(79, 22);
			numericUpDownModelTextLength.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
			numericUpDownModelTextLength.Name = "numericUpDownModelTextLength";
			numericUpDownModelTextLength.Size = new Size(115, 23);
			numericUpDownModelTextLength.TabIndex = 1;
			numericUpDownModelTextLength.TextAlign = HorizontalAlignment.Center;
			toolTip.SetToolTip(numericUpDownModelTextLength, "length of the model text");
			numericUpDownModelTextLength.Value = new decimal(new int[] { 100000, 0, 0, 0 });
			// 
			// groupBoxTextFile
			// 
			groupBoxTextFile.AccessibleRole = AccessibleRole.Grouping;
			groupBoxTextFile.Controls.Add(textBoxTextFilePath);
			groupBoxTextFile.Controls.Add(buttonSelectTextFile);
			groupBoxTextFile.Location = new Point(12, 12);
			groupBoxTextFile.Name = "groupBoxTextFile";
			groupBoxTextFile.Size = new Size(641, 59);
			groupBoxTextFile.TabIndex = 0;
			groupBoxTextFile.TabStop = false;
			groupBoxTextFile.Text = "&Select text file";
			// 
			// textBoxTextFilePath
			// 
			textBoxTextFilePath.AccessibleRole = AccessibleRole.Text;
			textBoxTextFilePath.Location = new Point(6, 22);
			textBoxTextFilePath.Name = "textBoxTextFilePath";
			textBoxTextFilePath.PlaceholderText = "Select a text file...";
			textBoxTextFilePath.ReadOnly = true;
			textBoxTextFilePath.Size = new Size(508, 23);
			textBoxTextFilePath.TabIndex = 0;
			toolTip.SetToolTip(textBoxTextFilePath, "file path and name");
			// 
			// groupBoxNgram
			// 
			groupBoxNgram.AccessibleRole = AccessibleRole.Grouping;
			groupBoxNgram.Controls.Add(buttonBuildTokenList);
			groupBoxNgram.Controls.Add(numericUpDownNGram);
			groupBoxNgram.Controls.Add(labelNgramLength);
			groupBoxNgram.Location = new Point(12, 77);
			groupBoxNgram.Name = "groupBoxNgram";
			groupBoxNgram.Size = new Size(268, 45);
			groupBoxNgram.TabIndex = 1;
			groupBoxNgram.TabStop = false;
			groupBoxNgram.Text = "&N-gram";
			// 
			// buttonBuildTokenList
			// 
			buttonBuildTokenList.AccessibleRole = AccessibleRole.PushButton;
			buttonBuildTokenList.AutoEllipsis = true;
			buttonBuildTokenList.Location = new Point(156, 15);
			buttonBuildTokenList.Name = "buttonBuildTokenList";
			buttonBuildTokenList.Size = new Size(106, 23);
			buttonBuildTokenList.TabIndex = 2;
			buttonBuildTokenList.Text = "&Build token list";
			buttonBuildTokenList.UseVisualStyleBackColor = true;
			buttonBuildTokenList.Click += ButtonBuildTokenList_Click;
			// 
			// groupBoxProgress
			// 
			groupBoxProgress.AccessibleRole = AccessibleRole.Grouping;
			groupBoxProgress.Controls.Add(progressBar);
			groupBoxProgress.Controls.Add(labelProgressPercent);
			groupBoxProgress.Controls.Add(labelProgress);
			groupBoxProgress.Controls.Add(buttonCancel);
			groupBoxProgress.Location = new Point(286, 77);
			groupBoxProgress.Name = "groupBoxProgress";
			groupBoxProgress.Size = new Size(367, 45);
			groupBoxProgress.TabIndex = 2;
			groupBoxProgress.TabStop = false;
			groupBoxProgress.Text = "&Progress";
			// 
			// groupBoxTokenFrequency
			// 
			groupBoxTokenFrequency.AccessibleRole = AccessibleRole.Grouping;
			groupBoxTokenFrequency.Controls.Add(buttonSaveTokenListAsCsv);
			groupBoxTokenFrequency.Controls.Add(listViewToken);
			groupBoxTokenFrequency.Location = new Point(12, 128);
			groupBoxTokenFrequency.Name = "groupBoxTokenFrequency";
			groupBoxTokenFrequency.Size = new Size(177, 245);
			groupBoxTokenFrequency.TabIndex = 3;
			groupBoxTokenFrequency.TabStop = false;
			groupBoxTokenFrequency.Text = "&Token Frequency";
			// 
			// buttonSaveTokenListAsCsv
			// 
			buttonSaveTokenListAsCsv.AccessibleRole = AccessibleRole.PushButton;
			buttonSaveTokenListAsCsv.AutoEllipsis = true;
			buttonSaveTokenListAsCsv.Location = new Point(6, 216);
			buttonSaveTokenListAsCsv.Name = "buttonSaveTokenListAsCsv";
			buttonSaveTokenListAsCsv.Size = new Size(165, 23);
			buttonSaveTokenListAsCsv.TabIndex = 1;
			buttonSaveTokenListAsCsv.Text = "Save as &CSV file";
			buttonSaveTokenListAsCsv.UseVisualStyleBackColor = true;
			buttonSaveTokenListAsCsv.Click += ButtonSaveTokenListAsCsv_Click;
			// 
			// groupBoxMetrics
			// 
			groupBoxMetrics.AccessibleRole = AccessibleRole.Grouping;
			groupBoxMetrics.Controls.Add(listViewMetrics);
			groupBoxMetrics.Location = new Point(195, 128);
			groupBoxMetrics.Name = "groupBoxMetrics";
			groupBoxMetrics.Size = new Size(458, 245);
			groupBoxMetrics.TabIndex = 4;
			groupBoxMetrics.TabStop = false;
			groupBoxMetrics.Text = "&Metrics";
			// 
			// groupBoxModelText
			// 
			groupBoxModelText.AccessibleRole = AccessibleRole.Grouping;
			groupBoxModelText.Controls.Add(buttonSaveAsTextFile);
			groupBoxModelText.Controls.Add(textBoxModelText);
			groupBoxModelText.Controls.Add(labelModelTextLength);
			groupBoxModelText.Controls.Add(numericUpDownModelTextLength);
			groupBoxModelText.Controls.Add(buttonGenerateModelText);
			groupBoxModelText.Location = new Point(12, 379);
			groupBoxModelText.Name = "groupBoxModelText";
			groupBoxModelText.Size = new Size(641, 267);
			groupBoxModelText.TabIndex = 5;
			groupBoxModelText.TabStop = false;
			groupBoxModelText.Text = "Mo&del text";
			// 
			// buttonSaveAsTextFile
			// 
			buttonSaveAsTextFile.AccessibleRole = AccessibleRole.PushButton;
			buttonSaveAsTextFile.AutoEllipsis = true;
			buttonSaveAsTextFile.Location = new Point(343, 22);
			buttonSaveAsTextFile.Name = "buttonSaveAsTextFile";
			buttonSaveAsTextFile.Size = new Size(126, 23);
			buttonSaveAsTextFile.TabIndex = 3;
			buttonSaveAsTextFile.Text = "Save as text &file";
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
			AccessibleRole = AccessibleRole.Window;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(665, 658);
			Controls.Add(groupBoxModelText);
			Controls.Add(groupBoxMetrics);
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
			groupBoxMetrics.ResumeLayout(false);
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
		private ListView listViewMetrics;
		private ColumnHeader columnHeaderMetrics;
		private ColumnHeader columnHeaderValue;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private ProgressBar progressBar;
		private Label labelProgressPercent;
		private Label labelNgramLength;
		private Label labelProgress;
		private TextBox textBoxModelText;
		private Button buttonGenerateModelText;
		private Button buttonCancel;
		private Label labelModelTextLength;
		private NumericUpDown numericUpDownModelTextLength;
		private GroupBox groupBoxTextFile;
		private TextBox textBoxTextFilePath;
		private GroupBox groupBoxNgram;
		private GroupBox groupBoxProgress;
		private GroupBox groupBoxTokenFrequency;
		private GroupBox groupBoxMetrics;
		private Button buttonBuildTokenList;
		private Button buttonSaveTokenListAsCsv;
		private GroupBox groupBoxModelText;
		private Button buttonSaveAsTextFile;
		private SaveFileDialog saveFileDialogTokenList;
		private SaveFileDialog saveFileDialogModelText;
		private ToolTip toolTip;
	}
}
