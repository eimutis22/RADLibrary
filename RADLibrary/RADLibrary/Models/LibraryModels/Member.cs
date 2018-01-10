using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Rad301ChristmasExam2017.Models
{
    [Table("Member")]
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "MemberID")]
        public int MemberID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Second Name")]
        public string SecondName { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date Joined")]
        public DateTime? DateJoined { get; set; }

        public virtual ICollection<Loan> memberLoans { get; set; }
    }
}