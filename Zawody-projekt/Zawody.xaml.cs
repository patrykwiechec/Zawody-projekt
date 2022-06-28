using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace Zawody_projekt
{
    /// <summary>
    /// Interaction logic for Zawody.xaml
    /// </summary>
    public partial class Zawody : Window
    {
        public Zawody()
        {
            InitializeComponent();
            //LoadGrid(); 
        }

        //połączenie z bazą
     //   SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Zawody;Integrated Security=True");

        //Wypisanie tabeli
    /*   public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT id_zawodow as ZawodyID, nazwa as NazwaZawodów, FORMAT(data_za,'M/dd/yyyy') as DataZawodów FROM Zawody", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
           
        }
    */




        //cofnij do MainWindow
        private void Cofnij_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        //Wyjście z aplikacji
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

       
    }
}
