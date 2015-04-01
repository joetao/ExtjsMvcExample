using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExjtsMvcExample.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("年龄")]
        [Range(0, 150)]
        public int Age { get; set; }

        [DisplayName("电话")]
        [StringLength(11)]
        [RegularExpression(@"^(\d{3,4}-)?\d{6,8}$")]
        public string Phone { get; set; }

        [DisplayName("电子邮件")]
        [RegularExpression(@"^([a-z0-9A-Z]+[-|\.]?)+[a-z0-9A-Z]@([a-z0-9A-Z]+(-[a-z0-9A-Z]+)?\.)+[a-zA-Z]{2,}$")]
        public string Email { get; set; }
    }
}