using De.BerndNet2000.TmplGen.Ui.Common.Enums;

using ReactiveUI;

namespace De.BerndNet2000.TmplGen.Ui.Common.ViewModels {
    /// <summary>
    /// View Model für ein Report Item.
    /// </summary>
    public class ReportItemViewModel:ReactiveObject, IReportItemViewModel {
        private string _message;
        private ReportItemStatus _status;
        public string Message {
            get { return _message; }
            set { _message = value; }
        }

        public ReportItemStatus Status {
            get { return _status; }
            set { _status = value; }
        }
    }
}