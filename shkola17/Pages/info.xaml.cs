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
        public info()
        {
            InitializeComponent();
        }
        private void Page_Is_Visible_Changed(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Entities.invent_tehnikaEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LView.ItemsSource = Entities.invent_tehnikaEntities1.GetContext().model.ToList();
            }
        }
    }
}
