using System.IO;

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
        /// Kopiert den kompletten Verzeichnisinhalt inkl. Unterverzeichnisse in ein Zielverzeichnis.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public void CopyTree(string source, string target) {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(source, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(source, target));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(source, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(source, target), true);
        }

        /// <summary>
        /// Ersetzt in allen Textdateien und Verzeichnissen den Suchwert.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="search"></param>
        /// <param name="replace"></param>
        public void SearchAndReplace(string directory, string search, string replace) {

            /* Alle Verzeichnisse durchsuchen und umbenennen */
            foreach (string dirPath in Directory.GetDirectories(directory,
                    "*",
                    SearchOption.AllDirectories)) {
                string dir = dirPath;
                if (!dir.EndsWith(Path.DirectorySeparatorChar.ToString())) {
                    dir += Path.DirectorySeparatorChar;
                }
                string lastFolderName = Path.GetFileName(Path.GetDirectoryName(dir));
                if (lastFolderName != null && lastFolderName.Contains(search)) {
                    DirectoryInfo parentDir = new DirectoryInfo(directory).Parent;
                    Directory.Move(directory, Path.Combine(parentDir.FullName, lastFolderName.Replace(search, replace)));
                }
            }

            /* Alle Dateien in den Verzeichnissen durchsuchen und Dateinamen durchsuchen und ggf ersetzen. */
            foreach (string path in Directory.GetFiles(directory,
                    "*.*",
                    SearchOption.AllDirectories)) {
                FileInfo file = new FileInfo(path);
                if (file.Name.Contains(search)) {
                    File.Move(file.FullName, Path.Combine(file.DirectoryName, file.Name.Replace(search, replace)));
                }
            }

            /* Alle Dateinhalte durchsuchen und ggf ersetzen. */
            foreach (string newPath in Directory.GetFiles(directory,
                    "*.*",
                    SearchOption.AllDirectories)) {
                
            }

        }
    

        /// <summary>
        /// ZIP komprimiert den Inhalt des übergebenen Verzeichnisses in die übergebene Datei.
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="targetFilePath"></param>
        public void CompressDirContentTo(string directory, string targetFilePath) {
        }

        /// <summary>
        /// Löscht das angegebene Verzeichnis und den kompletten Inhalt.
        /// </summary>
        /// <param name="directory"></param>
        public void DeleteDir(string directory) {
        }
    }
}