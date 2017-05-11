using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace mvcHomeWork.Controllers.ValidationAttributes
{
    public class 檢查Email是否存在Attribute : DataTypeAttribute
    {
        public 檢查Email是否存在Attribute() : base(DataType.Text)
        {
           
        }

        public override bool IsValid(object value)
        {
            //var str = (string)value;
            //return str.Contains("Will");
            return true;
        }
    }
}