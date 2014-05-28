using System.Collections.ObjectModel;

namespace De.BerndNet2000.TmplGen.Ui.Common {
    /// <summary>
    /// Basisviewmodel mit Reportingfunktionalität
    /// </summary>
    public interface IReportingBaseViewModel {
        /// <summary>
        /// Liefert oder setzt die Liste an Reportitems.
        /// </summary>
        ObservableCollection<IReportItemViewModel> ReportItems { get; set; }

    }
}