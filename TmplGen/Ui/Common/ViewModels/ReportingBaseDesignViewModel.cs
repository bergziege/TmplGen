using System.Collections.ObjectModel;

using De.BerndNet2000.TmplGen.Ui.Common.Enums;

using ReactiveUI;

namespace De.BerndNet2000.TmplGen.Ui.Common.ViewModels {
    /// <summary>
    ///     Design View Model für ein Reporting Base View Model.
    /// </summary>
    public class ReportingBaseDesignViewModel : ReactiveObject, IReportingBaseViewModel {
        private ObservableCollection<IReportItemViewModel> _reportItems;
        /// <summary>
        ///     Liefert oder setzt die Liste an Reportitems.
        /// </summary>
        public ObservableCollection<IReportItemViewModel> ReportItems {
            get {
                return new ObservableCollection<IReportItemViewModel> {
                    new ReportItemViewModel { Status = ReportItemStatus.Information, Message = "info" },
                    new ReportItemViewModel { Status = ReportItemStatus.Error, Message = "error" }
                };
            }
            set { this.RaiseAndSetIfChanged(ref _reportItems, value); }
        }

        public void ReportError(string error) {
        }

        public void ReportMessage(string message) {
        }
    }
}