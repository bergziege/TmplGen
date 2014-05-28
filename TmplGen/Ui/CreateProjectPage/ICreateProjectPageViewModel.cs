using FirstFloor.ModernUI.Presentation;

namespace De.BerndNet2000.TmplGen.Ui.CreateProjectPage {
    /// <summary>
    /// 
    /// </summary>
    public interface ICreateProjectPageViewModel {
        /// <summary>
        /// 
        /// </summary>
        string NewProjectName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        RelayCommand CreateProjectCommand { get; }
        /// <summary>
        /// 
        /// </summary>
        RelayCommand SelectTemplateSourceFileCommand { get; }
        /// <summary>
        /// 
        /// </summary>
        RelayCommand SelectProjectTargetFolderCommand { get; }
        /// <summary>
        /// 
        /// </summary>
        string TemplateSourceFile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ProjectTargetFolder { get; set; }
    }
}