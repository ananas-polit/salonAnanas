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
    /// Логика взаимодействия для ClientServiceWindow.xaml
    /// </summary>
    public partial class ClientServiceWindow : Window
    {
        SalonAnanasEntities1 context;
        public ClientServiceWindow()
        {
            InitializeComponent();
            context = new SalonAnanasEntities1();
            dgClientService.ItemsSource = context.ClientServices.ToList();
        }

        private void BtnAddCS_Click(object sender, RoutedEventArgs e)
        {
            var NewClientService = new ClientService();
            context.ClientServices.Add(NewClientService);
            var AddWindow = new AddClientServiceWindow(context, NewClientService);
            AddWindow.ShowDialog();
        }

        private void BtnDelCS_Click(object sender, RoutedEventArgs e)
        {
            var currentRegistr = dgClientService.SelectedItem as ClientService;
            if (currentRegistr == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.ClientServices.Remove(currentRegistr);
                context.SaveChanges();
              
            }
        }

        private void BtnEditCS_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentRegistr = BtnEdit.DataContext as ClientService;
            var EditWindow = new AddClientServiceWindow(context, currentRegistr);
            EditWindow.ShowDialog();
        }
    }
}
