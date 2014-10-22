using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using TmplGen.Services.Helper;

namespace TmplGen.Services {
    /// <summary>
    ///     Service für die Templatekonvertierung.
    /// </summary>
    public class TemplatingService {
        private const string INTERNAL_PLACEHOLDER = "___tmplgen___";
        private const string WORKSPACE = "workspace";
        private readonly string _currentPath;
        private readonly FileService _fileService;

        /// <summary>
        ///     Ctor.
        /// </summary>
        public TemplatingService() {
            _fileService = new FileService();
            _currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        ///     Konvertiert ein vorhandenes Template in eine Projektstruktur. Dabei wird der bei der Erstellung vergebene
        ///     Platzhalter durch einen neuen Wert ersetzt und alle Dateien des Templates in das übergebene Verzeichnis kopiert.
        /// </summary>
        /// <param name="templateFilePath">Dateipfad zum Template</param>
        /// <param name="targetDirectoryPath">Verzeichnispfad zur Ablage des Projekts</param>
        /// <param name="newName">
        ///     Wert, der anstelle des Platzhalters verwendet werden soll. Wird ein leerer Wert übergeben, wird
        ///     der Platzhalter nicht ersetzt.
        /// </param>
        /// <param name="extensions"></param>
        /// <param name="reportMessage">Aktion zur Ausgabe einer Nachricht (keine Fehlerausgabe)</param>
        /// <param name="reportOverallItems">Aktion zur Ausgabe der Gesamtschritte des Prozesses</param>
        /// <param name="reportItemsDone">Aktion zur Ausgabe der abgeschlossenen Schritte des Prozesses</param>
        /// <param name="reportError">Aktion um Fehler auszugeben</param>
        public async void CreateProjectAsync(string templateFilePath, string targetDirectoryPath, string newName, IList<string> extensions, Action<string> reportMessage, Action<int> reportOverallItems, Action<int> reportItemsDone, Action<string> reportError) {
            try {
                /* Template in Workspace entpacken */
                reportMessage.Invoke("Zip in Workspace entpacken");
                await TaskHelper.ToTask(() => _fileService.ExtractToDirectory(templateFilePath, GetWorkspace()));

                /* Alle Dateien holen */
                reportMessage.Invoke("Alle entpackten Dateien analysieren");
                IList<string> files = await TaskHelper.ToTask(() => _fileService.GetFilesFromDirectory(GetWorkspace()));

                /* Inhalte der Dateien durchsuchen und ersetzen */
                reportMessage.Invoke("Inhalte durchsuchen und ersetzen");
                await TaskHelper.ToTask(() => _fileService.ReplaceInFiles(INTERNAL_PLACEHOLDER, newName, files, extensions));

                /* CopyTable erstellen */
                reportMessage.Invoke("Neue Zielpfade erzeugen");
                Dictionary<string, string> copyTable = new Dictionary<string, string>();
                foreach (string templateFile in files) {
                    string template = templateFile;
                    if (template.StartsWith(GetWorkspace())) {
                        template = templateFile.Remove(0, GetWorkspace().Length);
                    }

                    string replacedPath = template.Replace(INTERNAL_PLACEHOLDER, newName);

                    if (replacedPath.StartsWith(Path.DirectorySeparatorChar.ToString())) {
                        replacedPath = replacedPath.Remove(0, Path.DirectorySeparatorChar.ToString().Length);
                    }

                    string newPath = Path.Combine(targetDirectoryPath, replacedPath);
                    copyTable.Add(templateFile, newPath);
                }

                /* Alle lokalen Dateien und Zielpfad kopieren */
                reportMessage.Invoke("Dateien in Zielpfade kopieren");
                await TaskHelper.ToTask(() => _fileService.CopyFiles(copyTable));

                /* Lokale Dateien löschen */
                reportMessage.Invoke("Workspace aufräumen");
                await TaskHelper.ToTask(() => _fileService.DeleteDir(GetWorkspace()));
            } catch (Exception ex) {
                reportError.Invoke("Fehler: " + ex.Message + Environment.NewLine
                                   + "Workspace bleibt zur Fehleranalyse bestehen");
            }
        }

        /// <summary>
        ///     Convertiert den Inhalt des übergebenen Verzeichnisses in ein Template.
        ///     Dazu wird in allen nicht Binärdateien die im Platzhalter angegebene Zeichenfolge gesucht
        ///     und durch einen eindeutigen Platzhalter ersetzt.
        /// </summary>
        /// <param name="directory">Verzeichnispfad, aus dessen Inhalt ein Template erstellt werden soll</param>
        /// <param name="targetFilePath">Zieldateipfad für das gepackte Template</param>
        /// <param name="placeholder">Der in der Voröage zu suchende Platzhalter</param>
        /// <param name="extensions"></param>
        /// <param name="reportMessage">Aktion zur Ausgabe einer Nachricht (keine Fehlerausgabe)</param>
        /// <param name="reportOverallItems">Aktion zur Ausgabe der Gesamtschritte des Prozesses</param>
        /// <param name="reportItemsDone">Aktion zur Ausgabe der abgeschlossenen Schritte des Prozesses</param>
        /// <param name="reportError">Aktion um Fehler auszugeben</param>
        public async void CreateTemplateAsync(string directory, string targetFilePath, string placeholder, IList<string> extensions, Action<string> reportMessage,
                Action<int> reportOverallItems, Action<int> reportItemsDone, Action<string> reportError) {
            try {
                /* Workspace anlegen */
                reportMessage.Invoke("Workspace anlegen");
                await TaskHelper.ToTask(() => _fileService.CheckCreateDir(GetWorkspace()));

                /* Alle Dateien des Quellverzeichnisses holen */
                reportMessage.Invoke("Alle Dateien des Quellverzeichnisses lesen");
                IList<string> files = await TaskHelper.ToTask(() => _fileService.GetFilesFromDirectory(directory));

                /* Alle Quelldateien in ein Dictionary überführen und in diesem die Werte ersetzen.
                         * Es müsste sich also am Ende eine Tabelle mit alten und neuen Pfaden ergeben. */
                reportMessage.Invoke("Suchen und Ersetzen in Pfaden");
                Dictionary<string, string> copyTable = new Dictionary<string, string>();
                foreach (string sourceFile in files) {
                    string source = sourceFile;
                    if (source.StartsWith(directory)) {
                        source = sourceFile.Remove(0, directory.Length);
                    }
                    string workspace = GetWorkspace();
                    string replacedPath = source.Replace(placeholder, INTERNAL_PLACEHOLDER);
                    if (replacedPath.StartsWith(Path.DirectorySeparatorChar.ToString())) {
                        replacedPath = replacedPath.Remove(0, Path.DirectorySeparatorChar.ToString().Length);
                    }
                    string newPath = Path.Combine(workspace, replacedPath);
                    copyTable.Add(sourceFile, newPath);
                }

                /* Alle Dateien nach der Übersetzung in den Workspace kopieren */
                reportMessage.Invoke("Dateien nach neuen Pfaden in Workspace kopieren");
                await TaskHelper.ToTask(() => _fileService.CopyFiles(copyTable));

                /* Inhalte der Dateien durchsuchen und ersetzen */
                reportMessage.Invoke("In Dateininhalten suchenund ersetzen");
                await TaskHelper.ToTask(() => _fileService.ReplaceInFiles(placeholder, INTERNAL_PLACEHOLDER, copyTable.Select(x => x.Value).ToList(), extensions));

                /* Kompletten Verzeichnisinhalt packen */
                reportMessage.Invoke("Workspace packen und abspeichern");
                await TaskHelper.ToTask(() => _fileService.CompressDirContentTo(GetWorkspace(), targetFilePath));

                /* Lokale daten aufräumen */
                reportMessage.Invoke("Workspace aufräumen");
                await TaskHelper.ToTask(() => _fileService.DeleteDir(GetWorkspace()));
            } catch (Exception ex) {
                reportError.Invoke("Fehler: " + ex.Message + Environment.NewLine
                                   + "Workspace bleibt zur Fehleranalyse bestehen");
            }
        }

        private string GetWorkspace() {
            return Path.Combine(_currentPath, WORKSPACE);
        }
    }
}