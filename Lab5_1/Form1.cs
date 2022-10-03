using System.Data;
using System.Data.SqlClient;

namespace Lab5_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable ExecuteQuery(string Query)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(Class1.connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(Query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        DataSet GetBangGia()
        {
            DataSet data = new DataSet();
            string query = "select * from NHANVIEN";
            using (SqlConnection connection = new SqlConnection(Class1.connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Select * from NHANVIEN";
            dataGridView1.DataSource = ExecuteQuery(query);
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            string query = "update NHANVIEN set HoTenNhanVien = N'" + txtName.Text + "',NgaySinh ='" + dtpDatetime.Text + "',DiaChi ='" + txtAdress.Text + "',DienThoai ='" + txtphone.Text + "',MaBangCap ='" + cbBangcap.Text + "' where HoTenNhanVien = N'" + txtName.Text + "'";
            dataGridView1.DataSource = ExecuteQuery(query);
            dataGridView1.DataSource= GetBangGia().Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            //
            txtName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dtpDatetime.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtAdress.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtphone.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            cbBangcap.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "insert into NHANVIEN values (N'" + txtName.Text + "','" + dtpDatetime.Text + "','" + txtAdress.Text + "','" + txtphone.Text + "','" + cbBangcap.Text + "')";
            dataGridView1.DataSource = ExecuteQuery(query);
            dataGridView1.DataSource = GetBangGia().Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "delete from NHANVIEN where HoTenNhanVien = N'" + txtName.Text + "' ";
            dataGridView1.DataSource = ExecuteQuery(query);
            dataGridView1.DataSource = GetBangGia().Tables[0];
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string query = "Select * from NHANVIEN where HoTenNhanVien =N'"+txtName.Text+"'";
            dataGridView1.DataSource = ExecuteQuery(query);
            //dataGridView1.DataSource = GetBangGia().Tables[0];
        }
    }
}