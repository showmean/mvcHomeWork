using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcHomeWork.Models;

namespace mvcHomeWork.Controllers
{
    public class 客戶分類Controller : BaseController
    {
        public ActionResult Index()
        {
            var data = 客戶分類repo.All();
            return View(data);
        }

        // GET: 客戶分類/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶分類 客戶分類 = 客戶分類repo.Get單筆資料ById(id.Value);
            if (客戶分類 == null)
            {
                return HttpNotFound();
            }
        //    ViewBag.客戶分類Id = new  SelectList(客戶分類repo.All(), "Id", "客戶分類", 客戶分類.Id);
            return View(客戶分類);
        }

        // GET: 客戶分類/Create
        public ActionResult Create()
        {
            
            //ViewBag.客戶分類Id = new SelectList(客戶分類repo.All(), "Id", "客戶分類");
            return View();
        }

        // POST: 客戶分類/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,分類")] 客戶分類 客戶分類)
        {
            if (ModelState.IsValid)
            {
                客戶分類repo.Add(客戶分類);
                客戶分類repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
           // ViewBag.客戶分類Id = new SelectList(客戶分類repo.All(), "Id", "客戶分類", 客戶分類.Id);
            return View(客戶分類);
        }

        // GET: 客戶分類/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶分類 客戶分類 = 客戶分類repo.Get單筆資料ById(id.Value);
            if (客戶分類 == null)
            {
                return HttpNotFound();
            }
           
            return View(客戶分類);
        }

        // POST: 客戶分類/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,分類")] 客戶分類 客戶分類)
        {
            if (ModelState.IsValid)
            {
                客戶分類repo.Update(客戶分類);
                客戶分類repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
        //    ViewBag.客戶分類Id = new SelectList(客戶分類repo.All(), "Id", "客戶分類", 客戶分類.Id);
            return View(客戶分類);
        }


        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
