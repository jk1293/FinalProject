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
    /// Interaction logic for Athletes.xaml
    /// </summary>
    public partial class Athletes : Window
    {
        public Athletes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            m.Username1.Text = UsernameS.Text;
            m.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\FinalProject\FinalProject\nnnnn.mdf;Integrated Security=True"); // needs a path

            sqlcon.Open();
            string query = "SELECT COUNT(1) FROM Favourites Where Athletename=@Athletename";
            SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.Parameters.AddWithValue("@Athletename", name.Text);

            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            if (count == 1)
            {
                 MessageBox.Show("Already added!");
            }
            else
            {
            try
            {


                string query2 = "INSERT INTO Favourites(Username, Athletename) values ('" + this.UsernameS.Text + "','" + this.name.Text + "') ";

                SqlCommand cmd = new SqlCommand(query2, sqlcon);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");

                //Favorites li = new Favorites();
                //li.Show();
                //this.Close();


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
    }
}
