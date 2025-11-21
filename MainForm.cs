using System.ComponentModel;
using System.Text;

namespace GraML
{
	public partial class MainForm : Form
	{
		// Sequenzielle Variante (bestehend) — belassen, falls du sie weiterhin brauchst.
		private static Dictionary<string, int> CountNgrams(ReadOnlySpan<char> text, int n, ProgressBar progressBar, BackgroundWorker backgroundWorker, Label labelProgress)
		{
			if (n <= 0 || text.Length < n)
			{
				return new Dictionary<string, int>(capacity: 0, comparer: StringComparer.Ordinal);
			}

			int possible = text.Length - n + 1;
			Dictionary<string, int> dict = new(capacity: Math.Max(val1: 4, val2: possible), comparer: StringComparer.Ordinal);

			// Keine direkten UI-Änderungen hier (laufen im UI-Thread). Nur Progress melden.
			for (int i = 0; i < possible; i++)
			{
				// Abbruchprüfung im heißen Loop
				if (backgroundWorker?.CancellationPending == true)
				{
					// frühzeitig abbrechen und aktuellen Zwischenstand zurückgeben
					return dict;
				}

				string token = new(value: text.Slice(start: i, length: n));
				dict[key: token] = dict.TryGetValue(key: token, value: out int cnt) ? cnt + 1 : 1;

				// Progress melden (wird im UI-Thread in ProgressChanged verarbeitet)
				if (backgroundWorker != null && backgroundWorker.WorkerReportsProgress)
				{
					int percent = (int)((i + 1) * 100L / possible);
					backgroundWorker.ReportProgress(percentProgress: percent);
				}
			}

			return dict;
		}

		// Kümmert sich ausschließlich um die UI-Anzeige der berechneten Kennzahlen
		private void UpdateNgramProperties(Dictionary<string, int> dict, int n)
		{
			if (dict == null || dict.Count == 0)
			{
				AddProperty(name: "n-gram size", value: $"{n}");
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

			AddProperty(name: "n-gram size", value: $"{n}");
			AddProperty(name: "Total unique n-grams", value: $"{unique}");
			AddProperty(name: "Total n-grams", value: $"{total}");
			AddProperty(name: "Proportion of unique n-grams", value: $"{unique / (double)total:F4}");
			AddProperty(name: "Most frequent n-gram", value: $"{most.Key} ({most.Value} occurrences)");
			AddProperty(name: "Least frequent n-gram", value: $"{least.Key} ({least.Value} occurrences)");
			AddProperty(name: "Average frequency of n-grams", value: $"{average:F4}");
			AddProperty(name: "Median frequency of n-grams", value: $"{median:F4}");
			AddProperty(name: "Mode frequency of n-grams", value: $"{dict.Values.GroupBy(keySelector: v => v).OrderByDescending(keySelector: g => g.Count()).First().Key}");
			AddProperty(name: "Standard deviation of n-gram frequencies", value: $"{Math.Sqrt(d: dict.Values.Average(selector: v => Math.Pow(x: v - average, y: 2))):F4}");
			AddProperty(name: "Variance of n-gram frequencies", value: $"{dict.Values.Average(selector: v => Math.Pow(x: v - average, y: 2)):F4}");
			AddProperty(name: "Range of n-gram frequencies", value: $"{dict.Values.Max() - dict.Values.Min()}");
			AddProperty(name: "Count of n-grams with frequency 1", value: $"{dict.Values.Count(predicate: v => v == 1)}");
			AddProperty(name: "Count of n-grams with frequency greater than average", value: $"{dict.Values.Count(predicate: v => v > average)}");
			AddProperty(name: "Count of n-grams with frequency less than average", value: $"{dict.Values.Count(predicate: v => v < average)}");
			AddProperty(name: "Top 5 most frequent n-grams", value: string.Join(separator: ", ", values: dict.OrderByDescending(keySelector: kv => kv.Value).Take(count: 5).Select(selector: kv => $"{kv.Key} ({kv.Value})")));
			AddProperty(name: "Top 5 least frequent n-grams", value: string.Join(separator: ", ", values: dict.OrderBy(keySelector: kv => kv.Value).Take(count: 5).Select(selector: kv => $"{kv.Key} ({kv.Value})")));
			AddProperty(name: "Frequency distribution of n-grams", value: string.Join(separator: ", ", values: dict.GroupBy(keySelector: kv => kv.Value).OrderBy(keySelector: g => g.Key).Select(selector: g => $"{g.Key}: {g.Count()}")));
			AddProperty(name: "Entropy of n-gram distribution", value: $"{entropy:F4}");
			AddProperty(name: "Gini coefficient of n-gram distribution", value: $"{gini:F4}");
			AddProperty(name: "Average length of n-grams", value: $"{dict.Keys.Average(selector: k => k.Length):F2}");
			AddProperty(name: "Hapax Legomena (occurring once)", value: $"{dict.Values.Count(predicate: v => v == 1)}");
			AddProperty(name: "Dis Legomena (occurring twice)", value: $"{dict.Values.Count(predicate: v => v == 2)}");
			AddProperty(name: "Ratio of Hapax Legomena to total", value: $"{dict.Values.Count(predicate: v => v == 1) / (double)total:F4}");
			AddProperty(name: "Yule's K Measure", value: $"{10000 * (dict.Values.Sum(selector: v => v * v) - dict.Values.Sum()) / (double)(total * total):F4}");
			AddProperty(name: "Normalized Entropy", value: $"{entropy / Math.Log2(x: dict.Count):F4}");
		}

		private void AddProperty(string name, string value)
		{
			ListViewItem item = new(text: name);
			item.SubItems.Add(text: value);
			listViewProperties.Items.Add(value: item);
		}

		private Dictionary<string, int>? ngramCounts;
		private int n;

		public MainForm()
		{
			InitializeComponent();
		}

		private void ButtonSelectTextFile_Click(object sender, EventArgs e)
		{
			openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (openFileDialog.ShowDialog(owner: this) == DialogResult.OK)
			{
				string filePath = openFileDialog.FileName;
				string fileContent = File.ReadAllText(path: filePath);
				int n = (int)numericUpDownNGram.Value;
				listViewNgram.Items.Clear();
				listViewProperties.Items.Clear();
				progressBar.Value = 0;
				labelProgressPercent.Text = "0 %";

				// Dateiinhalt und n als Argument an den BackgroundWorker übergeben
				backgroundWorker.RunWorkerAsync(argument: (fileContent, n));
			}
		}

		private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			// Nur Hintergrundarbeit: Parsen der Argumente und Zähl-Logik ausführen
			if (e.Argument is not ValueTuple<string, int> args)
			{
				e.Result = null;
				return;
			}

			(string fileContent, int n) = args;
			ReadOnlySpan<char> textSpan = fileContent.AsSpan();

			using BackgroundWorker? worker = sender as BackgroundWorker;

			// CPU-intensive Arbeit im Hintergrund (CountNgrams prüft CancellationPending)
			Dictionary<string, int> ngramCounts = CountNgrams(
				text: textSpan,
				n: n,
				progressBar: progressBar,
				backgroundWorker: worker!,
				labelProgress: labelProgressPercent);

			// Wenn während der Arbeit Abbruch angefordert wurde, markieren wir das Ergebnis als abgebrochen
			if (worker?.CancellationPending == true)
			{
				e.Cancel = true;
				e.Result = null;
				return;
			}

			// Ergebnis an den UI-Thread zurückgeben
			e.Result = (ngramCounts, n);
		}

