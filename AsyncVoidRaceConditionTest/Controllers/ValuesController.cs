using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;

namespace AsyncVoidRaceConditionTest.Controllers
{
    public class ValuesController : ApiController
    {
        public IHttpActionResult Post([FromBody] string value)
        {
            Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} Entering POST");
            bool result = RegularMethod();
            Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} Exiting POST");
            return Json(result);
        }

        private bool RegularMethod()
        {
            Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} Entering RegularMethod");
            AsyncVoidMethod();
            Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} Exiting RegularMethod");
            return true;
        }

        private async void AsyncVoidMethod()
        {
            Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} Entering AsyncVoidMethod");
            await Task.Delay(2000);
            Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} Exiting AsyncVoidMethod");
        }

        public void Put(int id, [FromBody] string value)
        {
            Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} Entering PUT");
        }
    }
}
