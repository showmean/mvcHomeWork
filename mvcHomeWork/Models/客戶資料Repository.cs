using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace mvcHomeWork.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => !p.是否已刪除);
        }
        public IQueryable<客戶資料> All(bool showAll)
        {
            if (showAll) return base.All();
            else return this.All();
        }
        public 客戶資料 Get單筆資料ById(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
        public IQueryable<客戶資料> Get客戶資料列表頁所有資料(bool Active, bool showAll = false)
        {
            IQueryable<客戶資料> all = this.All();
            if (showAll)
            {
                all = base.All();
            }
            return all
                .Where(p => !p.是否已刪除)
                .OrderByDescending(p => p.Id).Take(10);
        }
        public void Update(客戶資料 客戶資料)
        {
            this.UnitOfWork.Context.Entry(客戶資料).State = EntityState.Modified;
        }
        public override void Delete(客戶資料 entity)
        {
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;

            entity.是否已刪除 = true;
        }

    }

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}