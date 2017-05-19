using System;
using System.Linq;
using System.Collections.Generic;
	
namespace mvcHomeWork.Models
{   
	public  class 客戶管理Repository : EFRepository<客戶管理>, I客戶管理Repository
	{
        public override IQueryable<客戶管理> All()
        {
            return base.All();
        }
        public IQueryable<客戶管理> All(bool showAll)
        {
            if (showAll) return base.All();
            else return this.All();
        }

    }

	public  interface I客戶管理Repository : IRepository<客戶管理>
	{

	}
}