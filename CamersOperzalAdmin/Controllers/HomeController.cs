using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamersOperzalAdmin.Models;


namespace CamersOperzalAdmin.Controllers
{
    public class HomeController : Controller
    {
        // контекст к базе данных
        private ContextDatabase db = new ContextDatabase();

        /// <summary>
        /// Главная страница
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {                       
            return View(db.TGeneral.Where(x => x.CameraDisable == false));
        }


        /// <summary>
        /// Статус камеры
        /// </summary>
        /// <param name="Id">Идентификатор камеры</param>
        /// <returns></returns>
        public ActionResult StatusCamera(int? Id)
        {            
            if (Id == null)
            {
                throw new HttpException(400, "Некорректный запрос");
            }

            // получения сведений о камере
            General Camera = db.TGeneral.Find(Id);            
            if (Camera == null)            
                throw new HttpException(400, "Некорректный запрос");

            StatusUrl statusUrl = new StatusUrl(Camera.CameraImgLink, Camera.CameraAuthUser, Camera.CameraAuthPassword);
            ViewBag.Status = statusUrl.Status();            
            return View("_StatusUrl");
        }

        /// <summary>
        /// Страница настроек
        /// </summary>
        /// <returns></returns>
        public ActionResult Setting()
        {                       
            return View(db.TConfiguration.ToList());
        }


        /// <summary>
        /// Сохранение настроек
        /// </summary>
        /// <param name="listConfiguration">Список параметров настроек</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Setting(ICollection<Configuration> listConfiguration)
        {
            if (listConfiguration == null || listConfiguration.Count == 0)
                throw new HttpException(400,"Некорректный запрос");
            
            string errors = "";

            foreach (Configuration configuration in listConfiguration)
            {
                if (db.Entry(configuration).GetValidationResult().IsValid)
                {
                    db.Entry(configuration).State = System.Data.Entity.EntityState.Modified;                
                    db.SaveChanges();                   
                }
                else
                {                    
                    foreach (var s in db.Entry(configuration).GetValidationResult().ValidationErrors)
                    {
                        errors += s.ErrorMessage + " Id: " + configuration.Id + " <br />";
                    }
                }
            }            

            if (errors == "")
            {
                ViewBag.SaveState = "OK";
                ViewBag.StateText = "Данные успешно сохранены!";
            }
            else
            {
                ViewBag.SaveState = "Erorr";
                ViewBag.StateText = errors;
            }

            return this.Setting();
        }


        /// <summary>
        /// Управление камерами (добавление, изменение, удаление)
        /// </summary>
        /// <returns></returns>
        public ActionResult Camera()
        {
            ViewData["Ifns"] = db.TIfns
                .Select(c => new SelectListItem
                {
                    Value = c.IfnsCode,
                    Text = c.IfnsName
                });
            ViewBag.Url = Url.Action("Index", "Camers", new { CodeIfns = "_ifns_" });
            ViewBag.Title = "Управление камерами";
            return View(db.TIfns.ToList());
        }


        /// <summary>
        /// Управление включением/выключением камеры на сайте
        /// </summary>
        /// <returns></returns>
        public ActionResult DisableCamera()
        {
            ViewData["Ifns"] = db.TIfns
                .Select(c => new SelectListItem
                {
                    Value = c.IfnsCode,
                    Text = c.IfnsName
                });
            ViewBag.Url = Url.Action("Index", "CamersDisable", new { CodeIfns = "_ifns_" });
            ViewBag.Title = "Включение и выключение камер";
            return View("Camera", db.TIfns.ToList());
        }
    }
}