using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcHomeWork.Models;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.IO;

namespace mvcHomeWork.Controllers
{
    public class 客戶聯絡人Controller : BaseController
    {
       // private 客戶資料Entities1 db = new 客戶資料Entities1();

        // GET: 客戶聯絡人
        public ActionResult Index()
        {
            //  var 客戶聯絡人 = db.客戶聯絡人.Include(客 => 客.客戶資料);

            //var 客戶聯絡人 = db.客戶聯絡人
            //                                .Where(p => p.是否已刪除 == false).Take(20);
            //return View(客戶聯絡人.ToList());

            var data = 客戶聯絡人repo.All().Take(10);
            return View(data);
        }

        // GET: 客戶聯絡人/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            //var 客戶聯絡人 = db.客戶聯絡人
            //                                 .Where(p => p.是否已刪除 == false && p.Id == id);

            客戶聯絡人 客戶聯絡人 = 客戶聯絡人repo.Get單筆資料ById(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱");
            return View();
        }

        // POST: 客戶聯絡人/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                //db.客戶聯絡人.Add(客戶聯絡人);
                //db.SaveChanges();
                客戶聯絡人repo.Add(客戶聯絡人);
                客戶聯絡人repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = 客戶聯絡人repo.Get單筆資料ById(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(客戶聯絡人).State = EntityState.Modified;
                //db.SaveChanges();
                客戶聯絡人repo.Update(客戶聯絡人);
                客戶聯絡人repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(客戶資料repo.All(), "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: 客戶聯絡人/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            客戶聯絡人 客戶聯絡人 = 客戶聯絡人repo.Get單筆資料ById(id.Value);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: 客戶聯絡人/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            //// db.客戶聯絡人.Remove(客戶聯絡人);
            //客戶聯絡人.是否已刪除 = true;
            //    db.SaveChanges();

            客戶聯絡人 客戶聯絡人 = 客戶聯絡人repo.Get單筆資料ById(id);
            客戶聯絡人repo.Delete(客戶聯絡人);
            客戶聯絡人repo.UnitOfWork.Commit();
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


        public JsonResult 檢查Email是否存在(string Email, int 客戶Id, int? Id)
        {
            
            var result = true;
            // var user = db.客戶聯絡人
            var user = 客戶聯絡人repo.All()
                    .Where(x => x.Email.ToLower() == Email.ToLower()
                    && x.客戶Id == 客戶Id && x.Id!=Id)
                .FirstOrDefault();
            if (user != null)
                result = false;

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Excel()
        {
                XLWorkbook wb = new XLWorkbook();
                var data = 客戶聯絡人repo.All().Select(c => new { c.姓名, c.職稱, c.客戶資料, c.電話, c.手機,c.Email });
                var ws = wb.Worksheets.Add("客戶聯絡人", 1);
                ws.Cell(1, 1).Value = "姓名";
                ws.Cell(1, 2).Value = "職稱";
                ws.Cell(1, 3).Value = "客戶資料";
                ws.Cell(1, 4).Value = "電話";
                ws.Cell(1, 5).Value = "手機";
                ws.Cell(1, 6).Value = "Email";
                ws.Cell(2, 1).InsertData(data);
                MemoryStream memoryStream = new MemoryStream();
                wb.SaveAs(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return File(memoryStream.ToArray(), "application/vnd.ms-excel", "Download.xlsx");
        }
    }
}
