using De.BerndNet2000.TmplGen.Ui.Common.ViewModels;

using FirstFloor.ModernUI.Presentation;

using ReactiveUI;

namespace De.BerndNet2000.TmplGen.Ui.CreateTemplatePage.ViewModels {
    /// <summary>
    /// 
    /// </summary>
    public class CreateTemplatePageDesignViewModel: ReportingBaseDesignViewModel, ICreateTemplatePageViewModel {
        /// <summary>
        /// 
        /// </summary>
        public RelayCommand SelectSourceFolderCommand { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public RelayCommand SelectTemplateTargetFileCommand { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string SourceFolder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TargetFilePath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OldProjectName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RelayCommand CreateTemplateCommand { get; set; }
    }
}