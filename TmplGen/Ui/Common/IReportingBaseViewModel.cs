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

        /// <summary>
        /// Fügt einen Fehler zur den Report Items hinzu.
        /// </summary>
        /// <param name="error"></param>
        void ReportError(string error);

        /// <summary>
        /// Fügt eine Info zur den Report Items hinzu.
        /// </summary>
        /// <param name="message"></param>
        void ReportMessage(string message);
    }
}