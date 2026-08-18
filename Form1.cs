using Microsoft.Data.SqlClient;

namespace WinFormsApp_radio_checkbox
{
    public partial class Form1 : Form
    {
        string constr = @"Data Source=LAPTOP-R9MRDLN3\SQLEXPRESS;Initial Catalog=FreeCodingDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
        SqlConnection con;
        string gender;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            txtname.Text = string.Empty;
            radioButton1.Checked = true;
            checkBox1.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            int isactive = 0;
            isactive = checkBox1.Checked ? 1 : 0;

            using (con = new SqlConnection(constr))
            {
                con.Open();
                string strqry = "insert into student values('" + txtname.Text + "','"+gender+"',"+ isactive + ")";
                SqlCommand cmd = new SqlCommand(strqry, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Student Added Successfully");
                clear();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                gender = "Female";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                gender = "Male";
            }
        }
    }
}
