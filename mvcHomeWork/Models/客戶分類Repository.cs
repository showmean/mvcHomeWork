using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace mvcHomeWork.Models
{   
	public  class 客戶分類Repository : EFRepository<客戶分類>, I客戶分類Repository
	{
        public override IQueryable<客戶分類> All()
        {
            return base.All();
        }
        public 客戶分類 Get單筆資料ById(int id)
        {
            return this.All().FirstOrDefault(p => p.Id == id);
        }
        public void Update(客戶分類 客戶分類)
        {
            this.UnitOfWork.Context.Entry(客戶分類).State = EntityState.Modified;
        }
    }

	public  interface I客戶分類Repository : IRepository<客戶分類>
	{

	}
}