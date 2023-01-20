using PenShop.db;
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

namespace PenShop.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditOrder.xaml
    /// </summary>
    public partial class AddEditOrder : Window
    {
        private Order currentorder = new Order();
        public event Action ChangeOrder;
        public AddEditOrder(Order selectedorder)
        {
            InitializeComponent();
            if (selectedorder != null)
                currentorder = selectedorder;

            DataContext = currentorder;
            ComboPen.ItemsSource = App.db.Pens.ToList();
            ComboPen.DisplayMemberPath = "Articul";
            ComboClient.ItemsSource = App.db.Clients.ToList();
            ComboClient.DisplayMemberPath = "Name_Or_FIO";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace((currentorder.Count_Pens).ToString()) ||
                string.IsNullOrWhiteSpace((currentorder.Id_Pen).ToString()) ||
                string.IsNullOrWhiteSpace((currentorder.Id_Client).ToString()) ||
                string.IsNullOrWhiteSpace((currentorder.Date_Order).ToString()))

            {
                MessageBox.Show("Введены не все данные");
                return;

            }
            if (currentorder.Id_Order == 0)
            {
                var client = ComboClient.SelectedItem as Clients;
                var pen = ComboPen.SelectedItem as Pens;
                currentorder.Id_Client = client.Id_Client;
                currentorder.Id_Pen = pen.Id_Pen;
                App.db.Order.Add(currentorder);
                App.db.SaveChanges();
                MessageBox.Show("Успешно добавлено");
                ChangeOrder?.Invoke();
                this.Close();
            }
            else
            {

                try
                {
                    var client = ComboClient.SelectedItem as Clients;
                    var pen = ComboPen.SelectedItem as Pens;
                    currentorder.Id_Client = client.Id_Client;
                    currentorder.Id_Pen = pen.Id_Pen;
                    App.db.SaveChanges();
                    MessageBox.Show("Запись изменена");
                    ChangeOrder?.Invoke();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
