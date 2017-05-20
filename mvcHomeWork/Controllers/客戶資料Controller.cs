using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcHomeWork.Models;
using ClosedXML.Excel;
using System.IO;

namespace mvcHomeWork.Controllers
{
    public class 客戶資料Controller : BaseController
    {
     //   private 客戶資料Entities1 db = new 客戶資料Entities1();

        // GET: 客戶資料
        public ActionResult Index()
        {
            //return View(db.客戶資料.ToList());

            var data = 客戶資料repo.All().Take(10);
            return View(data);
        }

        // GET: 客戶資料/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = 客戶資料repo.Get單筆資料ById(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: 客戶資料/Create
        public ActionResult Create()
        {
            ViewBag.客戶分類Id = new SelectList(客戶分類repo.All(), "Id", "分類");
            return View();
        }

        // POST: 客戶資料/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶分類Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                //db.客戶資料.Add(客戶資料);
                //db.SaveChanges();
                客戶資料repo.Add(客戶資料);
                客戶資料repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶分類Id = new SelectList(客戶分類repo.All(), "Id", "分類", 客戶資料.客戶分類Id);
            return View(客戶資料);
        }

        // GET: 客戶資料/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = 客戶資料repo.Get單筆資料ById(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶分類Id = new SelectList(客戶分類repo.All(), "Id", "分類", 客戶資料.客戶分類Id);
            return View(客戶資料);
        }

        // POST: 客戶資料/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶分類Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(客戶資料).State = EntityState.Modified;
                //db.SaveChanges();
                客戶資料repo.Update(客戶資料);
                客戶資料repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶分類Id = new SelectList(客戶分類repo.All(), "Id", "分類", 客戶資料.客戶分類Id);
            return View(客戶資料);
        }

        // GET: 客戶資料/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //  客戶資料 客戶資料 = db.客戶資料.Find(id);
            客戶資料 客戶資料 = 客戶資料repo.Get單筆資料ById(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶分類Id = new SelectList(客戶分類repo.All(), "Id", "分類", 客戶資料.客戶分類Id);
            return View(客戶資料);
        }

        // POST: 客戶資料/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // 客戶資料 客戶資料 = db.客戶資料.Find(id);
            //db.客戶資料.Remove(客戶資料);
            //db.SaveChanges();
            客戶資料 客戶資料 = 客戶資料repo.Get單筆資料ById(id);
            客戶資料repo.Delete(客戶資料);
            客戶資料repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }
        public ActionResult Excel()
        {
            using (XLWorkbook wb = new XLWorkbook())
            {
                var data = 客戶資料repo.All().Select(c => new { c.客戶名稱, c.電話, c.傳真, c.統一編號,c.地址});
                var ws = wb.Worksheets.Add("客戶資料", 1);
                ws.Cell(1, 1).Value = "客戶名稱";
                ws.Cell(1, 2).Value = "電話";
                ws.Cell(1, 3).Value = "傳真";
                ws.Cell(1, 4).Value = "統一編號";
                ws.Cell(1, 5).Value = "地址";

                //注意官方文件上說明,如果是要塞入Query後的資料該資料一定要變成是data.AsEnumerable()
                //但是查詢出來的資料剛好是IQueryable ,其中IQueryable有繼承IEnumerable 所以不需要特別寫
                ws.Cell(2, 1).InsertData(data);

                //因為是用Query的方式,這個地方要用串流的方式來存檔
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    wb.SaveAs(memoryStream);
                    //請注意 一定要加入這行,不然Excel會是空檔
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    //注意Excel的ContentType,是要用這個"application/vnd.ms-excel" 不曉得為什麼網路上有的Excel ContentType超長,xlsx會錯 xls反而不會
                    return File(memoryStream.ToArray(), "application/vnd.ms-excel", "Download.xlsx");
                }
            }
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
