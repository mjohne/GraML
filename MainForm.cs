
namespace GraML
{
	public partial class MainForm : Form
	{
		private static Dictionary<string, int> CountNgrams(List<string> words, int n)
		{
			var dict = new Dictionary<string, int>();
			for (int i = 0; i <= words.Count - n; i++)
			{
				string token = string.Join(separator: "", values: words.Skip(count: i).Take(count: n));
				dict[key: token] = dict.TryGetValue(key: token, value: out int value) ? ++value : 1;
			}
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
				listView.Items.Clear();
				foreach (KeyValuePair<string, int> keyValuePair in ngramCounts)
				{
					var item = new ListViewItem(text: keyValuePair.Key);
					item.SubItems.Add(text: keyValuePair.Value.ToString());
					listView.Items.Add(value: item);
				}
			}
		}
	}
}