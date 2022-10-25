using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace CV3_1
{
    public partial class Form1 : Form
    {
        float total;
        float dan;
        float result;

        public Form1()
        {
            InitializeComponent();
            countMePlease();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            countMePlease();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            countMePlease();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }


        private void countMePlease()
        {
            bool isConvertable = true;
            float resultsum;
            try
            {
                total = float.Parse(textBox1.Text);
                dan = float.Parse(textBox2.Text);
            } catch (Exception myEx)
            {
                isConvertable = false;
            }
            

            if (isConvertable)
            {
                result = total / 100 * dan;
                resultsum = total - result;
                danlabel.Text = String.Format("Zaplatite sazbu: {0}", result);
                resultlabel.Text = String.Format("Zaplatite hodnotu: {0}", resultsum);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}