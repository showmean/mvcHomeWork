namespace mvcHomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(客戶類別MetaData))]
    public partial class 客戶類別
    {
    }
    
    public partial class 客戶類別MetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        public string 類別 { get; set; }
    }
}
