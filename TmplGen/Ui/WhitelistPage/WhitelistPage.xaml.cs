using System.Windows.Controls;

using De.BerndNet2000.TmplGen.Ui.WhitelistPage.ViewModels;

namespace De.BerndNet2000.TmplGen.Ui.WhitelistPage {
    /// <summary>
    ///     Interaktionslogik für WhitelistPage.xaml
    /// </summary>
    public partial class WhitelistPage : UserControl {
        public WhitelistPage() {
            InitializeComponent();
            if (DataContext == null) {
                DataContext = new WhitelistePageViewModel();
            }
        }
    }
}