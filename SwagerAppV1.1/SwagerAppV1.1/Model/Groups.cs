using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwagerAppV1._1.Model
{
    public class Groups
    {
        [Key]
        public int IdGrupe { get; set; }
        public string Name { get; set; }
        [ForeignKey("Users")]
        public virtual ICollection<Users> User { get; set; }
    }
}
