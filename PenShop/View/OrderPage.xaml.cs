using PenShop.db;
using PenShop.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PenShop.View
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            DataGridOrder.ItemsSource = App.db.Order.OrderByDescending(x => x.Date_Order).ToList();
        }

        private void DataGridOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnDelete.IsEnabled = true;
            EditBtn.IsEnabled = true;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить заказ? ", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    App.db.Order.Remove(DataGridOrder.SelectedItem as Order);
                    App.db.SaveChanges();
                    MessageBox.Show("Успещно");
                    DataGridOrder.ItemsSource = App.db.Order.OrderByDescending(x => x.Date_Order).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditOrder addEditOrder = new AddEditOrder(null);
            addEditOrder.ChangeOrder += (() => DataGridOrder.ItemsSource = App.db.Order.OrderByDescending(x => x.Date_Order).ToList());
            addEditOrder.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditOrder addEditOrder = new AddEditOrder(DataGridOrder.SelectedItem as Order);
            addEditOrder.ChangeOrder += (() => DataGridOrder.ItemsSource = App.db.Order.OrderByDescending(x => x.Date_Order).ToList());
            addEditOrder.Show();
        }
    }
}
