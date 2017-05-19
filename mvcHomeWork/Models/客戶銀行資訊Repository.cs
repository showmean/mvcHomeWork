using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace mvcHomeWork.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p => !p.是否已刪除);
        }
        public IQueryable<客戶銀行資訊> All(bool showAll)
        {
            if (showAll) return base.All();
            else return this.All();
        }
        public 客戶銀行資訊 Get單筆資料ById(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
        public IQueryable<客戶銀行資訊> Get客戶銀行資訊列表頁所有資料(bool Active, bool showAll = false)
        {
            IQueryable<客戶銀行資訊> all = this.All();
            if (showAll)
            {
                all = base.All();
            }
            return all
                .Where(p => !p.是否已刪除)
                .OrderByDescending(p => p.Id).Take(10);
        }
        public void Update(客戶銀行資訊 客戶銀行資訊)
        {
            this.UnitOfWork.Context.Entry(客戶銀行資訊).State = EntityState.Modified;
        }
        public override void Delete(客戶銀行資訊 entity)
        {
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;

            entity.是否已刪除 = true;
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}