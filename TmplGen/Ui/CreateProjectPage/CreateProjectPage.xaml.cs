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

using De.BerndNet2000.TmplGen.Ui.CreateProjectPage.ViewModels;

namespace De.BerndNet2000.TmplGen.Ui.CreateProjectPage {
    /// <summary>
    /// Interaction logic for CreateProjectPage.xaml
    /// </summary>
    public partial class CreateProjectPage : UserControl {
        /// <summary>
        /// 
        /// </summary>
        public CreateProjectPage() {
            InitializeComponent();
            if (DataContext == null) {
                DataContext = new CreateProjectPageViewModel();
            }
        }
    }
}
