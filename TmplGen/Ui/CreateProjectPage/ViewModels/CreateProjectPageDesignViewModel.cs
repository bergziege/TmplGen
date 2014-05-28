using FirstFloor.ModernUI.Presentation;

using ReactiveUI;

namespace De.BerndNet2000.TmplGen.Ui.CreateProjectPage.ViewModels {
    /// <summary>
    /// 
    /// </summary>
    public class CreateProjectPageDesignViewModel:ReactiveObject, ICreateProjectPageViewModel {
        /// <summary>
        /// 
        /// </summary>
        public string NewProjectName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RelayCommand CreateProjectCommand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RelayCommand SelectTemplateSourceFileCommand { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public RelayCommand SelectProjectTargetFolderCommand { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string TemplateSourceFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectTargetFolder { get; set; }
    }
}