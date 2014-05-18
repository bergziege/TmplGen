using System.Windows;

using De.BerndNet2000.TmplGen.Ui.Shell;
using De.BerndNet2000.TmplGen.Ui.Shell.ViewModels;

namespace De.BerndNet2000.TmplGen {
    /// <summary>
    ///     Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs"/> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            IShellViewModel vm = new ShellViewModel();
            Shell shell = new Shell();
            shell.DataContext = vm;

            MainWindow = shell;
            MainWindow.Show();
        }
    }
}