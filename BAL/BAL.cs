using System.Security.Cryptography;
using System.Text;
using DAL;
using Models;

namespace BAL;

public class BusinessOperations
{
    public string AddNewJob(Job Job)
    {
        DBOperations Dbo = new();
        if (Job == null)
        {
            return "Failed to add job, job details were not provided";
        }
        List<tbl_Job_Qualification> QualsToSave = Job.Qualifications_Required.Select(x => new tbl_Job_Qualification()
        {
            Job_ID = Job.Job_ID,
            QualificationRequired = x.Qualification_Name,
            Required = x.Required
        }).ToList();
        List<tbl_Job_Skill> SkillsToSave = Job.Skills_Required.Select(x => new tbl_Job_Skill()
        {
            Job_ID = Job.Job_ID,
            Skill_Name = x.Skill_Name,
            Required = x.Required
        }).ToList();
        string status = Dbo.AddNewJob(new tbl_Avl_Job()
        {
            Job_ID = Job.Job_ID,
            Job_Name = Job.Job_Name,
            JobOpen = Job.JobOpen,
            AvailablePositions = Job.AvailablePositions,
            FilledPositions = Job.FilledPositions,
            Domain = Job.Domain,
            Coy_ID = Job.Coy_ID,
            Job_Description = Job.Job_Description,
            YearsOfExperienceRequired = Job.YearsOfExperienceRequired,


        }, QualsToSave, SkillsToSave);
        return status;
    }
    public (List<Job>, string) GetAllJobs()
    {
        List<Job> ReturnData = new List<Job>();
        string status = "";
        try
        {
            (List<tbl_Avl_Job> JobDB, status) = new DBOperations().GetAllJobs();
            foreach (tbl_Avl_Job avl_Jobs in JobDB)
            {
                Job Job = new Job()
                {
                    Job_ID = avl_Jobs.Job_ID,
                    Job_Name = avl_Jobs.Job_Name,
                    JobOpen = avl_Jobs.JobOpen,

                    AvailablePositions = avl_Jobs.AvailablePositions,
                    FilledPositions = avl_Jobs.FilledPositions,
                    Domain = avl_Jobs.Domain,
                    Coy_ID = avl_Jobs.Coy_ID,
                    Job_Description = avl_Jobs.Job_Description,
                    YearsOfExperienceRequired = avl_Jobs.YearsOfExperienceRequired
                };
                ReturnData.Add(Job);
            }
        }
        catch (Exception Ex)
        {
            status += System.Reflection.MethodBase.GetCurrentMethod() + "\n\tError: " + Ex.Message + "\n\tInner Exception: " + Ex.InnerException;
            Console.WriteLine(status);
        }
        return (ReturnData, status);

    }
    public string AddUpdateUser(UserDetails UserData)
    {
        if (UserData == null)
        {
            return "User Not Saved because user data was not provided";
        }
        tbl_User UserDetails = new()
        {
            User_ID = UserData.User_ID,
            IsHiring = UserData.IsHiring,
            CompanyID = UserData.CompanyID,
            Name = UserData.Name,
            HighestQualification = UserData.HighestQualification,
            Joined_On = UserData.Joined_On ?? DateTime.UtcNow,
            YearsOfExperience = UserData.YearsOfExperience,
            Domain = UserData.Domain,
            CurrentLocation = UserData.CurrentLocation,
            Email = UserData.Email,
            Mobile = UserData.Mobile
        };

        tbl_User_Secrets UserSecretsToSave = new()
        {
            User_ID = UserData.User_ID,
            pw = getHash(UserData.Password)
        };
        string OldPassword = "";
        if (UserData.OldPassword != "")
        {
            OldPassword = getHash(UserData.OldPassword);
        }
        return new DBOperations().SaveUserDetails(UserDetails, UserSecretsToSave, OldPassword);
    }
    private static string getHash(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return "";
        }
        // SHA512 is disposable by inheritance.  
        using (var sha256 = SHA256.Create())
        {
            // Send a sample text to hash.  
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            // Get the hashed string.  
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    public UserDetails GetUserDetails(string User_ID, string Password)
    {
        Password = getHash(Password);

        return new DBOperations().GetUser(User_ID, Password);
    }
}
