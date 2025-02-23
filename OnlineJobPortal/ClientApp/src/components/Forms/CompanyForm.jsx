import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import "./jobForm.css";
import axios, { isCancel, AxiosError } from "axios";
import { Select, message } from "antd";

const CompanyForm = () => {
  const [isLoading, setIsLoading] = useState(false);
  const [cities, setCities] = useState([]);
  const [selectedCity, setSelectedCity] = useState("");
  useEffect(() => {
    var headers = new Headers();
    let apiKey = process.env.REACT_APP_Countries_API_Key;
    console.log(apiKey);
    headers.append(
      "X-CSCAPI-KEY",
      "M3FSNHZGZzhjQ0RxVHlrZmxZYzBZSnNhaE1VckJ2TmxKOFl0elpkZA=="
    );

    var requestOptions = {
      method: "GET",
      headers: headers,
      redirect: "follow",
    };
    fetch(
      "https://api.countrystatecity.in/v1/countries/IN/cities",
      requestOptions
    )
      .then((response) => response.json())
      .then((data) => {
        setCities(data.map((city) => city.name));
      });
  }, []);
  const [qualifications, setQualifications] = useState([
    { Qualification_Name: "", Required: false },
  ]);
  const [skills, setSkills] = useState([{ Skill_Name: "", Required: false }]);

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = async (data) => {
    await axios
      .post("/Home/Company", data)
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
        <label>Company Name</label>
        <input {...register("Company_Name", { required: true })} />
        {errors.Job_ID && (
          <span className="error-message">This field is required</span>
        )}
      </div>

      <div className="form-group">
        <label>Job Open (You can open it later)</label>
        <input type="date" {...register("Estd_Date")}></input>
      </div>

      <div className="form-group">
        <label>Job Open (You can open it later)</label>
        <select {...register("JobOpen")}>
          <option value={true}>Yes</option>
          <option value={false}>No</option>
        </select>
        <Select
          {...register("CurrentLocation", {
            // required: "Current Location is required.",
          })}
          id="CurrentLocation"
          style={{ width: "100%" }}
          showSearch
          placeholder="Select Current Location"
          options={cities.map((city, index) => ({
            value: city,
            label: city,
          }))}
          onSelect={(e) => {
            setSelectedCity(e);
          }}
        ></Select>
        {/* {errors.currentLocation && (
          <span className="error">{errors.currentLocation.message}</span>
        )} */}
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

      <button type="submit">Submit</button>
    </form>
  );
};

export default CompanyForm;
