import React, { useState } from "react";
import { useForm } from "react-hook-form";
import "./jobForm.css";
import axios, { isCancel, AxiosError } from "axios";
import { message } from "antd";

const JobForm = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [qualifications, setQualifications] = useState([
    { Qualification_Name: "", Required: false },
  ]);
  const [skills, setSkills] = useState([{ Skill_Name: "", Required: false }]);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();
  const handleAddSkill = () => {
    setSkills([...skills, { Skill_Name: "", Required: false }]);
  };

  const handleSkillChange = (index, event) => {
    let { value } = event.target;
    value = value === "true" ? true : value === "false" ? false : value;
    const updatedSkills = [...skills];
    updatedSkills[index][event.target.name] = value;
    setSkills(updatedSkills);
  };

  const handleRemoveSkill = (index) => {
    const updatedSkills = [...skills];
    updatedSkills.splice(index, 1);
    setSkills(updatedSkills);
  };
  const handleAddQualification = () => {
    setQualifications([
      ...qualifications,
      { Qualification_Name: "", Required: false },
    ]);
  };

  const handleQualificationChange = (index, event) => {
    let { value } = event.target;
    value = value === "true" ? true : value === "false" ? false : value;
    const updatedQualifications = [...qualifications];
    updatedQualifications[index][event.target.name] = value;

    setQualifications(updatedQualifications);
  };

  const handleRemoveQualification = (index) => {
    const updatedQualifications = [...qualifications];
    updatedQualifications.splice(index, 1);
    setQualifications(updatedQualifications);
  };

  const onSubmit = async (data) => {
    // Include qualifications and skills in the form data
    data.Qualifications_Required = qualifications;
    data.Skills_Required = skills;
    data.CreatorUserID = "AdminTest1";
    data.Coy_ID = "AdminTestCompany";
    data.JobOpen = data.JobOpen === "true" ? true : false;
    console.log(data);
    await axios
      .post("/Jobs/NewJob", data)
      .then((item) => {
        message.success(item.data);
      })
      .catch((error) => {
        message.error("There was an issue while saving user.");
      })
      .finally(() => {
        setIsLoading(false);
      });
    // Submit logic here
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="job-form">
      <div className="form-group">
        <label>Job ID</label>
        <input {...register("Job_ID", { required: true })} />
        {errors.Job_ID && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div className="form-group">
        <label>Job Name</label>
        <input {...register("Job_Name", { required: true })} />
        {errors.Job_Name && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div className="form-group">
        <label>Job Open (You can open it later)</label>
        <select {...register("JobOpen")}>
          <option value={true}>Yes</option>
          <option value={false}>No</option>
        </select>
      </div>

      <div className="form-group">
        <label>Available Opening</label>
        <input
          type="number"
          {...register("AvailablePositions", { required: true, min: 0 })}
        />
        {errors.v && (
          <span className="error-message">
            This field is required and must be non-negative
          </span>
        )}
      </div>

      <div className="form-group">
        <label>Domain</label>
        <input
          {...register("Domain", { required: true })}
          placeholder="Enter Domain"
        />
        {errors.Domain && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div className="form-group">
        <label>Job Description</label>
        <textarea {...register("jobDescription", { required: true })} />
        {errors.jobDescription && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div className="form-group">
        <label>Years Of Experience Required</label>
        <input
          type="number"
          {...register("yearsOfExperienceRequired", { required: true, min: 0 })}
        />
        {errors.yearsOfExperienceRequired && (
          <span className="error-message">
            This field is required and must be non-negative
          </span>
        )}
      </div>

      <div className="form-group">
        <label>Qualifications required</label>
        {qualifications.map((qualification, index) => (
          <div key={index} className="multi-row">
            <input
              type="text"
              value={qualification.Qualification_Name}
              onChange={(e) => handleQualificationChange(index, e)}
              name={`Qualification_Name`}
              placeholder="Qualification"
            />
            <select
              value={qualification.Required}
              onChange={(e) => handleQualificationChange(index, e)}
              name="Required"
            >
              <option value={false}>Optional</option>
              <option value={true}>Mandatory</option>
            </select>
            <button
              type="button"
              onClick={() => handleRemoveQualification(index)}
            >
              Remove
            </button>
          </div>
        ))}
        <button type="button" onClick={handleAddQualification}>
          Add New Qualification
        </button>
      </div>

      <div className="form-group">
        <label>Skills required</label>
        {skills.map((skill, index) => (
          <div key={index} className="multi-row">
            <input
              type="text"
              value={skill.Skill_Name}
              onChange={(e) => handleSkillChange(index, e)}
              name={`Skill_Name`}
              placeholder="Skill"
            />
            <select
              value={skill.Required}
              onChange={(e) => handleSkillChange(index, e)}
              name={`Required`}
            >
              <option value={false}>Optional</option>
              <option value={true}>Mandatory</option>
            </select>
            <button type="button" onClick={() => handleRemoveSkill(index)}>
              Remove
            </button>
          </div>
        ))}
        <button type="button" onClick={handleAddSkill}>
          Add New Skill
        </button>
      </div>

      <button type="submit">Submit</button>
    </form>
  );
};

export default JobForm;
