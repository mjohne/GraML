using System.Text;
using System.Text.Json;

namespace GraML
{
	public partial class MainForm : Form
	{
		#region Variables

		// Feld zum Speichern der Token als Array für VirtualMode
		private KeyValuePair<string, int>[] tokenArray = [];

		private Dictionary<string, int>? ngramCounts;

		private int n;

		private int fileLength;

		private string filePath = string.Empty;

		private string fileContent = string.Empty;

		// CancellationTokenSource für die Task-basierte Variante
		private CancellationTokenSource? _cts;

		#endregion

		#region Helpers

		// Sequenzielle Variante, jetzt Task-freundlich: CancellationToken + IProgress<int>
		private static Dictionary<string, int> CountNgrams(ReadOnlySpan<char> text, int n, CancellationToken ct, IProgress<int>? progress)
		{
			if (n <= 0 || text.Length < n)
			{
				return new Dictionary<string, int>(capacity: 0, comparer: StringComparer.Ordinal);
			}

			int possible = text.Length - n + 1;
			Dictionary<string, int> dict = new(capacity: Math.Max(val1: 4, val2: possible), comparer: StringComparer.Ordinal);

			for (int i = 0; i < possible; i++)
			{
				ct.ThrowIfCancellationRequested();

				string token = new(value: text.Slice(start: i, length: n));
				dict[key: token] = dict.TryGetValue(key: token, value: out int cnt) ? cnt + 1 : 1;

				if (progress != null)
				{
					int percent = (int)((i + 1) * 100L / possible);
					progress.Report(value: percent);
				}
			}

			return dict;
		}

