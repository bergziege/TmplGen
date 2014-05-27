using FirstFloor.ModernUI.Presentation;

namespace De.BerndNet2000.TmplGen.Ui.CreateTemplatePage {
    /// <summary>
    /// 
    /// </summary>
    public interface ICreateTemplatePageViewModel {
        /// <summary>
        /// 
        /// </summary>
        RelayCommand SelectSourceFolderCommand { get; }
        /// <summary>
        /// 
        /// </summary>
        RelayCommand SelectTemplateTargetFileCommand { get; }

        /// <summary>
        /// 
        /// </summary>
        string SourceFolder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string TargetFilePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string OldProjectName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        RelayCommand CreateTemplateCommand { get;  }
    }
}