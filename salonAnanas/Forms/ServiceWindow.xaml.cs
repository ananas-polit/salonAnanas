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
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        SalonAnanasEntities1 context;
        public ServiceWindow()
        {
            InitializeComponent();
            context = new SalonAnanasEntities1();
            dgServices.ItemsSource = context.Services.ToList();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            var NewService = new Service();//определяет новый объект
            context.Services.Add(NewService);//добавляем 
            var AddWindow = new AddServiceWindow(context, NewService);
            AddWindow.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentRegistr = dgServices.SelectedItem as Service;
            if (currentRegistr == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно ходите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Services.Remove(currentRegistr);
                context.SaveChanges();

            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentRegistr = BtnEdit.DataContext as Service;
            var EditWindow = new AddServiceWindow(context, currentRegistr);
            EditWindow.ShowDialog();
        }
    }
}
