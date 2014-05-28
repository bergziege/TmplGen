using System.Collections.ObjectModel;

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
    }
}