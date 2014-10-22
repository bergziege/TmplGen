using System.Windows.Controls;

using De.BerndNet2000.TmplGen.Ui.CreateTemplatePage.ViewModels;

namespace De.BerndNet2000.TmplGen.Ui.CreateTemplatePage {
    /// <summary>
    ///     Interaction logic for CreateTemplatePage.xaml
    /// </summary>
    public partial class CreateTemplatePage : UserControl {
        /// <summary>
        ///     Ctor.
        /// </summary>
        public CreateTemplatePage() {
            InitializeComponent();
            if (DataContext == null) {
                DataContext = new CreateTemplatePageViewModel();
            }
        }
    }
}