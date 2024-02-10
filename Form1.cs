using System.Windows.Forms;

namespace CommandCSharpApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.Text = System.Environment.MachineName;
            textBox3.Text = "Models";
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        //Button Generate
        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = generate_scrafoldding();
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        //Button Copy 
        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label6.Text);
        }

        private string generate_scrafoldding()
        {
            string servername = textBox1.Text;
            string dbName = textBox2.Text;
            string outputDir = textBox3.Text;
            string ext = "";
            if (textBox4.Text != "")
            {
                ext += $" -t {textBox4.Text} -f";
            }
            if (textBox5.Text != "")
            {
                ext += $" -c {textBox5.Text} -f";
            }

            string commandS = "Scaffold-DbContext " + $"Server={servername};Database={dbName};Trusted_Connection=True;" + $"Microsoft.EntityFrameworkCore.SqlServer -OutputDir {outputDir} {ext}";

            return commandS;
        }
    }
}