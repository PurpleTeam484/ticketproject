namespace ticketswap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Text;

    [Table("EMPLOYEE")]
    public partial class EMPLOYEE
    {
        [Key]
        public int EMPLOYEE_ID { get; set; }

        [StringLength(15)]
        public string EMPLOYEE_FNAME { get; set; }

        [StringLength(15)]
        public string EMPLOYEE_LNAME { get; set; }

        [StringLength(30)]
        public string EMPLOYEE_EMAIL { get; set; }

        [StringLength(100)]
        public string EMPLOYEE_PASSWORD { get; set; }

        [StringLength(10)]
        public string EMPLOYEE_RATE { get; set; }

        [StringLength(3)]
        public string EMPLOYEE_ACTIVE { get; set; }
    }
}
