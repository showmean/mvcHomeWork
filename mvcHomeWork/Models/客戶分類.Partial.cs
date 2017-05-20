namespace mvcHomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶分類MetaData))]
    public partial class 客戶分類
    {
    }
    
    public partial class 客戶分類MetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string 分類 { get; set; }
    
        public virtual ICollection<客戶資料> 客戶資料 { get; set; }
    }
}