		// Kümmert sich ausschließlich um die UI-Anzeige der berechneten Kennzahlen
		private void UpdateNgramProperties(Dictionary<string, int> dict, int n)
		{
			if (dict == null || dict.Count == 0)
			{
				AddProperty(name: "n-gram length", value: $"{n}");
				AddProperty(name: "Total unique n-grams", value: "0");
				return;
			}

			int total = dict.Values.Sum();
			int unique = dict.Count;
			double average = dict.Values.Average();
			int[] orderedFreqs = [.. dict.Values.OrderBy(keySelector: v => v)];
			double median = (orderedFreqs.Length % 2 == 1)
				? orderedFreqs[orderedFreqs.Length / 2]
				: (orderedFreqs[(orderedFreqs.Length / 2) - 1] + orderedFreqs[orderedFreqs.Length / 2]) / 2.0;

			KeyValuePair<string, int> most = dict.MaxBy(keySelector: kv => kv.Value);
			KeyValuePair<string, int> least = dict.MinBy(keySelector: kv => kv.Value);

			double[] probs = [.. dict.Values.Select(selector: v => (double)v / total)];
			double entropy = -probs.Where(predicate: p => p > 0).Sum(selector: p => p * Math.Log2(x: p));
			double gini = 1 - probs.Sum(selector: p => p * p);

			AddProperty(name: "n-gram length", value: $"{n}");
			AddProperty(name: "Total unique n-grams", value: $"{unique}");
			AddProperty(name: "Total n-grams", value: $"{total}");
			AddProperty(name: "Proportion of unique n-grams", value: $"{unique / (double)total:F4}");
			AddProperty(name: "Average frequency of n-grams", value: $"{average:F4}");
			AddProperty(name: "Median frequency of n-grams", value: $"{median:F4}");
			AddProperty(name: "Standard deviation of n-gram frequencies", value: $"{Math.Sqrt(d: dict.Values.Average(selector: v => Math.Pow(x: v - average, y: 2))):F4}");
			AddProperty(name: "Variance of n-gram frequencies", value: $"{dict.Values.Average(selector: v => Math.Pow(x: v - average, y: 2)):F4}");
			AddProperty(name: "Range of n-gram frequencies", value: $"{dict.Values.Max() - dict.Values.Min()}");
			AddProperty(name: "Count of n-grams with frequency 1", value: $"{dict.Values.Count(predicate: v => v == 1)}");
			AddProperty(name: "Count of n-grams with frequency greater than average", value: $"{dict.Values.Count(predicate: v => v > average)}");
			AddProperty(name: "Count of n-grams with frequency less than average", value: $"{dict.Values.Count(predicate: v => v < average)}");
			AddProperty(name: "Frequency distribution of n-grams", value: string.Join(separator: ", ", values: dict.GroupBy(keySelector: kv => kv.Value).OrderBy(keySelector: g => g.Key).Select(selector: g => $"{g.Key}: {g.Count()}")));
			AddProperty(name: "Entropy of n-gram distribution", value: $"{entropy:F4}");
			AddProperty(name: "Gini coefficient of n-gram distribution", value: $"{gini:F4}");
			AddProperty(name: "Yule's K Measure", value: $"{10000 * (dict.Values.Sum(selector: v => v * v) - dict.Values.Sum()) / (double)(total * total):F4}");
			AddProperty(name: "Normalized Entropy", value: $"{entropy / Math.Log2(x: dict.Count):F4}");
			AddProperty(name: "Hapax Legomena (occurring once)", value: $"{dict.Values.Count(predicate: v => v == 1)}");
			AddProperty(name: "Dis Legomena (occurring twice)", value: $"{dict.Values.Count(predicate: v => v == 2)}");
			AddProperty(name: "Tris Legomena (occurring thrice)", value: $"{dict.Values.Count(predicate: v => v == 3)}");
			AddProperty(name: "Tetrakis Legomena (occurring four times)", value: $"{dict.Values.Count(predicate: v => v == 4)}");
			AddProperty(name: "Pentakis Legomena (occurring five times)", value: $"{dict.Values.Count(predicate: v => v == 5)}");
			AddProperty(name: "Hexakis Legomena (occurring six times)", value: $"{dict.Values.Count(predicate: v => v == 6)}");
			AddProperty(name: "Ratio of Hapax Legomena to total", value: $"{dict.Values.Count(predicate: v => v == 1) / (double)total:F4}");
			AddProperty(name: "Ratio of Dis Legomena to total", value: $"{dict.Values.Count(predicate: v => v == 2) / (double)total:F4}");
			AddProperty(name: "Ratio of Tris Legomena to total", value: $"{dict.Values.Count(predicate: v => v == 3) / (double)total:F4}");
			AddProperty(name: "Ratio of Tetrakis Legomena to total", value: $"{dict.Values.Count(predicate: v => v == 4) / (double)total:F4}");
			AddProperty(name: "Ratio of Pentakis Legomena to total", value: $"{dict.Values.Count(predicate: v => v == 5) / (double)total:F4}");
			AddProperty(name: "Ratio of Hexakis Legomena to total", value: $"{dict.Values.Count(predicate: v => v == 6) / (double)total:F4}");
			AddProperty(name: "Most frequent n-gram", value: $"{most.Key} ({most.Value} occurrences)");
			AddProperty(name: "Least frequent n-gram", value: $"{least.Key} ({least.Value} occurrences)");
			AddProperty(name: "Top 5 most frequent n-grams", value: string.Join(separator: ", ", values: dict.OrderByDescending(keySelector: kv => kv.Value).Take(count: 5).Select(selector: kv => $"{kv.Key} ({kv.Value})")));
			AddProperty(name: "Top 5 least frequent n-grams", value: string.Join(separator: ", ", values: dict.OrderBy(keySelector: kv => kv.Value).Take(count: 5).Select(selector: kv => $"{kv.Key} ({kv.Value})")));
		}

		private void AddProperty(string name, string value)
		{
			ListViewItem item = new(text: name);
			item.SubItems.Add(text: value);
			listViewMetrics.Items.Add(value: item);
		}

