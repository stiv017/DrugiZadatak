using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwagerApi.Models
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
