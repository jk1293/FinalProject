using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
                    string logname = "";
        public Menu()
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");

            InitializeComponent();   

            for (int i = 1; i <= 4; i++)
            {
                try
                {
                    if (sqlcon.State == ConnectionState.Closed)
                    {
                        sqlcon.Open();
                    }
                    string query = $"SELECT news FROM News Where id= '" + i + "'";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                    sqlCmd.ExecuteNonQuery();
                    //sqlCmd.CommandType = CommandType.Text;
                    //sqlCmd.Parameters.AddWithValue("@Username", Username.Text);
                    //sqlCmd.Parameters.AddWithValue("@Password", Password.Password);
                    SqlDataReader reader = sqlCmd.ExecuteReader();
                    reader.Read();


                    if (i == 1)
                    {
                        n1.Text = reader["news"].ToString(); 
                    }
                    else if (i == 2)
                    {
                        n2.Text = reader["news"].ToString();
                    }
                    else if (i == 3)
                    {
                        n3.Text = reader["news"].ToString();
                    }
                    else if (i == 4)
                    {
                        n4.Text = reader["news"].ToString();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlcon.Close();
                }
            }

            }
           
       
        

        private void Athletes_Click(object sender, RoutedEventArgs e)
        {
            AthletesSearch s = new AthletesSearch();
            s.Username3.Text = Username1.Text;
            s.Show();
            s.text.Text = "Which athlete do you want to know about?";
            this.Close();

        }

        private void Standings_Click(object sender, RoutedEventArgs e)
        {
            Standings s = new Standings();
            s.UsernamR.Text = Username1.Text;
            s.Show();
            this.Close();
        }

        private void Events_Click(object sender, RoutedEventArgs e)
        {
            Events events = new Events();
            events.UsernameE.Text = Username1.Text;
            events.Show();
            this.Close();
        }

        private void Favorites_Click(object sender, RoutedEventArgs e)
        {

            Favorites f = new Favorites();
            f.Username2.Text = Username1.Text;
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");
            string query = "select * from Favourites where Username = '" + Username1.Text + "'";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            SqlDataReader myreader;
            //MessageBox.Show($" {myreader["Username"].ToString()}");

            try
            {

                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {

                    string sname = myreader.GetString(2);
                    f.Combobox.Items.Add(sname);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            f.Show();            this.Close();

        }
    }

}