		// Generiert Modelltext basierend auf den gezählten N‑Grams.
		// - n: Größe der N‑Gramme (muss mit den Keys in ngramCounts übereinstimmen).
		// - length: gewünschte Länge des Ausgabetexts in Zeichen.
		// - rng: optional für reproduzierbare Ergebnisse.
		private static string GenerateModelText(Dictionary<string, int> ngramCounts, int n, int length, Random? rng = null)
		{
			if (ngramCounts == null || ngramCounts.Count == 0 || n <= 0 || length <= 0)
			{
				return string.Empty;
			}

			rng ??= new Random();

			// Hilfsfunktion: gewichtete Auswahl aus (keys, weights)
			static char WeightedPick(char[] choices, int[] cumWeights, int total, Random rngLocal)
			{
				int r = rngLocal.Next(maxValue: total);
				int idx = Array.BinarySearch(array: cumWeights, value: r);
				if (idx < 0)
				{
					idx = ~idx;
				}

				if (idx >= choices.Length)
				{
					idx = choices.Length - 1;
				}

				return choices[idx];
			}

			// Fall n == 1: einfache gewichtete Auswahl auf einzelnen Zeichen
			if (n == 1)
			{
				List<char> chars = [];
				List<int> cum = [];
				int total = 0;
				foreach (KeyValuePair<string, int> kv in ngramCounts)
				{
					if (string.IsNullOrEmpty(value: kv.Key))
					{
						continue;
					}

					char c = kv.Key[index: 0];
					total += kv.Value;
					chars.Add(item: c);
					cum.Add(item: total);
				}
				if (chars.Count == 0)
				{
					return string.Empty;
				}

				StringBuilder sb1 = new(capacity: length);
				for (int i = 0; i < length; i++)
				{
					sb1.Append(value: WeightedPick(choices: [.. chars], cumWeights: [.. cum], total: total, rngLocal: rng));
				}

				return sb1.ToString();
			}

			// Allgemeiner Fall n >= 2
			// Baue Mapping: prefix (n-1 chars) -> (choices[], cumulativeWeights[], total)
			Dictionary<string, Dictionary<char, int>> prefixBuckets = new(comparer: StringComparer.Ordinal);
			int globalTotal = 0;

			foreach (KeyValuePair<string, int> kv in ngramCounts)
			{
				string gram = kv.Key;
				if (gram == null || gram.Length != n)
				{
					continue;
				}

				string prefix = gram[..(n - 1)];
				char next = gram[index: n - 1];

				if (!prefixBuckets.TryGetValue(key: prefix, value: out Dictionary<char, int>? inner))
				{
					inner = [];
					prefixBuckets[key: prefix] = inner;
				}

				inner[key: next] = inner.TryGetValue(key: next, value: out int cnt) ? cnt + kv.Value : kv.Value;

				globalTotal += kv.Value;
			}

			if (prefixBuckets.Count == 0)
			{
				return string.Empty;
			}

			// Wandle inner dictionaries in arrays (choices + cumulative weights)
			Dictionary<string, (char[] choices, int[] cumWeights, int total)> prefixMap = new(StringComparer.Ordinal);
			foreach (KeyValuePair<string, Dictionary<char, int>> p in prefixBuckets)
			{
				char[] choices = [.. p.Value.Keys];
				int[] weights = [.. p.Value.Values];
				int[] cum = new int[weights.Length];
				int sum = 0;
				for (int i = 0; i < weights.Length; i++)
				{
					sum += weights[i];
					cum[i] = sum;
				}
				prefixMap[key: p.Key] = (choices, cum, sum);
			}

			// Wähle Startprefix: gewichteter Pick über alle N‑Gramme (nach Häufigkeit)
			int rstart = rng.Next(maxValue: globalTotal);
			int acc = 0;
			string startPrefix = prefixMap.Keys.First(); // fallback
			foreach (KeyValuePair<string, int> kv in ngramCounts)
			{
				if (kv.Key == null || kv.Key.Length != n)
				{
					continue;
				}

				acc += kv.Value;
				if (acc > rstart)
				{
					startPrefix = kv.Key[..(n - 1)];
					break;
				}
			}

			StringBuilder sb = new(capacity: length);
			// initial: füge Startprefix bei
			sb.Append(value: startPrefix);

			// Generiere weiter, bis gewünschte Länge erreicht oder kein Übergang mehr existiert
			while (sb.Length < length)
			{
				string curPrefix = sb.Length >= (n - 1)
					? sb.ToString(startIndex: sb.Length - (n - 1), length: n - 1)
					: sb.ToString(); // sollte normalerweise nicht nötig

				if (!prefixMap.TryGetValue(key: curPrefix, value: out (char[] choices, int[] cumWeights, int total) bucket))
				{
					// Kein passender Übergang: wähle zufällig einen existierenden Prefix neu
					// (vermeidet frühes Abbrechen)
					string[] keys = [.. prefixMap.Keys];
					curPrefix = keys[rng.Next(maxValue: keys.Length)];
					sb.Append(value: curPrefix); // kann Länge erhöhen; prüfe dann beim nächsten Loop
					if (sb.Length >= length)
					{
						break;
					}

					continue;
				}

				char next = WeightedPick(bucket.choices, bucket.cumWeights, bucket.total, rngLocal: rng);
				sb.Append(value: next);
				// slide window automatisch durch sb; loop setzt curPrefix beim nächsten Durchlauf neu
			}

			// Falls länger als gewünscht, trimmen
			return sb.Length > length ? sb.ToString(startIndex: 0, length: length) : sb.ToString();
		}

