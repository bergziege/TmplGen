using System.Collections.ObjectModel;

using FirstFloor.ModernUI.Presentation;

namespace De.BerndNet2000.TmplGen.Ui.WhitelistPage {
    /// <summary>
    ///     Interface for view models for whitelist view
    /// </summary>
    public interface IWhitelistPageViewModel {
        /// <summary>
        ///     Returns a command to add the current input as new extension to the list.
        /// </summary>
        RelayCommand AddNewExtensionCommand { get; }
        /// <summary>
        ///     Returns or sets the user input.
        /// </summary>
        string ExtensionInput { get; set; }

        /// <summary>
        ///     Returns the list of extensions.
        /// </summary>
        ObservableCollection<string> Extensions { get; }
        /// <summary>
        ///     Returns a command to remove the current selected extension from the list.
        /// </summary>
        RelayCommand RemoveExtensionCommand { get; }

        /// <summary>
        ///     Returns or sets the currently selected extension.
        /// </summary>
        string SelectedExtension { get; set; }
    }
}