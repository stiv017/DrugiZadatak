using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwagerApi.Models
{
    public class Groups
    {
        [ForeignKey("Users")]
        [Key]
        public int IdGrupe { get; set; }
        public string Name { get; set; }
        public virtual Users User { get; set; }
    }
}
