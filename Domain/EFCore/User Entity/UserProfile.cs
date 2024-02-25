using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.EFCore.User_Entity
{
    [Table("user_profile")]
    public class UserProfile : BaseEntity
    {

        [Key]
        public Guid user_id { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string MiddleName { get; set; }

        public DateTime Birthdate { get; set; }

        [MaxLength(255)]
        public string Religion { get; set; }

        [MaxLength(255)]
        public string Occupation { get; set; }

        [MaxLength(50)]
        public string RelationshipStatus { get; set; }

        public string Address { get; set; }

        [Column(TypeName = "numeric(12,2)")]
        public decimal? ContactNumber { get; set; }

    }
}
