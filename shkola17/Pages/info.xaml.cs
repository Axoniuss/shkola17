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

namespace shkola17.Pages
{
    /// <summary>
    /// Логика взаимодействия для info.xaml
    /// </summary>
    public partial class info : Page
    {
        private Entities.sotr _currentcar = new Entities.sotr();
        public info(Entities.sotr client)
        {
            InitializeComponent();
        }
        private void Page_Is_Visible_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.invent_tehnikaEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                dtclient.ItemsSource = Entities.invent_tehnikaEntities1.GetContext().sotr.ToList();
            }
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Manager.fframe.Navigate(new Pages.addeditsotr((sender as Button).DataContext as Entities.sotr));
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dtclient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttondel_Click(object sender, RoutedEventArgs e)
        {
            var CarsForRemoving = dtclient.SelectedItems.Cast<Entities.sotr>().ToList();


            if (MessageBox.Show($"Вы уверены, что хотите удалить данные о " + $"{CarsForRemoving.Count}столбце", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.invent_tehnikaEntities1.GetContext().sotr.RemoveRange(CarsForRemoving);
                    Entities.invent_tehnikaEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Удаление завершено");
                    dtclient.ItemsSource = Entities.invent_tehnikaEntities1.GetContext().sotr.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
        }

        private void Add_Color(object sender, RoutedEventArgs e)
        {
            Manager.fframe.Navigate(new Pages.addeditsotr(null));
        }
    }
}
