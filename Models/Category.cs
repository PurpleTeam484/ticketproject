namespace ticketswap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Text;

    [Table("CATEGORY")]
    public partial class CATEGORY
    {
        [Key]
        public int CATEGORY_ID { get; set; }

        [StringLength(30)]
        public string CATEGORY_NAME { get; set; }

        [StringLength(300)]
        public string CATEGORY_DESCRIPTION { get; set; }
    }
}
