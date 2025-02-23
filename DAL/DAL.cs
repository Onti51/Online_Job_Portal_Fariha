using Microsoft.EntityFrameworkCore;
using Models;
namespace DAL;

public class DBOperations
{
    JobFinderDataContext context = new JobFinderDataContext();

    public string AddNewJob(tbl_Avl_Job NewJob, List<tbl_Job_Qualification> Qualifications, List<tbl_Job_Skill> Skills)
    {
        string status = "";
        try
        {

            context.tbl_Avl_Jobs.Add(NewJob);
            context.SaveChanges();
            status = $"Added Job:{NewJob.Job_Name} successfully\n";
            Qualifications = Qualifications.Where(x => context.tbl_Job_Qualifications.Contains(x)).ToList();
            context.tbl_Job_Qualifications.AddRange(Qualifications);
            // status = $"Added {Qualifications.Count} required qualifications for Job:{NewJob.Job_Name} successfully\n";
            Skills = Skills.Where(x => context.tbl_Job_Skills.Contains(x)).ToList();
            context.tbl_Job_Skills.AddRange(Skills);
            // status = $"Added {Skills.Count} required skills for Job:{NewJob.Job_Name} successfully\n";
        }
        catch (Exception Ex)
        {
            status += System.Reflection.MethodBase.GetCurrentMethod() + "\n\tError: " + Ex.Message + "\n\tInner Exception: " + Ex.InnerException;
            Console.WriteLine(status);
            status = "Failed to add job";
            //Log Error
        }
        return status;
    }

    public (List<tbl_Avl_Job>, string) GetAllJobs()
    {
        string status = "";
        List<tbl_Avl_Job> ReturnData = new List<tbl_Avl_Job>();
        try
        {

            ReturnData = context.tbl_Avl_Jobs.AsNoTracking().ToList();

            status = $"Fetched {ReturnData.Count} jobs successfully";
        }
        catch (Exception Ex)
        {
            status += System.Reflection.MethodBase.GetCurrentMethod() + "\n\tError: " + Ex.Message + "\n\tInner Exception: " + Ex.InnerException;
            //Log Error
            Console.WriteLine(status);
        }
        return (ReturnData, status);
    }

    public string SaveUserDetails(tbl_User UserData, tbl_User_Secrets UserSecrets, string oldPassword = "")
    {
        string status;
        try
        {
            if (context.tbl_Users.Where(x => x.User_ID == UserData.User_ID).Any())
            {
                if (context.tbl_User_Secrets.Where(x => x.User_ID == UserSecrets.User_ID && x.pw == oldPassword).Any())
                {
                    context.tbl_Users.Update(UserData);
                    if (context.tbl_User_Secrets.Where(x => x.User_ID == UserSecrets.User_ID).Any())
                    {
                        context.tbl_User_Secrets.Update(UserSecrets);
                    }
                    status = $"User data for {UserData.Name} updated successfully";
                }
                else
                {
                    status = "Old Password does not match, cannot make updates to existing user.";
                }
            }
            else
            {
                context.tbl_Users.Add(UserData);
                context.tbl_User_Secrets.Add(UserSecrets);
                status = $"User data for {UserData.Name} added successfully";
            }
            context.SaveChanges();


        }
        catch (Exception Ex)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + "\n\tError: " + Ex.Message + "\n\tInner Exception: " + Ex.InnerException);
            //Log Error
            status = "Failed to add user";
        }
        return status;

    }

    public UserDetails GetUser(string User_ID, string Password)
    {
        UserDetails User = new();
        try
        {

            if (context.tbl_User_Secrets.Where(x => x.User_ID == User_ID && x.pw == Password).Any())
            {
                User = context.tbl_Users.Where(x => x.User_ID == User_ID).Select(x => new UserDetails()
                {
                    User_ID = x.User_ID,
                    IsHiring = x.IsHiring ?? false,
                    CompanyID = x.CompanyID,
                    Name = x.Name,
                    HighestQualification = x.HighestQualification,
                    Joined_On = x.Joined_On,
                    YearsOfExperience = x.YearsOfExperience,
                    Domain = x.Domain,
                    CurrentLocation = x.CurrentLocation,
                    Email = x.Email,
                    Mobile = x.Mobile
                }).FirstOrDefault();
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod() + "\n\tError: " + Ex.Message + "\n\tInner Exception: " + Ex.InnerException);
            //Log Error

        }
        return User;
    }

}
