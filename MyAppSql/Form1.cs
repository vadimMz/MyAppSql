using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAppSql
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\peppe\Desktop\MySqlProjectOnWInForms\MyAppSql\MyAppSql\Database.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
                        
            connection = new SqlConnection(connectionString);

            await connection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [CONTACTS]", connection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(
                        Convert.ToString(sqlReader["Id"]) + "  " +
                        Convert.ToString(sqlReader["Name"]) + "  " +
                        Convert.ToString(sqlReader["Organization"]) + "  " +
                        Convert.ToString(sqlReader["Email"]) + "  " +
                        Convert.ToString(sqlReader["Phone"]) + "  " +
                        Convert.ToString(sqlReader["Phone2"]) + "  " +
                        Convert.ToString(sqlReader["Type"])
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Contact myContact = new Contact(NameBoxINS.Text, OrganizationBoxINS.Text, EmailBoxINS.Text, PhoneBoxINS.Text, PhoneBox2INS.Text, TypeBoxINS.Text);
          
          
            String Insert = "INSERT INTO CONTACTS (Name, Organization, Email, Phone, Phone2, Type) VALUES ('" + myContact.Name + "','" + myContact.Organization + "','" + myContact.Email + "','" + myContact.Phone + "','" + myContact.Phone2 + "','" + myContact.Type + "')";
            SqlCommand command = new SqlCommand(Insert, connection);
         

            try
            {
                if (myContact.CheckNullOrEmpty() == true)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("New contact has been added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("New contact has not been added");

            }
            finally
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                    NameBoxINS.Text = null;
                    OrganizationBoxINS.Text = null;
                    EmailBoxINS.Text = null;
                    PhoneBoxINS.Text = null;
                    PhoneBox2INS.Text = null;
                    TypeBoxINS.Text = null;
                }

            }





        }

        private async void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            connection = new SqlConnection(connectionString);

            await connection.OpenAsync();

            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [CONTACTS]", connection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(
                        Convert.ToString(sqlReader["Id"]) + "  " +
                        Convert.ToString(sqlReader["Name"]) + "  " +
                        Convert.ToString(sqlReader["Organization"]) + "  " +
                        Convert.ToString(sqlReader["Email"]) + "  " +
                        Convert.ToString(sqlReader["Phone"]) + "  " +
                        Convert.ToString(sqlReader["Phone2"]) + "  " +
                        Convert.ToString(sqlReader["Type"])
                        );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
            Application.Exit();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Contact myContact = new Contact(IDBoxUPD.Text, NameBoxUPD.Text, OrganizationBoxUPD.Text, EmailBoxUPD.Text, PhoneBoxUPD.Text, Phone2BoxUPD.Text, TypeBoxUPD.Text);

            String UpdateByID = "UPDATE CONTACTS SET Name = '" + myContact.Name + "', Organization = '" + myContact.Organization + "', Email = '" + myContact.Email + "', Phone ='" + myContact.Phone + "', Phone2 = '" + myContact.Phone2 + "',Type = '" + myContact.Type + "' WHERE id = '" + myContact.Id + "'";
            SqlCommand command = new SqlCommand(UpdateByID, connection);


            try
            {
                if (!String.IsNullOrEmpty(myContact.Id) == true)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("The contact has been changed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("The contact has not been changed");

            }
            finally
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                    NameBoxUPD.Text = null;
                    OrganizationBoxUPD.Text = null;
                    EmailBoxUPD.Text = null;
                    PhoneBoxUPD.Text = null;
                    Phone2BoxUPD.Text = null;
                    TypeBoxUPD.Text = null;
                }

            }

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            Contact myContact = new Contact(IDBoxDEL.Text);
            String DeleteByID = "DELETE FROM CONTACTS WHERE id = '" + myContact.Id + "'";
            SqlCommand command = new SqlCommand(DeleteByID, connection);


            try
            {
                if (!String.IsNullOrEmpty(myContact.Id) == true)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("The contact has been deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("The contact has not been deleted");

            }
            finally
            {
                if (connection != null && connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                    IDBoxDEL.Text = null;
                }

            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(BrowserTextBox.Text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                toolStripProgressBar1.Value = Convert.ToInt32(e.CurrentProgress);
                toolStripProgressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
            }   
            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message);

            }
        }

        private void инфоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Это тестовое приложения, подпиливая которое я изучаю C# и SQL");
        }

        private void pushButton_MouseHover(object sender, EventArgs e)
        {
            pushButton.Text = "Hover";
        }

        private void pushButton_MouseLeave(object sender, EventArgs e)
        {
            pushButton.Text = "Push";
        }



        /* private async void tabControl1_MouseMove(object sender, MouseEventArgs e)
         {


                 labelMouseX.Text = e.X.ToString();
                 labelMouseY.Text = e.Y.ToString();

         }
         */

         private async void tabPage5_MouseMove(object sender, MouseEventArgs e)
 {


         labelMouseX.Text = e.X.ToString();
         labelMouseY.Text = e.Y.ToString();

 }

        private void pushButton_Click(object sender, EventArgs e)
        {
            Form1 example = new Form1();
            example.Show();

        }
    }
}
