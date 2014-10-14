using System.Collections.ObjectModel;

using FirstFloor.ModernUI.Presentation;

using ReactiveUI;

namespace De.BerndNet2000.TmplGen.Ui.WhitelistPage.ViewModels {
    /// <summary>
    ///     Design view model for whitelist view.
    /// </summary>
    public class WhitelistDesignViewModel : ReactiveObject, IWhitelistPageViewModel {
        private RelayCommand _addNewExtensionCommand;
        private string _extensionInput;
        private ObservableCollection<string> _extensions;
        private RelayCommand _removeExtensionCommand;
        private string _selectedExtension;
        /// <summary>
        ///     Returns a command to add the current input as new extension to the list.
        /// </summary>
        public RelayCommand AddNewExtensionCommand {
            get { return _addNewExtensionCommand; }
        }

        /// <summary>
        ///     Returns or sets the user input.
        /// </summary>
        public string ExtensionInput {
            get { return "user input"; }
            set { _extensionInput = value; }
        }

        /// <summary>
        ///     Returns the list of extensions.
        /// </summary>
        public ObservableCollection<string> Extensions {
            get { return new ObservableCollection<string> { "sln", "csproj", "cs" }; }
        }

        /// <summary>
        ///     Returns a command to remove the current selected extension from the list.
        /// </summary>
        public RelayCommand RemoveExtensionCommand {
            get { return _removeExtensionCommand; }
        }

        /// <summary>
        ///     Returns or sets the currently selected extension.
        /// </summary>
        public string SelectedExtension {
            get { return "csproj"; }
            set { _selectedExtension = value; }
        }
    }
}