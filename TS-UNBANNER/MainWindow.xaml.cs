using System;
using System.Management;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using ProductIdService;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ProductIdChanger.ChangeProductID(txtProductId.Text) == true)
            {
                MessageBox.Show("Changed Successfully");
            }
            else
            {
                MessageBox.Show("Error Try Running App as Administrator");
            }
            txtProductId.Text = ProductIdChanger.SeeProductID();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            #region UnComment This Code On 32it System's

            if (Environment.Is64BitOperatingSystem)
            {
                MessageBox.Show("Your windows is 64bit please download 64bit verison.");
                System.Diagnostics.Process.Start("http://lerphub.com/");
                Application.Current.Shutdown();
            }

            #endregion

            txtProductId.Text = ProductIdChanger.SeeProductID();
           
        }
        private void BtnAboutUs_Click(object sender, RoutedEventArgs e)
        {
            AboutUsWindow a = new AboutUsWindow();
            a.ShowDialog();
        }
    }
}
