using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace The_Archivist.Models
{
    [Table("ArchiveTypes" , Schema = "dbo")]
    public class ArchiveType
    {
        public ArchiveType()
        {
            archives = new List<Archive>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "المعرف")]
        public int Id { get; set; }   
        
        [Required]
        [Display(Name = "اسم النوع")]
        public string? typeName { get; set; }
        public virtual ICollection<Archive> archives { get; set; }

    }
}
