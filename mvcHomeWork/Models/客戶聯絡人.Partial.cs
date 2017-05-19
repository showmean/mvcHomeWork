namespace mvcHomeWork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人
    {
    }
    
    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("客戶名稱")]
        public int 客戶Id { get; set; }
        [Required(ErrorMessage = "職稱不可空白")]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "姓名不可空白")]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required(ErrorMessage = "Email不可空白")]
        [EmailAddress(ErrorMessage = "請輸入正確的Email")]
        [Remote("檢查Email是否存在", "客戶聯絡人", AdditionalFields = "Email,客戶Id,Id", ErrorMessage = "該Email已存在")]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [RegularExpression(@"^\d{4}-\d{6}$", ErrorMessage = "手機電話格式必須為0911-111111")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        [Required]
        public bool 是否已刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
