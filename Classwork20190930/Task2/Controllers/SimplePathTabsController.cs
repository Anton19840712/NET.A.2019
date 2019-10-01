using System.Linq;
using System.Web.Mvc;

namespace Task2.Controllers
{
    public class SimplePathTabsController : Controller
    {
        private FotoPathEntities db = new FotoPathEntities();

        // GET: SimplePathTabs
        public ActionResult Index()
        {
            return View(db.SimplePathTabs.ToList());
        }

        // GET: SimplePathTabs/Details/5
        public ActionResult Create()
        {
            return View(db.SimplePathTabs.ToList());
        }
    }
}
