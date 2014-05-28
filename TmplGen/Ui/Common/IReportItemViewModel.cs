using De.BerndNet2000.TmplGen.Ui.Common.Enums;

namespace De.BerndNet2000.TmplGen.Ui.Common {
    /// <summary>
    ///     Schnittstelle eines ViewModels für ein Reportitem.
    /// </summary>
    public interface IReportItemViewModel {
        /// <summary>
        ///     Nachricht des Items
        /// </summary>
        string Message { get; set; }
        /// <summary>
        ///     Status dieses Items
        /// </summary>
        ReportItemStatus Status { get; set; }
    }
}