using System.Windows.Controls;

using De.BerndNet2000.TmplGen.Ui.CreateProjectPage.ViewModels;

namespace De.BerndNet2000.TmplGen.Ui.CreateProjectPage {
    /// <summary>
    ///     Interaction logic for CreateProjectPage.xaml
    /// </summary>
    public partial class CreateProjectPage : UserControl {
        /// <summary>
        /// </summary>
        public CreateProjectPage() {
            InitializeComponent();
            if (DataContext == null) {
                DataContext = new CreateProjectPageViewModel();
            }
        }
    }
}