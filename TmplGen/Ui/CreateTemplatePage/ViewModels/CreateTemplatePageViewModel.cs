using System.Collections.ObjectModel;

using De.BerndNet2000.TmplGen.Ui.Common;
using De.BerndNet2000.TmplGen.Ui.Common.ViewModels;

using FirstFloor.ModernUI.Presentation;

using Ookii.Dialogs.Wpf;

using ReactiveUI;

using TmplGen.Services;

namespace De.BerndNet2000.TmplGen.Ui.CreateTemplatePage.ViewModels {
    /// <summary>
    /// </summary>
    public class CreateTemplatePageViewModel : ReportingBaseViewModel, ICreateTemplatePageViewModel {
        private RelayCommand _createTemplateCommand;
        private string _oldProjectName;
        private RelayCommand _selectSourceFolderCommand;

        private RelayCommand _selectTemplateTargetFileCommand;
        private string _sourceFolder;
        private string _targetFilePath;
        private TemplatingService _templatingService;
        private ObservableCollection<IReportItemViewModel> _reportItems;

        /// <summary>
        /// Ctor.
        /// </summary>
        public CreateTemplatePageViewModel() {
            _templatingService = new TemplatingService();
        }

        /// <summary>
        /// </summary>
        public RelayCommand CreateTemplateCommand {
            get {
                if (_createTemplateCommand == null) {
                    _createTemplateCommand = new RelayCommand(CreateTemplate);
                }

                return _createTemplateCommand;
            }
        }
        public string OldProjectName {
            get { return _oldProjectName; }
            set { this.RaiseAndSetIfChanged(ref _oldProjectName, value); }
        }
        /// <summary>
        /// </summary>
        public RelayCommand SelectSourceFolderCommand {
            get {
                if (_selectSourceFolderCommand == null) {
                    _selectSourceFolderCommand = new RelayCommand(SelectSourceFolder);
                }

                return _selectSourceFolderCommand;
            }
        }
        /// <summary>
        /// </summary>
        public RelayCommand SelectTemplateTargetFileCommand {
            get {
                if (_selectTemplateTargetFileCommand == null) {
                    _selectTemplateTargetFileCommand = new RelayCommand(SelectTemplateTargetFile);
                }

                return _selectTemplateTargetFileCommand;
            }
        }

        /// <summary>
        /// </summary>
        public string SourceFolder {
            get { return _sourceFolder; }
            set { this.RaiseAndSetIfChanged(ref _sourceFolder, value); }
        }
        /// <summary>
        /// </summary>
        public string TargetFilePath {
            get { return _targetFilePath; }
            set { this.RaiseAndSetIfChanged(ref _targetFilePath, value); }
        }

        private void CreateTemplate(object param) {
            _templatingService.CreateTemplate(SourceFolder, TargetFilePath, OldProjectName, ReportMessage, null, null, ReportError);
        }

        private void SelectSourceFolder(object param) {
            VistaFolderBrowserDialog folderSelect = new VistaFolderBrowserDialog();
            bool? result = folderSelect.ShowDialog();
            if (result.HasValue && result.Value) {
                SourceFolder = folderSelect.SelectedPath;
            }
        }

        private void SelectTemplateTargetFile(object param) {
            VistaSaveFileDialog saveFile = new VistaSaveFileDialog();
            bool? result = saveFile.ShowDialog();
            if (result.HasValue && result.Value) {
                TargetFilePath = saveFile.FileName;
            }
        }

    }
}