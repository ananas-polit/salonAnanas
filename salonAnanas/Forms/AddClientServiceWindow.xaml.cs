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
    /// Логика взаимодействия для AddClientServiceWindow.xaml
    /// </summary>
    public partial class AddClientServiceWindow : Window
    {
        SalonAnanasEntities1 context;
        public AddClientServiceWindow(SalonAnanasEntities1 context1, ClientService clientService)
        {
            InitializeComponent();
            this.context = context1;
            this.DataContext = clientService;

        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
