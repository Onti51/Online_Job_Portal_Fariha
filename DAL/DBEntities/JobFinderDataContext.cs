using Microsoft.EntityFrameworkCore;

namespace DAL;
public class JobFinderDataContext : DbContext
{
    public JobFinderDataContext()
    {
    }

    public JobFinderDataContext(DbContextOptions<JobFinderDataContext> opt) : base(opt)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

            optionsBuilder.UseNpgsql(ConnStr.Get());

        }
    }
    public DbSet<tbl_Avl_Job> tbl_Avl_Jobs { get; set; }
    public DbSet<tbl_User> tbl_Users { get; set; }
    public DbSet<tbl_Job_Applicant> tbl_Job_Applicants { get; set; }
    public DbSet<tbl_Company> tbl_Companies { get; set; }
    public DbSet<tbl_User_Skill> tbl_User_Skills { get; set; }
    public DbSet<tbl_User_Qualification> tbl_User_Qualifications { get; set; }
    public DbSet<tbl_Job_Qualification> tbl_Job_Qualifications { get; set; }
    public DbSet<tbl_Job_Skill> tbl_Job_Skills { get; set; }
    public DbSet<tbl_User_Secrets> tbl_User_Secrets { get; set; }

}