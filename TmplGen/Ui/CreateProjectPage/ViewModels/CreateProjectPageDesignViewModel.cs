using De.BerndNet2000.TmplGen.Ui.Common.ViewModels;

using FirstFloor.ModernUI.Presentation;

namespace De.BerndNet2000.TmplGen.Ui.CreateProjectPage.ViewModels {
    /// <summary>
    /// </summary>
    public class CreateProjectPageDesignViewModel : ReportingBaseDesignViewModel, ICreateProjectPageViewModel {
        /// <summary>
        /// </summary>
        public RelayCommand CreateProjectCommand { get; set; }
        /// <summary>
        /// </summary>
        public string NewProjectName { get; set; }
        /// <summary>
        /// </summary>
        public string ProjectTargetFolder { get; set; }
        /// <summary>
        /// </summary>
        public RelayCommand SelectProjectTargetFolderCommand { get; private set; }
        /// <summary>
        /// </summary>
        public RelayCommand SelectTemplateSourceFileCommand { get; private set; }
        /// <summary>
        /// </summary>
        public string TemplateSourceFile { get; set; }
    }
}