using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace The_Archivist.Models
{
    [Table("Employees",Schema ="dbo")]
    public class Employee
    {
        public Employee()
        {
            archives = new List<Archive>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "معرف الموظف")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "الاسم الأول")]
        public string? empFName { get; set; }

        [Required]
        [Display(Name = "الكنية")]
        public string? empLName { get; set; }

        [ForeignKey("Departments")]
        [Display(Name = "القسم")]
        public int departmentId { get; set; }
        public virtual Department? department { get; set; }

        [ForeignKey("Orgnizations")]
        [Display(Name = "المنظمة")]
        public int orgnizationId { get; set; }
        public virtual Orgnization? orgnization { get; set; }
        
        public virtual ICollection<Archive> archives { get; set; }


    }
}
