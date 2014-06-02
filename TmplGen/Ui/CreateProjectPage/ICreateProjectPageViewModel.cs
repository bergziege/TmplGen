using De.BerndNet2000.TmplGen.Ui.Common;

using FirstFloor.ModernUI.Presentation;

namespace De.BerndNet2000.TmplGen.Ui.CreateProjectPage {
    /// <summary>
    /// </summary>
    public interface ICreateProjectPageViewModel : IReportingBaseViewModel {
        /// <summary>
        /// </summary>
        RelayCommand CreateProjectCommand { get; }
        /// <summary>
        /// </summary>
        string NewProjectName { get; set; }
        /// <summary>
        /// </summary>
        string ProjectTargetFolder { get; set; }
        /// <summary>
        /// </summary>
        RelayCommand SelectProjectTargetFolderCommand { get; }
        /// <summary>
        /// </summary>
        RelayCommand SelectTemplateSourceFileCommand { get; }
        /// <summary>
        /// </summary>
        string TemplateSourceFile { get; set; }
    }
}