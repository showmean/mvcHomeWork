using mvcHomeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcHomeWork.Controllers
{
    public abstract class BaseController : Controller
    {
        protected 客戶資料Repository 客戶資料repo = RepositoryHelper.Get客戶資料Repository();
        protected 客戶管理Repository 客戶管理repo = RepositoryHelper.Get客戶管理Repository();
        protected 客戶銀行資訊Repository 客戶銀行資訊repo = RepositoryHelper.Get客戶銀行資訊Repository();
        protected 客戶聯絡人Repository 客戶聯絡人repo = RepositoryHelper.Get客戶聯絡人Repository();
        // GET: Base
        public  ActionResult Debug()
        {
            return View();
        }
    }
}