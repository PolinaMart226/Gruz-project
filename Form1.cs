using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Gruz_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Port=5432;Database=Gruz;User ID=postgres;Password=2264";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            DataTable table = new DataTable();

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "SELECT * FROM \"Заказ\"";

                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sqlQuery, conn))
                {
                    adapter.Fill(table);
                }
            }

            dataGridView1.DataSource = table;
        }
    }
}