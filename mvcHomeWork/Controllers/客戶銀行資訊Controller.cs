﻿using System;
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
    public class 客戶銀行資訊Controller : BaseController
    {
     //   private 客戶資料Entities1 db = new 客戶資料Entities1();

        // GET: 客戶銀行資訊
        public ActionResult Index()
        {
            // var 客戶銀行資訊 = db.客戶銀行資訊.Include(客 => 客.客戶資料);
            // return View(客戶銀行資訊.ToList());
            var data = 客戶銀行資訊repo.All().Take(10);
            return View(data);
        }

        // GET: 客戶銀行資訊/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // 客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            客戶銀行資訊 客戶銀行資訊 = 客戶銀行資訊repo.Get單筆資料ById(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Create
        public ActionResult Create()
        {
            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶銀行資訊/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                //db.客戶銀行資訊.Add(客戶銀行資訊);
                //db.SaveChanges();
                客戶銀行資訊repo.Add(客戶銀行資訊);
                客戶銀行資訊repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            //ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // 客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            客戶銀行資訊 客戶銀行資訊 = 客戶銀行資訊repo.Get單筆資料ById(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            //   ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")] 客戶銀行資訊 客戶銀行資訊)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(客戶銀行資訊).State = EntityState.Modified;
                //db.SaveChanges();
                客戶銀行資訊repo.Update(客戶銀行資訊);
                客戶銀行資訊repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: 客戶銀行資訊/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            客戶銀行資訊 客戶銀行資訊 = 客戶銀行資訊repo.Get單筆資料ById(id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: 客戶銀行資訊/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶銀行資訊 客戶銀行資訊 = db.客戶銀行資訊.Find(id);
            //db.客戶銀行資訊.Remove(客戶銀行資訊);
            //db.SaveChanges();
            客戶銀行資訊 客戶銀行資訊 = 客戶銀行資訊repo.Get單筆資料ById(id);
            客戶銀行資訊repo.Delete(客戶銀行資訊);
            客戶銀行資訊repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
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
