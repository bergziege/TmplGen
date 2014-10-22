using System.Collections.Generic;
using System.IO;
using System.Linq;

using Ionic.Zip;

using Microsoft.SqlServer.Server;

namespace TmplGen.Services {
    /// <summary>
    /// Service für Dateioperationen
    /// </summary>
    public class FileService {

        /// <summary>
        /// Erstellt das übergebene Verzeichnis, wenn es noch nicht existiert.
        /// </summary>
        /// <param name="directory"></param>
        public void CheckCreateDir(string directory) {
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
        }

        /// <summary>
        /// Liefert eine Liste aller in einem Verzeichnis und dessen Unterverzeichnissen enthaltenen Dateien.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public IList<string> GetFilesFromDirectory(string directory) {
            return Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
        }

        /// <summary>
        /// ZIP komprimiert den Inhalt des übergebenen Verzeichnisses in die übergebene Datei.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="targetFilePath"></param>
        public void CompressDirContentTo(string directory, string targetFilePath) {
            using (var zip = new Ionic.Zip.ZipFile()) {
                zip.AddDirectory(directory, "");
                zip.Save(targetFilePath);
            }
        }

        /// <summary>
        /// Löscht das angegebene Verzeichnis und den kompletten Inhalt.
        /// </summary>
        /// <param name="directory"></param>
        public void DeleteDir(string directory) {
            if (Directory.Exists(directory)) {
                Directory.Delete(directory,true); 
            }
        }

        /// <summary>
        /// Kopiert alle Dateien, sofern sie existieren, vom Ausgangspunkt zum neuen Zielverzeichnis
        /// </summary>
        /// <param name="copyTable"></param>
        public void CopyFiles(Dictionary<string, string> copyTable) {
            foreach (KeyValuePair<string, string> sourceTarget in copyTable.Where(sourceTarget => File.Exists(sourceTarget.Key))) {
                if (!Directory.Exists(Path.GetDirectoryName(sourceTarget.Value))) {
                    Directory.CreateDirectory(Path.GetDirectoryName(sourceTarget.Value));
                }
                File.Copy(sourceTarget.Key, sourceTarget.Value,true);
            }
        }

        /// <summary>
        /// Sucht und Ersetzt in Inhalte von Ascii Files in den übergebenen Dateien.
        /// </summary>
        /// <param name="placeholder"></param>
        /// <param name="internalPlaceholder"></param>
        /// <param name="files"></param>
        /// <param name="extensions"></param>
        public void ReplaceInFiles(string placeholder, string internalPlaceholder, IEnumerable<string> files, IList<string> extensions) {
            foreach (string file in files.Where(File.Exists)) {
                string extension = Path.GetExtension(file);
                if (extension != null && extension.StartsWith(".")) {
                    extension = extension.TrimStart('.');
                }
                if (extensions.Contains(extension)) {
                    string text = File.ReadAllText(file);
                    text = text.Replace(placeholder, internalPlaceholder);
                    File.WriteAllText(file, text);
                }
                
            }
        }

        /// <summary>
        /// Entpackt die übergebene ZIP in das angegebene Verzeichnis.
        /// </summary>
        /// <param name="templateFilePath"></param>
        /// <param name="workspace"></param>
        public void ExtractToDirectory(string templateFilePath, string workspace) {
            if (!Directory.Exists(workspace)) {
                Directory.CreateDirectory(workspace);
            }
            using (var zip = ZipFile.Read(templateFilePath)) {
                zip.ExtractAll(workspace);
            }
        }
    }
}