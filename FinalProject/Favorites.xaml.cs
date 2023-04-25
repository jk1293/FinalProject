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
        //         sqlcon.Open();
        //    string a = Username2.Text;
        //    SqlCommand cmd = new SqlCommand(query, sqlcon);
        //    SqlDataReader myreader;
        //    MessageBox.Show(a);
        //    //MessageBox.Show($" {myreader["Username"].ToString()}");

        //    try
        //    {

        //        myreader = cmd.ExecuteReader();
        //        while (myreader.Read())
        //        {


        //            string sname = myreader.GetString(2);
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
    }
}
