using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TmplGen.Services.Test {
    [TestClass]
    public class TemplatingServiceTest {
        [TestMethod]
        public void TestTemplify() {
            TemplatingService service = new TemplatingService();
            service.CreateTemplateAsync("./Testdata",
                    "./template.zip",
                    "MyProject",
                    ReportMessage,
                    ReportOverallItems,
                    ReportItemsDone,
                    ReportError);
        }

        private void ReportError(string obj) {
        }

        private void ReportItemsDone(int obj) {
        }

        private void ReportMessage(string obj) {
        }

        private void ReportOverallItems(int obj) {
        }
    }
}