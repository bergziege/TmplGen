using System.Collections.ObjectModel;

using De.BerndNet2000.TmplGen.Ui.Common.Enums;

using ReactiveUI;

using TmplGen.Services.Helper;

namespace De.BerndNet2000.TmplGen.Ui.Common.ViewModels {
    /// <summary>
    ///     Basis View Model mit Report Items.
    /// </summary>
    public class ReportingBaseViewModel : ReactiveObject, IReportingBaseViewModel {
        private bool _isProcessing;
        private ObservableCollection<IReportItemViewModel> _reportItems =
                new ObservableCollection<IReportItemViewModel>();

        /// <summary>
        /// </summary>
        public bool IsProcessing {
            get { return _isProcessing; }
            set { this.RaiseAndSetIfChanged(ref _isProcessing, value); }
        }

        /// <summary>
        ///     Liefert oder setzt die Liste an Reportitems.
        /// </summary>
        public ObservableCollection<IReportItemViewModel> ReportItems {
            get { return _reportItems; }
            set { this.RaiseAndSetIfChanged(ref _reportItems, value); }
        }

        /// <summary>
        ///     Fügt einen Fehler zur den Report Items hinzu.
        /// </summary>
        /// <param name="error"></param>
        public void ReportError(string error) {
            TaskHelper.ToTask(
                    () => ReportItems.Add(new ReportItemViewModel { Message = error, Status = ReportItemStatus.Error }),
                    ApplicationContext.Instance.SyncContext);
        }

        /// <summary>
        ///     Fügt eine Info zur den Report Items hinzu.
        /// </summary>
        /// <param name="message"></param>
        public void ReportMessage(string message) {
            TaskHelper.ToTask(
                    () =>
                            ReportItems.Add(new ReportItemViewModel
                            { Message = message, Status = ReportItemStatus.Information }),
                    ApplicationContext.Instance.SyncContext);
        }
    }
}