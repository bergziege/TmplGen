﻿using System.Linq;

using De.BerndNet2000.TmplGen.Properties;
using De.BerndNet2000.TmplGen.Ui.Common.ViewModels;

using FirstFloor.ModernUI.Presentation;

using Ookii.Dialogs.Wpf;

using ReactiveUI;

using TmplGen.Services;
using TmplGen.Services.Helper;

namespace De.BerndNet2000.TmplGen.Ui.CreateProjectPage.ViewModels {
    /// <summary>
    /// </summary>
    public class CreateProjectPageViewModel : ReportingBaseViewModel, ICreateProjectPageViewModel {
        private readonly TemplatingService _templatingService;
        private RelayCommand _createProjectCommand;
        private string _newProjectName;
        private string _projectTargetFolder;
        private RelayCommand _selectProjectTargetFolderCommand;
        private RelayCommand _selectTemplateSourceFileCommand;
        private string _templateSourceFile;

        /// <summary>
        /// </summary>
        public CreateProjectPageViewModel() {
            _templatingService = new TemplatingService();
        }

        /// <summary>
        /// </summary>
        public RelayCommand CreateProjectCommand {
            get {
                if (_createProjectCommand == null) {
                    _createProjectCommand = new RelayCommand(CreateProject, CanCreateProject);
                }

                return _createProjectCommand;
            }
        }

        /// <summary>
        /// </summary>
        public string NewProjectName {
            get { return _newProjectName; }
            set { this.RaiseAndSetIfChanged(ref _newProjectName, value); }
        }
        /// <summary>
        /// </summary>
        public string ProjectTargetFolder {
            get { return _projectTargetFolder; }
            set { this.RaiseAndSetIfChanged(ref _projectTargetFolder, value); }
        }
        /// <summary>
        /// </summary>
        public RelayCommand SelectProjectTargetFolderCommand {
            get {
                if (_selectProjectTargetFolderCommand == null) {
                    _selectProjectTargetFolderCommand = new RelayCommand(SelectProjectTargetFolder);
                }

                return _selectProjectTargetFolderCommand;
            }
        }

        /// <summary>
        /// </summary>
        public RelayCommand SelectTemplateSourceFileCommand {
            get {
                if (_selectTemplateSourceFileCommand == null) {
                    _selectTemplateSourceFileCommand = new RelayCommand(SelectTemplateSourceFile);
                }

                return _selectTemplateSourceFileCommand;
            }
        }

        /// <summary>
        /// </summary>
        public string TemplateSourceFile {
            get { return _templateSourceFile; }
            set { this.RaiseAndSetIfChanged(ref _templateSourceFile, value); }
        }

        private bool CanCreateProject(object arg) {
            return !string.IsNullOrWhiteSpace(NewProjectName) && !string.IsNullOrWhiteSpace(ProjectTargetFolder)
                   && !string.IsNullOrWhiteSpace(TemplateSourceFile) && !IsProcessing;
        }

        private async void CreateProject(object param) {
            IsProcessing = true;
            await TaskHelper.ToTask(() => _templatingService.CreateProjectAsync(TemplateSourceFile,
                    ProjectTargetFolder,
                    NewProjectName, Settings.Default.FileExtensionWhitelist.Cast<string>().ToList(),
                    ReportMessage,
                    null,
                    null,
                    ReportError));
            IsProcessing = false;
        }

        private void SelectProjectTargetFolder(object param) {
            VistaFolderBrowserDialog folderSelect = new VistaFolderBrowserDialog();
            bool? result = folderSelect.ShowDialog();
            if (result.HasValue && result.Value) {
                ProjectTargetFolder = folderSelect.SelectedPath;
            }
        }

        private void SelectTemplateSourceFile(object param) {
            VistaOpenFileDialog selectFile = new VistaOpenFileDialog();
            bool? result = selectFile.ShowDialog();
            if (result.HasValue && result.Value) {
                TemplateSourceFile = selectFile.FileName;
            }
        }
    }
}