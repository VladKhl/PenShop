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
    /// Логика взаимодействия для PenPage.xaml
    /// </summary>
    public partial class PenPage : Page
    {
        public PenPage()
        {
            InitializeComponent();
            DataGridPen.ItemsSource = App.db.Pens.ToList();
        }

        private void DataGridPen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnDelete.IsEnabled = true;
            EditBtn.IsEnabled = true;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить ручку? Это так же удалит все заказы с ней", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    if ((App.db.Order.Where(x => x.Id_Pen == (DataGridPen.SelectedItem as Pens).Id_Pen) != null))
                    {
                        App.db.Order.RemoveRange(App.db.Order.Where(x => x.Id_Pen == (DataGridPen.SelectedItem as Pens).Id_Pen).ToList());
                    }
                    App.db.Pens.Remove(DataGridPen.SelectedItem as Pens);
                    App.db.SaveChanges();
                    MessageBox.Show("Успещно");
                    DataGridPen.ItemsSource = App.db.Pens.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            //AddEditPen addEditOrder = new AddEditPen(null);
            //addEditOrder.ChangeOrder += (() => DataGridOrder.ItemsSource = App.db.Order.OrderByDescending(x => x.Date_Order).ToList());
            //addEditOrder.Show();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
