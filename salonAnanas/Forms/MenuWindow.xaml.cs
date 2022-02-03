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

namespace salonAnanas.Forms
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            var client = new ClientWindow();
            client.ShowDialog();
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {
            var service = new ServiceWindow();
            service.ShowDialog();
        }

        private void BtnClientService_Click(object sender, RoutedEventArgs e)
        {
            var cs = new ClientServiceWindow();
            cs.ShowDialog();
        }

        
    }
}
