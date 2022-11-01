using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace CV4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|csv files (*.csv)|*.csv|xml files (*.xml)|*.xml|config files (*.ini)|*.ini";
            openFileDialog1.ShowDialog();
            filePath = openFileDialog1.FileName;
            MessageBox.Show(filePath, "Otevreny soubor", MessageBoxButtons.OK);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|csv files (*.csv)|*.csv|xml files (*.xml)|*.xml|config files (*.ini)|*.ini";
            saveFileDialog1.ShowDialog();
            filePath = saveFileDialog1.FileName;
            // MessageBox.Show("Ulozeny soubor je na adrese: {0}", filePath);
            MessageBox.Show(filePath, "Ulozeny soubor", MessageBoxButtons.OK);

        }
    }
}