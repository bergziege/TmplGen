using System.Collections.ObjectModel;
using System.Linq;

using De.BerndNet2000.TmplGen.Properties;

using FirstFloor.ModernUI.Presentation;

using ReactiveUI;

namespace De.BerndNet2000.TmplGen.Ui.WhitelistPage.ViewModels {
    /// <summary>
    ///     View Model for the whitelist view
    /// </summary>
    public class WhitelistePageViewModel : ReactiveObject, IWhitelistPageViewModel {
        private ObservableCollection<string> _extensions = new ObservableCollection<string>();
        private RelayCommand _addNewExtensionCommand;
        private string _extensionInput;
        private RelayCommand _removeExtensionCommand;
        private string _selectedExtension;

        /// <summary>
        ///     Creates a new instance
        /// </summary>
        public WhitelistePageViewModel() {
            LoadExtensions();
        }

        /// <summary>
        ///     Returns a command to add the current input as new extension to the list.
        /// </summary>
        public RelayCommand AddNewExtensionCommand {
            get {
                if (_addNewExtensionCommand == null) {
                    _addNewExtensionCommand = new RelayCommand(AddNewExtension, CanAddExtension);
                }

                return _addNewExtensionCommand;
            }
        }

        /// <summary>
        ///     Returns or sets the user input.
        /// </summary>
        public string ExtensionInput {
            get { return _extensionInput; }
            set { this.RaiseAndSetIfChanged(ref _extensionInput, value); }
        }

        /// <summary>
        ///     Returns the list of extensions.
        /// </summary>
        public ObservableCollection<string> Extensions {
            get { return _extensions; }
        }

        /// <summary>
        ///     Returns a command to remove the current selected extension from the list.
        /// </summary>
        public RelayCommand RemoveExtensionCommand {
            get {
                if (_removeExtensionCommand == null) {
                    _removeExtensionCommand = new RelayCommand(RemoveExtension, CanRemoveExtension);
                }

                return _removeExtensionCommand;
            }
        }

        /// <summary>
        ///     Returns or sets the currently selected extension.
        /// </summary>
        public string SelectedExtension {
            get { return _selectedExtension; }
            set { this.RaiseAndSetIfChanged(ref _selectedExtension, value); }
        }

        private void AddNewExtension(object param) {
            _extensions.Add(ExtensionInput.Trim());
            ExtensionInput = string.Empty;
            SaveExtensions();
        }

        private bool CanAddExtension(object arg) {
            return !string.IsNullOrWhiteSpace(ExtensionInput);
        }

        private bool CanRemoveExtension(object arg) {
            return SelectedExtension != null;
        }

        private void LoadExtensions() {
            foreach (string s in Settings.Default.FileExtensionWhitelist.Cast<string>().OrderBy(x=>x)) {
                _extensions.Add(s);
            }
        }

        private void RemoveExtension(object param) {
            _extensions.Remove(SelectedExtension);
            SaveExtensions();
        }

        private void SaveExtensions() {
            Settings.Default.FileExtensionWhitelist.Clear();
            foreach (string extension in Extensions) {
                Settings.Default.FileExtensionWhitelist.Add(extension);
            }
            Settings.Default.Save();
        }
    }
}