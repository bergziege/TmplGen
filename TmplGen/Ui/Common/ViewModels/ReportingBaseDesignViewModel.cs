using System.Collections.ObjectModel;

using ReactiveUI;

namespace De.BerndNet2000.TmplGen.Ui.Common.ViewModels {
    /// <summary>
    /// Design View Model für ein Reporting Base View Model.
    /// </summary>
    public class ReportingBaseDesignViewModel:ReactiveObject, IReportingBaseViewModel {
        private ObservableCollection<IReportItemViewModel> _reportItems;
        public ObservableCollection<IReportItemViewModel> ReportItems {
            get { return _reportItems; }
            set { this.RaiseAndSetIfChanged(ref _reportItems, value); }
        }
    }
}