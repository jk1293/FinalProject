using System;
using System.Collections.Generic;
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
    /// Interaction logic for Favorites.xaml
    /// </summary>
    public partial class Favorites : Window
    {
        public Favorites()
        {
            InitializeComponent();
            //fillcombobox();
        }

        //public void fillcombobox()
        //{


        //    SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");
        //    string query = "select * from Favourites";
        //    SqlCommand cmd = new SqlCommand(query, sqlcon);
        //    SqlDataReader myreader;
        //    //MessageBox.Show(a);
        //    //MessageBox.Show($" {myreader["Username"].ToString()}");

        //    try
        //    {
        //        sqlcon.Open();
        //        myreader = cmd.ExecuteReader();
        //        while (myreader.Read())
        //        {


        //            string sname = myreader.GetString(1);
        //            Combobox.Items.Add(sname);
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            m.Username1.Text = Username2.Text;
            m.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True");
            Athletes p = new Athletes();
            try
            {

                sqlcon.Open();
                string query = $"Select * from Athletes where Name = '" + Combobox.Text + "'";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                p.Age.Text = reader["Age"].ToString();
                p.Nationality.Text = reader["Nationality"].ToString();
                p.Wins.Text = reader["Wins"].ToString();
                p.Podiums.Text = reader["Podiums"].ToString();

                p.name.Text = reader["Name"].ToString();
               
                p.UsernameS.Text = Username2.Text;
              
                p.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { sqlcon.Close(); }

            this.Close();
        }
    }
}
