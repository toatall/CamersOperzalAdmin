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
    public class IfnsController : Controller
    {
        // контекст к базе данных
        private ContextDatabase db = new ContextDatabase();

        // GET: /Ifns/
        public ActionResult Index()
        {
            return View(db.TIfns.OrderBy(x => x.Order).ToList());
        }
       

        // GET: /Ifns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ifns/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IfnsCode,IfnsName,Order")] Ifns ifns)
        {
            if (ModelState.IsValid)
            {
                db.TIfns.Add(ifns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ifns);
        }

        // GET: /Ifns/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ifns camers_operzal_ifns = db.TIfns.Find(id);
            if (camers_operzal_ifns == null)
            {
                return HttpNotFound();
            }
            return View(camers_operzal_ifns);
        }

        // POST: /Ifns/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IfnsCode,IfnsName,Order")] Ifns ifns)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ifns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ifns);
        }

        // GET: /Ifns/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ifns ifns = db.TIfns.Find(id);
            if (ifns == null)
            {
                return HttpNotFound();
            }
            return View(ifns);
        }

        // POST: /Ifns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ifns ifns = db.TIfns.Find(id);
            db.TIfns.Remove(ifns);
            db.SaveChanges();
            return RedirectToAction("Index");
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
