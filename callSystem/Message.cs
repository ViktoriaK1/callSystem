using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace callSystem
{
    public partial class Message : Form
    {
        public Message()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm m = new MainForm();
            m.Show();
        }
       
        private void Message_Load(object sender, EventArgs e)
        {
            {
                string queryString1 = "select email from clients where email != ''";
                using (SqlConnection connection =
                   new SqlConnection(@"Data Source=DESKTOP-R37G8GU\SQLEXPRESS;Initial Catalog=inf_system;Integrated Security=True"))
                {
                    SqlCommand cmd1 = new SqlCommand(queryString1, connection);
                    DataTable tbl1 = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd1);
                    da.Fill(tbl1);
                        this.comboBox1.DataSource = tbl1;
                        this.comboBox1.DisplayMember = "email";// столбец для отображения
                        this.comboBox1.ValueMember = "email";//столбец с id
                        this.comboBox1.SelectedIndex = -1;
                   
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                MessageBox.Show("Отправлено");
                textBox2.Text = "";
                comboBox1.Text = "";
            }
            else

                MessageBox.Show("Не выбран отправитель");
        }
    }
}
