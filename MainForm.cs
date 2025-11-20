namespace GraML
{
	public partial class MainForm : Form
	{
		private Dictionary<string, int> CountNgrams(List<string> words, int n)
		{
			var dict = new Dictionary<string, int>();
			for (int i = 0; i <= words.Count - n; i++)
			{
				string token = string.Join(separator: "", values: words.Skip(count: i).Take(count: n));
				dict[key: token] = dict.TryGetValue(key: token, value: out int value) ? ++value : 1;
			}

			listViewProperties.Items.Clear();
			ListViewItem item = new(text: "n-gram size");
			item.SubItems.Add(text: $"{numericUpDownNGram.Value}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Total unique n-grams");
			item.SubItems.Add(text: $"{dict.Count}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Total n-grams");
			item.SubItems.Add(text: $"{dict.Values.Sum()}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Proportion of unique n-grams");
			//item = new(text: "Lexical Diversity (Type-Token Ratio) of n-gram distribution");
			item.SubItems.Add(text: $"{(double)dict.Count / dict.Values.Sum()}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Most frequent n-gram");
			item.SubItems.Add(text: $"{dict.Aggregate(func: (l, r) => l.Value > r.Value ? l : r).Key} ({dict.Aggregate(func: (l, r) => l.Value > r.Value ? l : r).Value} occurrences)");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Least frequent n-gram");
			item.SubItems.Add(text: $"{dict.Aggregate(func: (l, r) => l.Value < r.Value ? l : r).Key} ({dict.Aggregate(func: (l, r) => l.Value < r.Value ? l : r).Value} occurrences)");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Average frequency of n-grams");
			item.SubItems.Add(text: $"{dict.Values.Average()}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Median frequency of n-grams");
			item.SubItems.Add(text: $"{dict.Values.OrderBy(keySelector: v => v).ElementAt(index: dict.Values.Count / 2)}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Mode frequency of n-grams");
			item.SubItems.Add(text: $"{dict.Values.GroupBy(keySelector: v => v).OrderByDescending(keySelector: g => g.Count()).First().Key}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Standard deviation of n-gram frequencies");
			item.SubItems.Add(text: $"{Math.Sqrt(d: dict.Values.Average(selector: v => Math.Pow(x: v - dict.Values.Average(), y: 2)))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Variance of n-gram frequencies");
			item.SubItems.Add(text: $"{dict.Values.Average(selector: v => Math.Pow(x: v - dict.Values.Average(), y: 2))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Range of n-gram frequencies");
			item.SubItems.Add(text: $"{dict.Values.Max() - dict.Values.Min()}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Count of n-grams with frequency 1");
			item.SubItems.Add(text: $"{dict.Values.Count(predicate: v => v == 1)}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Count of n-grams with frequency greater than average");
			item.SubItems.Add(text: $"{dict.Values.Count(predicate: v => v > dict.Values.Average())}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Count of n-grams with frequency less than average");
			item.SubItems.Add(text: $"{dict.Values.Count(predicate: v => v < dict.Values.Average())}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Top 5 most frequent n-grams");
			item.SubItems.Add(text: $"{string.Join(separator: ", ", values: dict.OrderByDescending(keySelector: kv => kv.Value).Take(count: 5).Select(selector: kv => $"{kv.Key} ({kv.Value})"))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Top 5 least frequent n-grams");
			item.SubItems.Add(text: $"{string.Join(separator: ", ", values: dict.OrderBy(keySelector: kv => kv.Value).Take(count: 5).Select(selector: kv => $"{kv.Key} ({kv.Value})"))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Frequency distribution of n-grams");
			item.SubItems.Add(text: $"{string.Join(separator: ", ", values: dict.GroupBy(keySelector: kv => kv.Value).OrderBy(keySelector: g => g.Key).Select(selector: g => $"{g.Key}: {g.Count()}"))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Entropy of n-gram distribution");
			item.SubItems.Add(text: $"{-dict.Values.Select(selector: v => (double)v / dict.Values.Sum()).Where(predicate: p => p > 0).Sum(selector: p => p * Math.Log2(x: p))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Gini coefficient of n-gram distribution");
			item.SubItems.Add(text: $"{1 - dict.Values.Select(selector: v => (double)v / dict.Values.Sum()).Sum(selector: p => p * p)}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Herfindahl-Hirschman Index of n-gram distribution");
			item.SubItems.Add(text: $"{dict.Values.Sum(selector: v => Math.Pow(x: (double)v / dict.Values.Sum(), y: 2))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Simpson's Diversity Index of n-gram distribution");
			item.SubItems.Add(text: $"{1 - dict.Values.Select(selector: v => Math.Pow(x: (double)v / dict.Values.Sum(), y: 2)).Sum()}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Shannon-Wiener Index of n-gram distribution");
			item.SubItems.Add(text: $"{-dict.Values.Select(selector: v => (double)v / dict.Values.Sum()).Where(predicate: p => p > 0).Sum(selector: p => p * Math.Log(d: p))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Pielou's Evenness of n-gram distribution");
			item.SubItems.Add(text: $"{-dict.Values.Select(selector: v => (double)v / dict.Values.Sum()).Where(predicate: p => p > 0).Sum(selector: p => p * Math.Log(d: p)) / Math.Log(d: dict.Count)}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "McIntosh's Index of n-gram distribution");
			item.SubItems.Add(text: $"{Math.Sqrt(d: dict.Values.Sum(selector: v => v * v)) / dict.Values.Sum()}");
			listViewProperties.Items.Add(value: item);
			/*item = new(text: "Brillouin's Index of n-gram distribution");
			item.SubItems.Add(text: $"{Math.Log(Factorial(dict.Values.Sum())) - (dict.Values.Select(v => Math.Log(Factorial(v))).Sum() / dict.Values.Sum())}");
			listViewProperties.Items.Add(value: item);*/
			item = new(text: "Menhinick's Index of n-gram distribution");
			item.SubItems.Add(text: $"{dict.Count / Math.Sqrt(d: dict.Values.Sum())}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Margalef's Index of n-gram distribution");
			item.SubItems.Add(text: $"{(dict.Count - 1) / Math.Log(d: dict.Values.Sum())}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Berger-Parker Index of {n}-gram distribution");
			item.SubItems.Add(text: $"{(double)dict.Values.Max() / dict.Values.Sum()}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Simpson's Reciprocal Index of n-gram distribution");
			item.SubItems.Add(text: $"{1 / dict.Values.Sum(selector: v => Math.Pow(x: (double)v / dict.Values.Sum(), y: 2))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Evar of n-gram distribution");
			item.SubItems.Add(text: $"{1 - (2 / Math.PI * Math.Acos(d: dict.Values.Sum(selector: v => (double)v / dict.Values.Sum())))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Hill's Numbers of order 0, 1, and 2 for n-gram distribution");
			item.SubItems.Add(text: $"{dict.Count}, {Math.Exp(d: -dict.Values.Select(selector: v => (double)v / dict.Values.Sum()).Where(predicate: p => p > 0).Sum(selector: p => p * Math.Log(d: p)))}, {1 / dict.Values.Sum(selector: v => Math.Pow(x: (double)v / dict.Values.Sum(), y: 2))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Renyi's Entropy of order 2 for n-gram distribution");
			item.SubItems.Add(text: $"{1 / (1 - 2) * Math.Log(d: dict.Values.Sum(selector: v => Math.Pow(x: (double)v / dict.Values.Sum(), y: 2)))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Tsallis Entropy of order 2 for n-gram distribution");
			item.SubItems.Add(text: $"{1 - dict.Values.Sum(selector: v => Math.Pow(x: (double)v / dict.Values.Sum(), y: 2))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Kullback-Leibler Divergence from uniform distribution for n-gram distribution");
			item.SubItems.Add(text: $"{dict.Values.Select(selector: v => (double)v / dict.Values.Sum()).Where(predicate: p => p > 0).Sum(selector: p => p * Math.Log(d: p * dict.Count))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Jensen-Shannon Divergence from uniform distribution for n-gram distribution");
			item.SubItems.Add(text: $"{(0.5 * dict.Values.Select(selector: v => (double)v / dict.Values.Sum()).Where(predicate: p => p > 0).Sum(selector: p => Math.Log(d: 2 * p))) + (0.5 * (1.0 / dict.Count) * dict.Count * Math.Log(d: 2 / dict.Count))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Average length of n-grams");
			item.SubItems.Add(text: $"{dict.Keys.Average(selector: k => k.Length)}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Longest n-gram");
			item.SubItems.Add(text: $"{dict.Keys.OrderByDescending(keySelector: k => k.Length).First()} (Length: {dict.Keys.OrderByDescending(keySelector: k => k.Length).First().Length})");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Shortest n-gram");
			item.SubItems.Add(text: $"{dict.Keys.OrderBy(keySelector: k => k.Length).First()} (Length: {dict.Keys.OrderBy(keySelector: k => k.Length).First().Length})");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Hapax Legomena (n-grams occurring once) count for n-gram distribution");
			item.SubItems.Add(text: $"{dict.Values.Count(predicate: v => v == 1)}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Dis Legomena (n-grams occurring twice) count for n-gram distribution");
			item.SubItems.Add(text: $"{dict.Values.Count(predicate: v => v == 2)}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Ratio of Hapax Legomena to total n-grams");
			item.SubItems.Add(text: $"{(double)dict.Values.Count(predicate: v => v == 1) / dict.Values.Sum()}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Ratio of Dis Legomena to total n-grams");
			item.SubItems.Add(text: $"{(double)dict.Values.Count(predicate: v => v == 2) / dict.Values.Sum()}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Yule's K Measure for n-gram distribution");
			item.SubItems.Add(text: $"{10000 * (dict.Values.Sum(selector: v => v * v) - dict.Values.Sum()) / (dict.Values.Sum() * dict.Values.Sum())}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Simpson's Index of Diversity for n-gram distribution");
			item.SubItems.Add(text: $"{1 - dict.Values.Sum(selector: v => Math.Pow(x: (double)v / dict.Values.Sum(), y: 2))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Ego's C Measure for n-gram distribution");
			item.SubItems.Add(text: $"{(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Bray-Curtis Dissimilarity for n-gram distribution");
			item.SubItems.Add(text: $"{1 - (2.0 * dict.Values.Max() / dict.Values.Sum())}");
			listViewProperties.Items.Add(value: item);
			/*
			MessageBox.Show(text: $"Cohen's Kappa for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Krippendorff's Alpha for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Fleiss' Kappa for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Gwet's AC1 for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Scott's Pi for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Krippendorff's Alpha for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"{-dict.Values.Select(v => (double)v / dict.Values.Sum()).Where(p => p > 0).Sum(p => p * Math.Log2(p)) / Math.Log2(dict.Count)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			*/
			item = new(text: "Normalized Entropy of n-gram distribution");
			item.SubItems.Add(text: $"{-dict.Values.Select(selector: v => (double)v / dict.Values.Sum()).Where(predicate: p => p > 0).Sum(selector: p => p * Math.Log2(x: p)) / Math.Log2(x: dict.Count)}");
			listViewProperties.Items.Add(value: item);
			return dict;
		}

		public MainForm()
		{
			InitializeComponent();
		}

		private void ButtonOpenTextFile_Click(object sender, EventArgs e)
		{
			openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string filePath = openFileDialog.FileName;
				string fileContent = File.ReadAllText(path: filePath);
				//textBoxFileContent.Text = fileContent;
				List<string> words = [.. fileContent.Select(selector: static c => c.ToString())];
				var ngramCounts = CountNgrams(words, n: (int)numericUpDownNGram.Value);
				listViewNgram.Items.Clear();
				foreach (KeyValuePair<string, int> keyValuePair in ngramCounts)
				{
					var item = new ListViewItem(text: keyValuePair.Key);
					item.SubItems.Add(text: keyValuePair.Value.ToString());
					listViewNgram.Items.Add(value: item);
				}
			}
		}
	}
}