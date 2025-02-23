using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL;

public class tbl_User_Secrets
{
    [Key]
    public string User_ID { get; set; }
    [Required]
    public string pw { get; set; }



    [ForeignKey("User_ID")]
    public tbl_User User { get; set; }
}