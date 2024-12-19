using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Academy
{
    public partial class Form1 : Form
    {
        private Form2 frm2;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {

            int i = 1;
            string inputID = txtid.Text;
            string admin_id;
            string y, x, j, n, b;

            string connectionString = "Data Source = LAPTOP-EMVCIH7G;Initial Catalog=CourseAcademyDB;Integrated Security=true";
            string query = "SELECT CO_ID, adm_mail, adm_salary, adm_name FROM ac_admin WHERE adm_Pid = @adm_Pid"; ;

            int admPid;
            if (!int.TryParse(txtid.Text, out admPid))
            {
               MessageBox.Show( "Please enter a valid admin ID.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Use parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@adm_Pid", admPid);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            b = reader["CO_ID"].ToString();
                            admin_id = reader["adm_mail"].ToString();
                            x = reader["adm_salary"].ToString();
                            y = reader["adm_name"].ToString();
                            n = "Data retrieved successfully!";
                            if (inputID == admPid.ToString())
                            {
                                MessageBox.Show("loged in successfylly!");
                                frm2 = new Form2();
                                frm2.Show();
                            }
                            

                        }
                    }
                }
            }

        }
    } 
    
}