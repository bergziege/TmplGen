using System.Collections.ObjectModel;

using De.BerndNet2000.TmplGen.Ui.Common.Enums;

using ReactiveUI;

namespace De.BerndNet2000.TmplGen.Ui.Common.ViewModels {
    /// <summary>
    ///     Basis View Model mit Report Items.
    /// </summary>
    public class ReportingBaseViewModel : ReactiveObject, IReportingBaseViewModel {
        private ObservableCollection<IReportItemViewModel> _reportItems =
                new ObservableCollection<IReportItemViewModel>();
        public ObservableCollection<IReportItemViewModel> ReportItems {
            get { return _reportItems; }
            set { this.RaiseAndSetIfChanged(ref _reportItems, value); }
        }

        /// <summary>
        ///     Fügt einen Fehler zur den Report Items hinzu.
        /// </summary>
        /// <param name="error"></param>
        public void ReportError(string error) {
            ReportItems.Add(new ReportItemViewModel { Message = error, Status = ReportItemStatus.Error });
        }

        /// <summary>
        ///     Fügt eine Info zur den Report Items hinzu.
        /// </summary>
        /// <param name="message"></param>
        public void ReportMessage(string message) {
            ReportItems.Add(new ReportItemViewModel { Message = message, Status = ReportItemStatus.Information });
        }
    }
}