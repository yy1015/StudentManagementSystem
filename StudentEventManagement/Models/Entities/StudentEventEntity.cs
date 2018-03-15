using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentEventManagement.Models.Entities
{
    [Table("StudentEvent")]
    public class StudentEventEntity : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public short Maximum { get; set; }

        [Required]
        public int VenueId { get; set; }
        public virtual VenueEntity Venue { get; set; }
    }
}