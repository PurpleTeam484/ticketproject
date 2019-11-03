namespace ticketswap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Text;

    [Table("DISPUTE")]
    public partial class DISPUTE
    {
        [Key]
        public int DISPUTE_ID { get; set; }

        public int? ORDER_ID { get; set; }

        [StringLength(3)]
        public string DISPUTE_ACTIVE { get; set; }

        [StringLength(1000)]
        public string DISPUTE_DESCRIPTION { get; set; }

        public int? EMPLOYEE_ID { get; set; }

        [StringLength(30)]
        public string DISPUTE_OPEN_DATE { get; set; }

        [StringLength(30)]
        public string DISPUTE_CLOSE_DATE { get; set; }
    }
}
