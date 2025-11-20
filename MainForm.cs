namespace GraML
{
	public partial class MainForm : Form
	{
		// Zählt nur N-Gramme (keine UI-Updates)
		private static Dictionary<string, int> CountNgrams(List<string> words, int n)
		{
			Dictionary<string, int> dict = [];
			for (int i = 0; i <= words.Count - n; i++)
			{
				string token = string.Concat(values: words.Skip(count: i).Take(count: n));
				dict[key: token] = dict.TryGetValue(key: token, value: out int existing) ? existing + 1 : 1;
			}
			return dict;
		}

		// Kümmert sich ausschließlich um die UI-Anzeige der berechneten Kennzahlen
		private void UpdateNgramProperties(Dictionary<string, int> dict, int n)
		{
			listViewProperties.Items.Clear();
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

			double[] probs = [.. dict.Values.Select(v => (double)v / total)];
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
			AddProperty(name: "Longest n-gram", value: $"{dict.Keys.OrderByDescending(keySelector: k => k.Length).First()} (Length: {dict.Keys.Max(selector: k => k.Length)})");
			AddProperty(name: "Shortest n-gram", value: $"{dict.Keys.OrderBy(keySelector: k => k.Length).First()} (Length: {dict.Keys.Min(selector: k => k.Length)})");
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

		public MainForm()
		{
			InitializeComponent();
		}

		private void ButtonOpenTextFile_Click(object sender, EventArgs e)
		{
			openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (openFileDialog.ShowDialog(owner: this) == DialogResult.OK)
			{
				string filePath = openFileDialog.FileName;
				string fileContent = File.ReadAllText(path: filePath);
				List<string> words = [.. fileContent.Select(selector: static c => c.ToString())];

				int n = (int)numericUpDownNGram.Value;
				Dictionary<string, int> ngramCounts = CountNgrams(words: words, n: n);
				listViewNgram.Items.Clear();
				foreach (KeyValuePair<string, int> kv in ngramCounts)
				{
					ListViewItem item = new(text: kv.Key);
					item.SubItems.Add(text: $"{kv.Value}");
					listViewNgram.Items.Add(value: item);
				}

				// UI-Update getrennt von der Zähl-Logik
				UpdateNgramProperties(dict: ngramCounts, n: n);
			}
		}
	}
}