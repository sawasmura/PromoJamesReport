namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int Id { get; set; }

        [StringLength(256)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [StringLength(100)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [StringLength(250)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100)]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Active { get; set; }
    }
}
