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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        SalonAnanasEntities1 context;
        public ClientWindow()
        {
            InitializeComponent();
            context = new SalonAnanasEntities1();
           
            dgClient.ItemsSource = context.Clients.ToList(); 
        }

        private void CmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentRegistr = BtnEdit.DataContext as Client;
            var EditWindow = new AddClientWindow(context, currentRegistr);
            EditWindow.ShowDialog();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var currentRegistr = dgClient.SelectedItem as Client;
            if (currentRegistr == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Clients.Remove(currentRegistr);
                context.SaveChanges();

            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var NewClient = new Client();//определяет новый объект
            context.Clients.Add(NewClient);//добавляем 
            var EditWindow = new AddClientWindow(context, NewClient);
            EditWindow.ShowDialog();
            
        }

        private void TxtPlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
