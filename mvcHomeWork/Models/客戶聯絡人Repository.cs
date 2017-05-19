using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace mvcHomeWork.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => !p.是否已刪除);
        }
        public IQueryable<客戶聯絡人> All(bool showAll)
        {
            if (showAll) return base.All();
            else return this.All();
        }
        public 客戶聯絡人 Get單筆資料ById(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
        public IQueryable<客戶聯絡人> Get客戶聯絡人列表頁所有資料(bool Active, bool showAll = false)
        {
            IQueryable<客戶聯絡人> all = this.All();
            if (showAll)
            {
                all = base.All();
            }
            return all
                .Where(p => !p.是否已刪除)
                .OrderByDescending(p => p.Id).Take(10);
        }
        public void Update(客戶聯絡人 客戶聯絡人)
        {
            this.UnitOfWork.Context.Entry(客戶聯絡人).State = EntityState.Modified;
        }
        public override void Delete(客戶聯絡人 entity)
        {
            this.UnitOfWork.Context.Configuration.ValidateOnSaveEnabled = false;

            entity.是否已刪除 = true;
        }

    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}