		private void SaveListViewTokenToCsv(string? path = null)
		{
			// Falls kein Pfad übergeben wurde, SaveFileDialog anzeigen
			if (string.IsNullOrEmpty(value: path))
			{
				if (saveFileDialogTokenList.ShowDialog(owner: this) != DialogResult.OK)
				{
					return;
				}

				path = saveFileDialogTokenList.FileName;
			}

			// Kopfzeile und Zeilen erzeugen
			StringBuilder sb = new();
			sb.AppendLine(value: "Token,Count");

			foreach (ListViewItem item in listViewToken.Items)
			{
				string token = item.Text ?? string.Empty;
				string count = item.SubItems.Count > 1 ? item.SubItems[index: 1].Text ?? string.Empty : string.Empty;
				sb.AppendLine(handler: $"{EscapeCsv(value: token)},{EscapeCsv(value: count)}");
			}

			// Datei schreiben (UTF-8 mit BOM)
			File.WriteAllText(path: path, contents: sb.ToString(), encoding: new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));

			MessageBox.Show(text: $"CSV file saved: {path}", caption: "Export completed", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
		}

		private static string EscapeCsv(string value)
		{
			if (string.IsNullOrEmpty(value: value))
			{
				return string.Empty;
			}

			bool mustQuote = value.Contains(value: ',') || value.Contains(value: '"') || value.Contains(value: '\n') || value.Contains(value: '\r');
			if (!mustQuote)
			{
				return value;
			}

			// Doppelte Anführungszeichen verdoppeln und den Wert in Anführungszeichen setzen
			return $"\"{value.Replace(oldValue: "\"", newValue: "\"\"")}\"";
		}

		private void SaveModelTextToFile(string? path = null)
		{
			// Inhalt prüfen
			string content = textBoxModelText?.Text ?? string.Empty;
			if (string.IsNullOrWhiteSpace(value: content))
			{
				MessageBox.Show(text: "No model text to save.", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
				return;
			}

			// Falls kein Pfad angegeben, SaveFileDialog anzeigen
			if (string.IsNullOrEmpty(value: path))
			{
				if (saveFileDialogModelText.ShowDialog(owner: this) != DialogResult.OK)
				{
					return;
				}

				path = saveFileDialogModelText.FileName;
			}

			// Schreiben mit BOM (UTF-8)
			try
			{
				File.WriteAllText(path: path, contents: content, encoding: new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
				MessageBox.Show(text: $"Model text saved: {path}", caption: "Export completed", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(text: ex.Message, caption: "Error saving", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
		}
		private static readonly JsonSerializerOptions SharedJsonOptions = new() { WriteIndented = true };

		private void SaveMetricsToJson(string? path = null)
		{
			// Keine Metriken -> nichts tun
			if (listViewMetrics.Items.Count == 0)
			{
				MessageBox.Show(text: "No metrics to export.", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
				return;
			}

			// Falls kein Pfad übergeben wurde, SaveFileDialog anzeigen
			if (string.IsNullOrEmpty(value: path))
			{
				if (saveFileDialogMetrics.ShowDialog(owner: this) != DialogResult.OK)
				{
					return;
				}

				path = saveFileDialogMetrics.FileName;
			}

			// Metriken aus listViewMetrics extrahieren
			List<Dictionary<string, string>> metricsList = new(capacity: listViewMetrics.Items.Count);
			foreach (ListViewItem item in listViewMetrics.Items)
			{
				string name = item.Text ?? string.Empty;
				string value = item.SubItems.Count > 1 ? item.SubItems[index: 1].Text ?? string.Empty : string.Empty;
				metricsList.Add(item: new Dictionary<string, string> { { "name", name }, { "value", value } });
			}

			// Export-Objekt mit Metadaten
			Dictionary<string, object?> export = new()
			{
				{ "file", string.IsNullOrEmpty(value: filePath) ? null : Path.GetFileName(path: filePath) },
				{ "filePath", string.IsNullOrEmpty(value: filePath) ? null : filePath },
				{ "n", n },
				{ "generatedAtUtc", DateTime.UtcNow.ToString(format: "o") },
				{ "metrics", metricsList }
			};

			// Serialisieren und speichern (UTF-8 mit BOM für Kompatibilität)
			string json = JsonSerializer.Serialize(value: export, options: SharedJsonOptions);

			try
			{
				File.WriteAllText(path: path, contents: json, encoding: new UTF8Encoding(encoderShouldEmitUTF8Identifier: true));
				MessageBox.Show(text: $"Metrics saved: {path}", caption: "Export completed", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show(text: ex.Message, caption: "Error saving", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Constructor

		public MainForm()
		{
			InitializeComponent();
		}

		#endregion

		#region Form Events

		private void MainForm_Load(object sender, EventArgs e)
		{
			groupBoxNgram.Enabled = false;
			groupBoxProgress.Enabled = false;
			groupBoxTokenFrequency.Enabled = false;
			groupBoxMetrics.Enabled = false;
			groupBoxModelText.Enabled = false;
		}

		#endregion

		#region Click Handlers

		private void ButtonSelectTextFile_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog(owner: this) == DialogResult.OK)
			{
				filePath = openFileDialog.FileName;
				textBoxTextFilePath.Text = filePath;
				fileContent = File.ReadAllText(path: filePath);
				fileLength = fileContent.Length;
				numericUpDownModelTextLength.Value = fileLength;
				groupBoxNgram.Enabled = true;
			}
		}

		private async void ButtonBuildTokenList_Click(object sender, EventArgs e)
		{
			// Vorbereitung UI
			groupBoxProgress.Enabled = true;
			groupBoxModelText.Enabled = false;
			groupBoxTokenFrequency.Enabled = false;
			groupBoxMetrics.Enabled = false;
			listViewToken.Items.Clear();
			listViewMetrics.Items.Clear();
			progressBar.Value = 0;
			labelProgressPercent.Text = "0 %";

			if (string.IsNullOrEmpty(value: fileContent))
			{
				MessageBox.Show(text: "No file loaded.", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
				return;
			}

			// Cancel vorheriger Aufgabe
			_cts?.Cancel();
			_cts = new CancellationTokenSource();

			Progress<int> progress = new(handler: p =>
			{
				int percent = Math.Clamp(value: p, min: 0, max: 100);
				progressBar.Value = percent;
				labelProgressPercent.Text = $"{percent} %";
			});

			int nLocal = (int)numericUpDownNGram.Value;

			try
			{
				// Zählarbeit in Hintergrund-Task
				Dictionary<string, int> result = await Task.Run(function: () => CountNgrams(text: fileContent.AsSpan(), n: nLocal, ct: _cts.Token, progress: progress), cancellationToken: _cts.Token);

				// Abbruch geprüft
				_cts.Token.ThrowIfCancellationRequested();

				ngramCounts = result;
				n = nLocal;
				groupBoxModelText.Enabled = true;
				groupBoxTokenFrequency.Enabled = true;
				groupBoxMetrics.Enabled = true;

				// Sortieren (optional) und asynchron in Batches hinzufügen
				KeyValuePair<string, int>[] tokens = [.. ngramCounts.OrderByDescending(keySelector: static kv => kv.Value)];
				await PopulateListViewTokenInBatches(tokens: tokens, batchSize: 500);

				// UI-Übersicht aktualisieren
				UpdateNgramProperties(dict: ngramCounts, n: n);

				// finalen Progress anzeigen
				progressBar.Value = 100;
				labelProgressPercent.Text = "100 %";
			}
			catch (OperationCanceledException)
			{
				// Abbruchbehandlung
				labelProgressPercent.Text = "Cancelled";
				progressBar.Value = 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show(text: ex.Message, caption: "Error", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
			}
			finally
			{
				_cts?.Dispose();
				_cts = null;
				groupBoxProgress.Enabled = false;
			}
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			// Button zum Abbruch
			if (_cts != null && !_cts.IsCancellationRequested)
			{
				_cts.Cancel();
				labelProgressPercent.Text = "Abort request...";
			}
		}

		private void ButtonGenerateModelText_Click(object sender, EventArgs e)
		{
			if (ngramCounts == null || n <= 0)
			{
				MessageBox.Show(text: "Please open a file first and calculate the N-grams.", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
				return;
			}
			string model = GenerateModelText(ngramCounts, n: n, length: (int)numericUpDownModelTextLength.Value);
			textBoxModelText.Text = model;
		}

		private void ButtonSaveTokenListAsCsv_Click(object sender, EventArgs e)
		{
			if (listViewToken.Items.Count == 0)
			{
				MessageBox.Show(text: "No tokens available for export.", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Warning);
				return;
			}
			SaveListViewTokenToCsv();
		}

		private void ButtonSaveModelText_Click(object sender, EventArgs e)
		{
			SaveModelTextToFile();
		}

		private void ButtonSaveMetricsAsJsonFile_Click(object sender, EventArgs e)
		{
			SaveMetricsToJson();
		}

		#endregion

		#region Misc Async Helpers

		private async Task PopulateListViewTokenInBatches(KeyValuePair<string, int>[] tokens, int batchSize = 500)
		{
			if (tokens == null || tokens.Length == 0)
			{
				return;
			}

			listViewToken.BeginUpdate();
			try
			{
				int total = tokens.Length;
				for (int i = 0; i < total; i += batchSize)
				{
					int take = Math.Min(val1: batchSize, val2: total - i);
					List<ListViewItem> items = new(capacity: take);
					for (int j = 0; j < take; j++)
					{
						KeyValuePair<string, int> kv = tokens[i + j];
						ListViewItem item = new(text: kv.Key);
						item.SubItems.Add(text: kv.Value.ToString());
						items.Add(item);
					}

					listViewToken.Items.AddRange(items: [.. items]);

					// Aktualisiere Fortschritt sichtbar, UI bleibt responsiv
					int progress = (int)Math.Clamp(value: (i + take) * 100L / total, min: 0, max: 100);
					progressBar.Value = progress;
					labelProgressPercent.Text = $"{progress} %";

					// Gib UI-Thread die Chance, Eingaben zu verarbeiten
					await Task.Yield();
				}
			}
			finally
			{
				listViewToken.EndUpdate();
			}
		}

		#endregion

		#region ListView Event Handlers

		// Event-Handler: liefert beim Bedarf das gewünschte ListViewItem
		private void ListViewToken_RetrieveVirtualItem(object? sender, RetrieveVirtualItemEventArgs e)
		{
			KeyValuePair<string, int> kv = tokenArray[e.ItemIndex];
			ListViewItem item = new(text: kv.Key);
			item.SubItems.Add(text: kv.Value.ToString());
			e.Item = item;
		}

		#endregion
	}
}