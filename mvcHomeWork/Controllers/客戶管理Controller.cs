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
    public class 客戶管理Controller : BaseController
    {
       // private 客戶資料Entities1 db = new 客戶資料Entities1();

        // GET: 客戶管理
        public ActionResult Index()
        {
            //return View(db.客戶管理.ToList());
            var data = 客戶管理repo.All().Take(10);
            return View(data);
        }

    }
}
