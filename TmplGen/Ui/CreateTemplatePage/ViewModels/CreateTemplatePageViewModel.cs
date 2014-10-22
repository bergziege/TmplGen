using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using De.BerndNet2000.TmplGen.Properties;
using De.BerndNet2000.TmplGen.Ui.Common;
using De.BerndNet2000.TmplGen.Ui.Common.ViewModels;

using FirstFloor.ModernUI.Presentation;

using Ookii.Dialogs.Wpf;

using ReactiveUI;

using TmplGen.Services;
using TmplGen.Services.Helper;

namespace De.BerndNet2000.TmplGen.Ui.CreateTemplatePage.ViewModels {
    /// <summary>
    /// </summary>
    public class CreateTemplatePageViewModel : ReportingBaseViewModel, ICreateTemplatePageViewModel {
        private readonly TemplatingService _templatingService;
        private RelayCommand _createTemplateCommand;
        private string _oldProjectName;
        private RelayCommand _selectSourceFolderCommand;

        private RelayCommand _selectTemplateTargetFileCommand;
        private string _sourceFolder;
        private string _targetFilePath;

        /// <summary>
        ///     Ctor.
        /// </summary>
        public CreateTemplatePageViewModel() {
            _templatingService = new TemplatingService();
        }

        /// <summary>
        /// </summary>
        public RelayCommand CreateTemplateCommand {
            get {
                if (_createTemplateCommand == null) {
                    _createTemplateCommand = new RelayCommand(CreateTemplate, CanCreateTemplate);
                }

                return _createTemplateCommand;
            }
        }

        /// <summary>
        /// </summary>
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

        private bool CanCreateTemplate(object arg) {
            return !string.IsNullOrWhiteSpace(SourceFolder) && !string.IsNullOrWhiteSpace(TargetFilePath)
                   && !string.IsNullOrWhiteSpace(OldProjectName) && !IsProcessing;
        }

        private async void CreateTemplate(object param) {
            IsProcessing = true;
            await TaskHelper.ToTask(() => _templatingService.CreateTemplateAsync(SourceFolder,
                    TargetFilePath,
                    OldProjectName,
                    Settings.Default.FileExtensionWhitelist.Cast<string>().ToList(),
                    ReportMessage,
                    null,
                    null,
                    ReportError));
            IsProcessing = false;
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