using System.Web;

namespace MagicalShow_4th_HandIn
{
    public class Global : HttpApplication
    {
        public static DatabaseController DB = DatabaseController.getInstance();

        protected void Application_Start()
        {
        }
    }
}
