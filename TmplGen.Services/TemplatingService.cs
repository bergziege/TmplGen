using System;
using System.IO;
using System.Reflection;

namespace TmplGen.Services {
    /// <summary>
    /// Service für die Templatekonvertierung.
    /// </summary>
    public class TemplatingService {
        private FileService _fileService;
        private string _currentPath;
        private const string WORKSPACE = "workspace";
        private const string INTERNAL_PLACEHOLDER = "zzzzzzzzzzzzzzzz";

        /// <summary>
        /// Ctor.
        /// </summary>
        public TemplatingService() {
            _fileService = new FileService();
            _currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Convertiert den Inhalt des übergebenen Verzeichnisses in ein Template.
        /// Dazu wird in allen nicht Binärdateien die im Platzhalter angegebene Zeichenfolge gesucht
        /// und durch einen eindeutigen Platzhalter ersetzt.
        /// </summary>
        /// <param name="directory">Verzeichnispfad, aus dessen Inhalt ein Template erstellt werden soll</param>
        /// <param name="targetFilePath">Zieldateipfad für das gepackte Template</param>
        /// <param name="placeholder">Der in der Voröage zu suchende Platzhalter</param>
        /// <param name="reportMessage">Aktion zur Ausgabe einer Nachricht (keine Fehlerausgabe)</param>
        /// <param name="reportOverallItems">Aktion zur Ausgabe der Gesamtschritte des Prozesses</param>
        /// <param name="reportItemsDone">Aktion zur Ausgabe der abgeschlossenen Schritte des Prozesses</param>
        /// <param name="reportError">Aktion um Fehler auszugeben</param>
        public void CreateTemplate(string directory, string targetFilePath, string placeholder, Action<string> reportMessage,
                Action<int> reportOverallItems, Action<int> reportItemsDone, Action<string> reportError) {
            /* Verzeichnis nach lokal kopieren */
            _fileService.CheckCreateDir(Path.Combine(_currentPath, WORKSPACE));
            _fileService.CopyTree(directory, Path.Combine(_currentPath, WORKSPACE));

            /* Alle Dateien durchlaufen und Platzhalter suchen/setzen */
            _fileService.SearchAndReplace(Path.Combine(_currentPath, WORKSPACE), placeholder, INTERNAL_PLACEHOLDER);

            /* Kompletten Verzeichnisinhalt packen */
            _fileService.CompressDirContentTo(directory, targetFilePath);

            /* Lokale daten aufräumen */
            _fileService.DeleteDir(directory);
        }

        /// <summary>
        /// Konvertiert ein vorhandenes Template in eine Projektstruktur. Dabei wird der bei der Erstellung vergebene
        /// Platzhalter durch einen neuen Wert ersetzt und alle Dateien des Templates in das übergebene Verzeichnis kopiert.
        /// </summary>
        /// <param name="templateFilePath">Dateipfad zum Template</param>
        /// <param name="targetDirectoryPath">Verzeichnispfad zur Ablage des Projekts</param>
        /// <param name="newName">Wert, der anstelle des Platzhalters verwendet werden soll. Wird ein leerer Wert übergeben, wird der Platzhalter nicht ersetzt.</param>
        /// <param name="reportMessage">Aktion zur Ausgabe einer Nachricht (keine Fehlerausgabe)</param>
        /// <param name="reportOverallItems">Aktion zur Ausgabe der Gesamtschritte des Prozesses</param>
        /// <param name="reportItemsDone">Aktion zur Ausgabe der abgeschlossenen Schritte des Prozesses</param>
        /// <param name="reportError">Aktion um Fehler auszugeben</param>
        public void CreateProject(string templateFilePath, string targetDirectoryPath, string newName,
                Action<string> reportMessage,
                Action<int> reportOverallItems, Action<int> reportItemsDone, Action<string> reportError) {
            /* Template nach lokal entpacken */

            /* Alle Dateien durchlaufen und Platzhalter mit neuem Namen austauschen.
             * Wurde kein neuer Name übergeben, den Platzhalter bestehen lassen */

            /* Alle lokalen Dateien und Zielpfad kopieren */

            /* Lokale Dateien löschen */
        }
    }
}