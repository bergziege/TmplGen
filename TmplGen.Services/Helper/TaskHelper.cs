using System;
using System.Threading.Tasks;

namespace TmplGen.Services.Helper {
    /// <summary>
    ///     Statische Klasse mit Hilfsfunktionen für Tasks
    ///     Bsp.:
    /// 
    ///     public async void InitAsync() {
    ///       string loadedData = await TaskHelper.ToTask<string>(DoStringStuff);
    ///     }
    /// 
    ///     private string DoStringStuff() {
    ///       Thread.Sleep(1000);
    ///       return "verschlafener text";
    ///     }
    /// 
    /// </summary>
    public static class TaskHelper {

        /// <summary>
        /// Führt die übergebene Funktion in einem Task aus.
        /// </summary>
        /// <typeparam name="T">Typ des Rückgabewerten der Funktion</typeparam>
        /// <param name="toRunInTask">Im Task auszuführende Funktion</param>
        /// <param name="taskScheduler">Optionaler Task Scheduler</param>
        /// <param name="startTask">Optional ob der Task gestartet werden soll</param>
        /// <returns></returns>
        public static Task<T> ToTask<T>(Func<T> toRunInTask, TaskScheduler taskScheduler = null, bool startTask = true) {
            if (taskScheduler == null) {
                taskScheduler = TaskScheduler.Default;
            }
            Task<T> task = new Task<T>(toRunInTask);
            if (startTask) {
                task.Start(taskScheduler);
            }
            return task;
        }

        /// <summary>
        /// Führt die übergebene Aktion in einem Task aus.
        /// </summary>
        /// <typeparam name="T">Typ des Rückgabewerten der Aktion</typeparam>
        /// <param name="toRunInTask">Im Task auszuführende Aktion</param>
        /// <param name="taskScheduler">Optionaler Task Scheduler</param>
        /// <param name="startTask">Optional ob der Task gestartet werden soll</param>
        /// <returns></returns>
        public static Task ToTask(Action toRunInTask, TaskScheduler taskScheduler = null, bool startTask = true) {
            if (taskScheduler == null) {
                taskScheduler = TaskScheduler.Default;
            }
            Task task = new Task(toRunInTask);
            if (startTask) {
                task.Start(taskScheduler);
            }
            return task;
        }
    }
}