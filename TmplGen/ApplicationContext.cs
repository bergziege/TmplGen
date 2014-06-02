using System.Threading.Tasks;

namespace De.BerndNet2000.TmplGen {
    public class ApplicationContext {
        private static readonly ApplicationContext instance = new ApplicationContext();
        private TaskScheduler _syncContext;

        static ApplicationContext() {
        }

        private ApplicationContext() {
        }

        public static ApplicationContext Instance {
            get { return instance; }
        }

        public TaskScheduler SyncContext {
            get { return _syncContext; }
            set { _syncContext = value; }
        }
    }
}