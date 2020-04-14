using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace pract_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
		}

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
			OpenFileDialog openFile = new OpenFileDialog();
			openFile.Filter = "txt files|*.txt";
			if (openFile.ShowDialog() == DialogResult.OK)
				richTextBox1.Text = File.ReadAllText(openFile.FileName);
		}

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
			SaveFileDialog saveFile = new SaveFileDialog();
			saveFile.DefaultExt = "*.txt";
			saveFile.Filter = "txt files|*.txt";
			if (saveFile.ShowDialog() == DialogResult.OK && saveFile.FileName.Length > 0)
			{
				using (StreamWriter sw = new StreamWriter(saveFile.FileName, true))
				{
					sw.WriteLine(richTextBox1.Text);
					sw.Close();
				}
			}
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Application.Exit();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (richTextBox1.SelectionLength > 0)
				Clipboard.SetText(richTextBox1.Text, TextDataFormat.UnicodeText);
		}

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
			if (Clipboard.ContainsText())
				richTextBox1.Text += Clipboard.GetText();
		}

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
			richTextBox1.Text = "";
        }

		private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (richTextBox1.SelectionLength > 0)
				Clipboard.SetText(richTextBox1.Text, TextDataFormat.UnicodeText);
			richTextBox1.SelectedText = "";
		}
	}
}
