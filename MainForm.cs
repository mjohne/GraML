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
			item.SubItems.Add(text: numericUpDownNGram.Value.ToString());
			listViewProperties.Items.Add(value: item);
			item = new(text: "Total unique n-grams");
			item.SubItems.Add(text: dict.Count.ToString());
			listViewProperties.Items.Add(value: item);
			item = new(text: "Total n-grams");
			item.SubItems.Add(text: dict.Values.Sum().ToString());
			listViewProperties.Items.Add(value: item);
			item = new(text: "Most frequent n-gram");
			item.SubItems.Add(text: $"{dict.Aggregate((l, r) => l.Value > r.Value ? l : r).Key} ({dict.Aggregate((l, r) => l.Value > r.Value ? l : r).Value} occurrences)");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Least frequent n-gram");
			item.SubItems.Add(text: $"{dict.Aggregate((l, r) => l.Value < r.Value ? l : r).Key} ({dict.Aggregate((l, r) => l.Value < r.Value ? l : r).Value} occurrences)");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Average frequency of n-grams");
			item.SubItems.Add(text: $"{dict.Values.Average()}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Median frequency of n-grams");
			item.SubItems.Add(text: $"{dict.Values.OrderBy(v => v).ElementAt(index: dict.Values.Count / 2)}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Mode frequency of n-grams");
			item.SubItems.Add(text: $"{dict.Values.GroupBy(v => v).OrderByDescending(g => g.Count()).First().Key}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Standard deviation of n-gram frequencies");
			item.SubItems.Add(text: $"{Math.Sqrt(dict.Values.Average(v => Math.Pow(v - dict.Values.Average(), 2)))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Variance of n-gram frequencies");
			item.SubItems.Add(text: $"{dict.Values.Average(v => Math.Pow(v - dict.Values.Average(), 2))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Range of n-gram frequencies");
			item.SubItems.Add(text: $"{dict.Values.Max() - dict.Values.Min()}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Count of n-grams with frequency 1");
			item.SubItems.Add(text: $"{dict.Values.Count(v => v == 1)}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Count of n-grams with frequency greater than average");
			item.SubItems.Add(text: $"{dict.Values.Count(v => v > dict.Values.Average())}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Count of n-grams with frequency less than average");
			item.SubItems.Add(text: $"{dict.Values.Count(v => v < dict.Values.Average())}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Top 5 most frequent n-grams");
			item.SubItems.Add(text: $"{string.Join(", ", dict.OrderByDescending(kv => kv.Value).Take(5).Select(kv => $"{kv.Key} ({kv.Value})"))}");
			listViewProperties.Items.Add(value: item);
			item = new(text: "Top 5 least frequent n-grams");
			item.SubItems.Add(text: $"{string.Join(", ", dict.OrderBy(kv => kv.Value).Take(5).Select(kv => $"{kv.Key} ({kv.Value})"))}");
			listViewProperties.Items.Add(value: item);
			/*
			MessageBox.Show(text: $"Frequency distribution of {n}-grams: {string.Join(", ", dict.GroupBy(kv => kv.Value).OrderBy(g => g.Key).Select(g => $"{g.Key}: {g.Count()}"))}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Entropy of {n}-gram distribution: {-dict.Values.Select(v => (double)v / dict.Values.Sum()).Where(p => p > 0).Sum(p => p * Math.Log2(p))}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Gini coefficient of {n}-gram distribution: {1 - dict.Values.Select(v => (double)v / dict.Values.Sum()).Sum(p => p * p)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Herfindahl-Hirschman Index of {n}-gram distribution: {dict.Values.Select(v => Math.Pow((double)v / dict.Values.Sum(), 2)).Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Simpson's Diversity Index of {n}-gram distribution: {1 - dict.Values.Select(v => Math.Pow((double)v / dict.Values.Sum(), 2)).Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Shannon-Wiener Index of {n}-gram distribution: {-dict.Values.Select(v => (double)v / dict.Values.Sum()).Where(p => p > 0).Sum(p => p * Math.Log(p))}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Pielou's Evenness of {n}-gram distribution: {-dict.Values.Select(v => (double)v / dict.Values.Sum()).Where(p => p > 0).Sum(p => p * Math.Log(p)) / Math.Log(dict.Count)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"McIntosh's Index of {n}-gram distribution: {Math.Sqrt(dict.Values.Select(v => v * v).Sum()) / dict.Values.Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Brillouin's Index of {n}-gram distribution: {Math.Log(Factorial(dict.Values.Sum())) - (dict.Values.Select(v => Math.Log(Factorial(v))).Sum() / dict.Values.Sum())}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Menhinick's Index of {n}-gram distribution: {dict.Count / Math.Sqrt(dict.Values.Sum())}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Margalef's Index of {n}-gram distribution: {(dict.Count - 1) / Math.Log(dict.Values.Sum())}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Berger-Parker Index of {n}-gram distribution: {(double)dict.Values.Max() / dict.Values.Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Simpson's Reciprocal Index of {n}-gram distribution: {1 / dict.Values.Select(v => Math.Pow((double)v / dict.Values.Sum(), 2)).Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Evar of {n}-gram distribution: {1 - (2 / Math.PI * Math.Acos(dict.Values.Select(v => (double)v / dict.Values.Sum()).Sum()))}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Hill's Numbers of order 0, 1, and 2 for {n}-gram distribution: {dict.Count}, {Math.Exp(-dict.Values.Select(v => (double)v / dict.Values.Sum()).Where(p => p > 0).Sum(p => p * Math.Log(p)))}, {1 / dict.Values.Select(v => Math.Pow((double)v / dict.Values.Sum(), 2)).Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Renyi's Entropy of order 2 for {n}-gram distribution: {1 / (1 - 2) * Math.Log(dict.Values.Select(v => Math.Pow((double)v / dict.Values.Sum(), 2)).Sum())}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Tsallis Entropy of order 2 for {n}-gram distribution: {1 - dict.Values.Select(v => Math.Pow((double)v / dict.Values.Sum(), 2)).Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Kullback-Leibler Divergence from uniform distribution for {n}-gram distribution: {dict.Values.Select(v => (double)v / dict.Values.Sum()).Where(p => p > 0).Sum(p => p * Math.Log(p * dict.Count))}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Jensen-Shannon Divergence from uniform distribution for {n}-gram distribution: {(0.5 * dict.Values.Select(v => (double)v / dict.Values.Sum()).Where(p => p > 0).Sum(p => p * Math.Log(2 * p))) + (0.5 * (1.0 / dict.Count) * dict.Count * Math.Log(2 / dict.Count))}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Total number of {n}-grams processed: {dict.Values.Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Number of unique {n}-grams: {dict.Count}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Proportion of unique {n}-grams: {(double)dict.Count / dict.Values.Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Average length of {n}-grams: {dict.Keys.Average(k => k.Length)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Longest {n}-gram: {dict.Keys.OrderByDescending(k => k.Length).First()} (Length: {dict.Keys.OrderByDescending(k => k.Length).First().Length})", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Shortest {n}-gram: {dict.Keys.OrderBy(k => k.Length).First()} (Length: {dict.Keys.OrderBy(k => k.Length).First().Length})", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Lexical Diversity (Type-Token Ratio) of {n}-gram distribution: {(double)dict.Count / dict.Values.Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Hapax Legomena (n-grams occurring once) count for {n}-gram distribution: {dict.Values.Count(v => v == 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Dis Legomena (n-grams occurring twice) count for {n}-gram distribution: {dict.Values.Count(v => v == 2)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Ratio of Hapax Legomena to total {n}-grams: {(double)dict.Values.Count(v => v == 1) / dict.Values.Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Ratio of Dis Legomena to total {n}-grams: {(double)dict.Values.Count(v => v == 2) / dict.Values.Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Yule's K Measure for {n}-gram distribution: {10000 * (dict.Values.Select(v => v * v).Sum() - dict.Values.Sum()) / (dict.Values.Sum() * dict.Values.Sum())}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Simpson's Index of Diversity for {n}-gram distribution: {1 - dict.Values.Select(v => Math.Pow((double)v / dict.Values.Sum(), 2)).Sum()}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Ego's C Measure for {n}-gram distribution: {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Bray-Curtis Dissimilarity for {n}-gram distribution: {1 - (2.0 * dict.Values.Max() / dict.Values.Sum())}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Cohen's Kappa for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Krippendorff's Alpha for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Fleiss' Kappa for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Gwet's AC1 for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Scott's Pi for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Krippendorff's Alpha for {n}-gram distribution (assuming uniform distribution): {(dict.Values.Sum() - dict.Values.Max()) / (dict.Values.Sum() - 1)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			MessageBox.Show(text: $"Normalized Entropy of {n}-gram distribution: {-dict.Values.Select(v => (double)v / dict.Values.Sum()).Where(p => p > 0).Sum(p => p * Math.Log2(p)) / Math.Log2(dict.Count)}", caption: "N-gram Count", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
			*/

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