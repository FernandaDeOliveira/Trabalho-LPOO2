using RotaBus.Core;
using RotaBus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RotaBus.Services.Controllers
{
    public class MotoristaController : Controller
    {
        
            MotoristaRepositorio mRepository = new MotoristaRepositorio();
           // ClassificacaoRepository cRepository = new ClassificacaoRepository();
            // GET: 
            public ActionResult Index()
            {
                var motoristas = mRepository.GetAll();
                return View(motoristas);
            }

            public ActionResult Create()
            {
                
                ViewBag.Motoristas = mRepository.GetAll();

                return View();
            }
            [HttpPost]
            public ActionResult Create(Motorista pMotorista)
            {
                mRepository.Create(pMotorista);
                return RedirectToAction("Index");
            }

            public ActionResult Update(int id)
            {
                //carrega as classificacoes numa viewbag para carregar a select option
              //  ViewBag.Classificacoes = cRepository.GetAll();
                var moto = mRepository.GetOne(id);
                return View(moto);
            }

            [HttpPost]
            public ActionResult Update(Motorista    pMotorista)
            {
                mRepository.Update(pMotorista);
                return RedirectToAction("Index");
            }

            public ActionResult Delete(int id)
            {
                mRepository.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }