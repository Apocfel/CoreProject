using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreProject.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [DisplayName(displayName: "Введите имя")]
        [StringLength(25)]
        public string name { get; set; }

        [DisplayName(displayName: "Введите email")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        [BindNever]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
