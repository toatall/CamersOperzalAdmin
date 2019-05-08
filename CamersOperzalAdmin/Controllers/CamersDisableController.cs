using System;   
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CamersOperzalAdmin.Models;

namespace CamersOperzalAdmin.Controllers
{
    public class CamersDisableController : Controller
    {
        // контекст к базе данных
        private ContextDatabase db = new ContextDatabase();

        // GET: /CamersDisable/
        public ActionResult Index(string CodeIfns)
        {
            if (CodeIfns == null || CodeIfns.ToString().Trim() == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tgeneral = db.TGeneral.Include(g => g.Ifns).Where(x => x.IfnsCode == CodeIfns);
            ViewBag.CodeIfns = CodeIfns; 
            return View("Index", tgeneral.ToList());
        }                       

        // GET: /CamersDisable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            General general = db.TGeneral.Find(id);
            if (general == null)
            {
                return HttpNotFound();
            }
            ViewBag.IfnsCode = new SelectList(db.TIfns, "IfnsCode", "IfnsName", general.IfnsCode);
            return View(general);
        }

        // POST: /CamersDisable/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CameraDisable,CameraDisableDescription")] General general)
        {            
            //if (ModelState.IsValid)
            if (general != null)
            {
                General modelGeneral = db.TGeneral.Find(general.Id);
                modelGeneral.CameraDisable = general.CameraDisable;
                modelGeneral.CameraDisableDescription = general.CameraDisableDescription;

                db.TGeneral.Attach(modelGeneral);
                db.Entry(modelGeneral).Property(x => x.CameraDisable).IsModified = true;
                db.Entry(modelGeneral).Property(x => x.CameraDisableDescription).IsModified = true;
                db.SaveChanges();
                return this.Index(modelGeneral.IfnsCode);                
            }
            ViewBag.IfnsCode = new SelectList(db.TIfns, "IfnsCode", "IfnsName", general.IfnsCode);
            if (general != null)
                ViewBag.g = general;
            return View(general);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
