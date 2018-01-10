using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rad301ChristmasExam2017.Models
{
    [Table("Loan")]
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Loan ID")]
        public int LoanID { get; set; }

        [ForeignKey("associatedMember")]
        public int MemberID { get; set; }

        [ForeignKey("associatedBook")]
        public int BookID { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Loan Date Added")]
        public DateTime? LoanDate { get; set; }

        public virtual Member associatedMember { get; set; }
        public virtual Book associatedBook { get; set; }
    }
}