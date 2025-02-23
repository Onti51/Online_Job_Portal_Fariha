using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL;

public class tbl_User
{
    [Key]
    public string User_ID { get; set; }
    public bool? IsHiring { get; set; }
    public string? CompanyID { get; set; }
    public string? Name { get; set; }
    public string? HighestQualification { get; set; }
    public string? Domain { get; set; }
    public int? YearsOfExperience { get; set; }
    public string? CurrentLocation { get; set; }
    public DateTime Joined_On { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }


    [ForeignKey("CompanyID")]
    public tbl_Company Company { get; set; }
}