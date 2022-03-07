using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace The_Archivist.Models
{
    [Table("OrgTypes",Schema ="dbo")]
    public class OrgType
    {
        public OrgType()
        {
            orgnizations = new List<Orgnization>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "المعرف")]
        public int Id { get; set; } 
        [Required]
        [Display(Name = "اسم النوع")]
        public string? typeName { get; set; }

        public virtual ICollection<Orgnization>? orgnizations { get; set; }

    }
}
