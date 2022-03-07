using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace The_Archivist.Models
{
    [Table("Departments", Schema = "dbo")]
    public class Department
    {
        public Department()
        {
            employees = new List<Employee>();
            archives = new List<Archive>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "معرف القسم")]
        public int Id { get; set; } 

        [Required]
        [Display(Name = "اسم القسم")]
        public string? depName { get; set; }

        [Display(Name = "المنظمة")]
        public int orgnizationId { get; set; } 
        public virtual Orgnization? orgnization { get; set; }

        public virtual ICollection<Employee> employees { get; set; }

        public virtual ICollection<Archive> archives { get; set; }

    }
}
