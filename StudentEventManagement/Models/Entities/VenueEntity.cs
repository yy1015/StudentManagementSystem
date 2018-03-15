using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentEventManagement.Models.Entities
{
    [Table("Venue")]
    public class VenueEntity : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string Notes { get; set; }

        public virtual IEnumerable<StudentEventEntity> StudentEvents { get; set; }
    }
}