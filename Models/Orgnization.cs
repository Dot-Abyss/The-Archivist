using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace The_Archivist.Models
{
    [Table("Orgnizations",Schema ="dbo")]
    public class Orgnization
    {
        public Orgnization()
        {
            departments = new List<Department>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "معرف المؤسسة")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "اسم المؤسسة")]
        public string? orgName { get; set; }

        [Display(Name = "الشعار")]
        public string? imageSrc { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "شعار المنظمة")]
        public IFormFile imageFile { get; set; }

        public virtual ICollection<Department> departments { get; set; }
        public virtual ICollection<Employee> employees { get; set; }

        [ForeignKey("OrgTypes")]
        [Display(Name = "نوع المؤسسة")]
        public int orgTypesId { get; set; }

        public virtual OrgType? orgTypes { get; set; }
    }
}
