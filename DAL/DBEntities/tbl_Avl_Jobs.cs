using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL;

public class tbl_Avl_Job
{
    [Key]
    public string Job_ID { get; set; }
    public string Job_Name { get; set; }
    public string Coy_ID { get; set; }
    public string Job_Description { get; set; }
    public int AvailablePositions { get; set; }
    public int FilledPositions { get; set; }
    public bool JobOpen { get; set; }
    public string Domain { get; set; }
    public int YearsOfExperienceRequired { get; set; }


    [ForeignKey("Coy_ID")]
    public tbl_Company Company { get; set; }
}