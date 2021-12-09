using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projet_Apside_TOP.Models;

namespace Projet_Apside_TOP.Controllers
{
    public class HomeController : Controller
    {
        private Db_pEntities db = new Db_pEntities();

        public ActionResult Index()
        {
            return View(db.Sauveteurs.ToList());
        }

            [HttpPost]
            public JsonResult Ajout_Sauveteurs(FormCollection fc)
            {
                string nom = fc.Get("nom");
                string email = fc.Get("email");
                string adresse = fc.Get("adresse");
                string telephone = fc.Get("telephone");
                Sauveteurs Sv = new Sauveteurs();
                Sv.Nom = nom;
                Sv.Email = email;
                Sv.Adresse = adresse;
                Sv.Telephone = telephone;
                db.Sauveteurs.Add(Sv);
                db.SaveChanges();
                return Json("success");
            }
        public JsonResult Delete(int id)
        {
            Sauveteurs d = db.Sauveteurs.Where(m => m.Id_sauveteurs == id).FirstOrDefault<Sauveteurs>();
            db.Sauveteurs.Remove(d);
            db.SaveChanges();
            return Json("success", JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult Edit_Sauveteurs(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var de = db.Sauveteurs.Where(model => model.Id_sauveteurs == id).FirstOrDefault<Sauveteurs>();
            return Json(de, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Updat_Sauveteurs(FormCollection fc)
        {
            int id_sauvv = int.Parse(fc.Get("id_sauv"));
            string nom = fc.Get("nomm");
            string email = fc.Get("emaill");
            string adresse = fc.Get("adressee");
            string telephone = fc.Get("teelephone");

            var me = db.Sauveteurs.Single(a => a.Id_sauveteurs == id_sauvv);

            me.Nom = nom;
            me.Email = email;
            me.Adresse = adresse;
            me.Telephone = telephone;

            db.Entry(me).State = EntityState.Modified;
            db.SaveChanges();

            return Json("success", JsonRequestBehavior.AllowGet);
        }

    }
    }