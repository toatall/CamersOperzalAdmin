using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CamersOperzalAdmin.Models;

namespace CamersOperzalAdmin.Views
{
    public class CamersController : Controller
    {
        // контекст к базе данных
        private ContextDatabase db = new ContextDatabase();

        // GET: /Camers/
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
        

        // GET: /Camers/Create
        public ActionResult Create(string CodeIfns)
        {
            Ifns ModelIfns = db.TIfns.Find(CodeIfns);
            if (ModelIfns == null)
            {
                return HttpNotFound();
            }

            ViewBag.IfnsCode = new SelectList(db.TIfns, "IfnsCode", "IfnsName");
            General model = new General();
            model.IfnsCode = CodeIfns;
            return View(model);
        }

        // POST: /Camers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IfnsCode,CameraImgLink,CameraImgFile,CameraDisable,CameraDisableDescription,CameraAuthUser,CameraAuthPassword")] General general)
        {
            if (ModelState.IsValid)
            {
                db.TGeneral.Add(general);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return this.Index(general.IfnsCode);
            }

            ViewBag.IfnsCode = new SelectList(db.TIfns, "IfnsCode", "IfnsName", general.IfnsCode);
            return View(general);
        }

        // GET: /Camers/Edit/5
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

        // POST: /Camers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,IfnsCode,CameraImgLink,CameraImgFile,CameraDisable,CameraDisableDescription,CameraAuthUser,CameraAuthPassword")] General general)
        {
            if (ModelState.IsValid)
            {
                db.Entry(general).State = EntityState.Modified;
                db.SaveChanges();
                return this.Index(general.IfnsCode);
                //return RedirectToAction("Index");
            }
            ViewBag.IfnsCode = new SelectList(db.TIfns, "IfnsCode", "IfnsName", general.IfnsCode);
            return View(general);
        }

        // GET: /Camers/Delete/5
        public ActionResult Delete(int? id)
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
            return View(general);
        }

        // POST: /Camers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            General general = db.TGeneral.Find(id);
            string Code = general.IfnsCode;
            db.TGeneral.Remove(general);
            db.SaveChanges();
            return this.Index(Code);           
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
