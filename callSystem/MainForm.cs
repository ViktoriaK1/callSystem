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
    public partial class MainForm : Form
    {
        Database database = new Database();
        public MainForm()
        {
            InitializeComponent();
            CreateColumns();


        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_client", "ID клиента");
            dataGridView1.Columns.Add("name_client", "ФИО");
            dataGridView1.Columns.Add("problem", "проблема");
            dataGridView1.Columns.Add("phone_number", "номер телефона");
            dataGridView1.Columns.Add("email", "e-mail");
            dataGridView1.Columns.Add("connection", "способ связи");
        }
        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3),
              record.GetString(4), record.GetString(5));
        }

        private void RefreshDataGrid(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string query = $"select * from clients";

            SqlCommand command = new SqlCommand(query, database.GetConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgv, reader);
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Phone p = new Phone();
            p.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Message p = new Message();
            p.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var name = textBox1.Text;
            var problem = textBox2.Text;
            var phone = textBox3.Text;
            var email = textBox4.Text;
            var connect = textBox5.Text;

            if (name != "" && problem != "" && connect != "")
            {
                var addQuery = $"insert into clients (name_client, problem, phone_number, email, connection) values (N'{name}', N'{problem}', N'{phone}', N'{email}', N'{connect}')";

                var command = new SqlCommand(addQuery, database.GetConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись добавлена!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            database.closeConnection();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-R37G8GU\SQLEXPRESS;Initial Catalog=inf_system;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand("DELETE FROM clients WHERE id_client=@id_client", con);
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                com.Parameters.AddWithValue("@id_client", id);
                con.Open(); //Открываем подключение
                try
                {
                    com.ExecuteNonQuery();
                    MessageBox.Show("Запись удалена");
                }
                catch
                {
                    MessageBox.Show("Удалить не удалось!");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            database.openConnection();

                var name = textBox1.Text;
                var problem = textBox2.Text;
                var phone = textBox3.Text;
                var email = textBox4.Text;
                var connection = textBox5.Text;

                var query = $"update clients set name_client = N'{name}', problem = N'{problem}', phone_number = N'{phone}', email = N'{email}', connection = N'{connection}'";

                var command = new SqlCommand(query, database.GetConnection());
                command.ExecuteNonQuery();
            
            database.closeConnection();
        }
    }
}

