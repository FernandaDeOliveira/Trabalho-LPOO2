using RotaBus.Core;
using RotaBus.Repository;
using System.Web.Mvc;

namespace RotaBus.Controllers
{
    public class RotaController : Controller
    {
        RotaRepositorio rRepositorio = new RotaRepositorio();
        MotoristaRepositorio mRepositorio = new MotoristaRepositorio();
        // GET: Rota
        public ActionResult Index()
        {
            var rotas = rRepositorio.GetAll();
            return View(rotas);
        }

        public ActionResult Create()
        {
            //carrega as classificacoes numa viewbag para carregar a select option
            ViewBag.Motoristas = mRepositorio.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Rota pRota)
        {
            rRepositorio.Create(pRota);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var rota = rRepositorio.GetOne(id);
            ViewBag.Motoristas = mRepositorio.GetAll();
            return View(rota);
        }
        [HttpPost]
        public ActionResult Update(Rota pRota)
        {
            rRepositorio.Update(pRota);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            rRepositorio.Delete(id);
            return RedirectToAction("Index");
        }
    }
}