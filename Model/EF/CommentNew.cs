namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommentNew
    {
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public int? NewsId { get; set; }

        public int? Active { get; set; }
    }
}
