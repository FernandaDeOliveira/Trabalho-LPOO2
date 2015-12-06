using RotaBus.Core;
using System.Web.Mvc;

namespace RotaBus.Controllers
{
    public class MensalidadeController : Controller
    {
        MensalidadeRepositorio mRepositorio = new MensalidadeRepositorio();
        RotaRepositorio rRepositorio = new RotaRepositorio();

        // GET: Mensalidade
        public ActionResult Index()
        {        
            var mensalidades = mRepositorio.GetAll();
            return View(mensalidades);
        }

        public ActionResult Create()
        {
            //carrega as classificacoes numa viewbag para carregar a select option
            ViewBag.Rotas = rRepositorio.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Mensalidade pMensalidade)
        {
            mRepositorio.Create(pMensalidade);
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var mensalidade = mRepositorio.GetOne(id);
            ViewBag.Rotas = rRepositorio.GetAll();
            return View(mensalidade);
        }
        [HttpPost]
        public ActionResult Update(Mensalidade pMensalidade)
        {
            mRepositorio.Update(pMensalidade);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            mRepositorio.Delete(id);
            return RedirectToAction("Index");
        }
    }
}