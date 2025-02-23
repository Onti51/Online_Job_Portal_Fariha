using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace DAL;

public class tbl_Company
{
    [Key]
    public string ID { get; set; }
    public string Name { get; set; }
    public float Rating { get; set; }
    public DateTime Estd_Date { get; set; }
    public string HQ_Location { get; set; }
    public string Domain { get; set; }
}