import React, { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import { Select, message } from "antd";
import "./userForm.css";
import axios from "axios";
import Loader from "../General/Loader";

const initialValues = {
  User_ID: "",
  IsHiring: "",
  Name: "",
  HighestQualification: "",
  Domain: "",
  YearsOfExperience: "",
  CurrentLocation: "",
  Email: "",
  Mobile: "",
  Password: "",
};

// Replace with your API endpoint or logic to fetch domain and location options

const UserForm = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
    watch,
  } = useForm({ defaultValues: initialValues });
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

  const [passwordError, setPasswordError] = useState("");

  // Inside your component function
  const validatePassword = (value) => {
    if (!value) {
      return "Password is required.";
    } else if (value.length < 8) {
      return "Password must be at least 8 characters long.";
    } else if (!/(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}/.test(value)) {
      return "Password must contain at least one uppercase letter, one lowercase letter, and one number.";
    }
    return "";
  };

  // Inside your component function
  const handlePasswordChange = (e) => {
    const error = validatePassword(e.target.value);
    setPasswordError(error);
  };

  const onSubmit = async (data) => {
    // console.log(data);
    setIsLoading(true);
    data.IsHiring = data.IsHiring === "true" ? true : false;
    data.CurrentLocation = selectedCity;

    await axios
      .post("/Home/AddUpdateUser", data)
      .then((item) => {
        message.success(item.data);
      })
      .catch((error) => {
        message.error("There was an issue while saving new job.");
      })
      .finally(() => {
        // setIsLoading(false);
      });

    setIsLoading(false);
  };

  return (
    <>
      {isLoading && <Loader />}
      <form onSubmit={handleSubmit(onSubmit)} className="form-container">
        {/* User ID */}
        <div>
          <label htmlFor="User_ID">User ID (Required, min. 6 chars):</label>
          <input
            {...register("User_ID", {
              required: "User ID is required.",
              minLength: {
                value: 6,
                message: "User ID must be at least 6 characters long.",
              },
            })}
            id="User_ID"
            type="text"
            placeholder="Enter User ID"
          />
          {errors.User_ID && (
            <span className="error">{errors.User_ID.message}</span>
          )}
        </div>

        {/* Is Recruiter */}
        <div>
          <label>Is Recruiter (Required):</label>
          <select {...register("IsHiring")} id="IsHiring" type="text">
            <option value={true}>Yes</option>
            <option value={false}>No</option>
          </select>

          {errors.IsHiring && (
            <span className="error">{errors.IsHiring.message}</span>
          )}
        </div>

        {/* Name */}
        <div>
          <label htmlFor="Name">Name (Required):</label>
          <input
            {...register("Name", { required: "Name is required." })}
            id="Name"
            type="text"
            placeholder="Enter Name"
          />
          {errors.name && <span className="error">{errors.name.message}</span>}
        </div>

        {/* Highest Qualification */}
        <div>
          <label htmlFor="HighestQualification">
            Highest Qualification (Optional):
          </label>
          <input
            {...register("HighestQualification")}
            id="HighestQualification"
            type="text"
            placeholder="Enter Highest Qualification"
          />
        </div>

        {/* Domain */}
        <div>
          <label htmlFor="Domain">Domain (Required):</label>
          <input
            {...register("Domain", { required: true })}
            id="Domain"
            type="text"
            placeholder="Enter Domain"
          />
          {errors.Domain && (
            <span className="error-message">This field is required</span>
          )}
        </div>

        <div>
          <label htmlFor="YearsOfExperience">
            Years of Experience (Required, Positive only):
          </label>
          <input
            {...register("YearsOfExperience", {
              required: "Years of Experience is required.",
              pattern: {
                value: /^[1-9][0-9]*$/,
                message: "Please enter a positive integer value.",
              },
            })}
            id="YearsOfExperience"
            type="number"
            min="0"
            placeholder="Enter Years of Experience"
          />
          {errors.YearsOfExperience && (
            <span className="error">{errors.YearsOfExperience.message}</span>
          )}
        </div>

        {/* Current Location */}
        <div>
          <label htmlFor="CurrentLocation">Current Location:</label>
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

        {/* Email */}
        <div>
          <label htmlFor="Email">Email (Required):</label>
          <input
            {...register("Email", { required: true })}
            id="Email"
            placeholder="Enter Email"
          />
          {errors.Email && (
            <span className="error-message">This field is required</span>
          )}
        </div>
        <div>
          <label htmlFor="Password">
            Password (Required, min. 8 chars, uppercase, lowercase, number):
          </label>
          <input
            {...register("Password", { required: true })}
            onChange={handlePasswordChange}
            id="Password"
            type="password"
            placeholder="Enter Password"
          />
          {passwordError && <span className="error">{passwordError}</span>}
        </div>

        <button type="submit" style={{ marginTop: "2vh" }}>
          Submit
        </button>
      </form>
    </>
  );
};

export default UserForm;
