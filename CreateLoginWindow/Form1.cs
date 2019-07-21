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

namespace CreateLoginWindow
{
    public partial class Form1 : Form
    {
        private const string V = "'";

        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();  //Close the form on clicking EXIT
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nikkitha\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30;");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select Count(*) from [Table] where Username='" + username.Text + "' and Password='" + password.Text+"'", sqlConnection);

            //fetching the result to data table:
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            if (dataTable.Rows[0][0].ToString() =="1")
            {
                this.Hide();  //Hide the Main form
                Main main = new Main();
                main.Show();  //On clicking the LOGIN button, show the Main form
            }

            else
            {
                MessageBox.Show("Please check the username and password");
            }
            
        }
    }
}