		private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// ProgressChanged läuft auf dem UI-Thread — sichere UI-Aktualisierung
			int percent = Math.Clamp(value: e.ProgressPercentage, min: 0, max: 100);
			progressBar.Value = percent;
			labelProgressPercent.Text = $"{percent} %";
		}

		private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// Fehlerbehandlung
			if (e.Error != null)
			{
				MessageBox.Show(text: e.Error.Message, caption: "Fehler", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
				return;
			}

			if (e.Cancelled)
			{
				// Abbruch: Rücksetzen UI / Info
				labelProgressPercent.Text = "Cancelled";
				progressBar.Value = 0;
				return;
			}

			if (e.Result is not ValueTuple<Dictionary<string, int>, int> result || result.Item1 == null)
			{
				return;
			}

			ngramCounts = result.Item1;
			n = result.Item2;

			// UI-Updates auf dem UI-Thread
			listViewNgram.Items.Clear();
			foreach (KeyValuePair<string, int> kv in ngramCounts)
			{
				ListViewItem item = new(text: kv.Key);
				item.SubItems.Add(text: $"{kv.Value}");
				listViewNgram.Items.Add(value: item);
			}

			// UI-Übersicht aktualisieren
			UpdateNgramProperties(dict: ngramCounts, n: n);

			// finalen Progress anzeigen
			progressBar.Value = 100;
			labelProgressPercent.Text = "100 %";
		}

		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			// Button zum Abbruch (Button in Designer an diesen Handler binden)
			if (backgroundWorker.IsBusy && backgroundWorker.WorkerSupportsCancellation)
			{
				backgroundWorker.CancelAsync();
				labelProgressPercent.Text = "Abort request...";
			}
		}

		private void ButtonCreateModelText_Click(object sender, EventArgs e)
		{
			if (ngramCounts == null || n <= 0)
			{
				MessageBox.Show(text: "Please open a file first and calculate the N-grams.", caption: "Warning", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
				return;
			}
			string model = GenerateModelText(ngramCounts, n: n, length: (int)numericUpDownModelTextLength.Value);
			textBoxModelText.Text = model;
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
					sb.Append(value: curPrefix); // kann len erhöhen; prüfe dann beim nächsten Loop
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
	}
}