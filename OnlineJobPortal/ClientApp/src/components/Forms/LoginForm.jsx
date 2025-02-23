import { Button, Col, Input, Row, message } from "antd";
import Password from "antd/es/input/Password";
import React, { useState } from "react";
import "./loginform.css";
import axios from "axios";

function LoginForm() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [loginAttempt, setLoginAttempt] = useState(0);
  const onLoginSubmit = async () => {
    // console.log(username + "-" + password);
    await axios
      .get("/Home/User?User_ID=" + username + "&Password=" + password)
      .then((response) => {
        if (response.user_ID == "" || response.user_ID == undefined) {
          message.error("Wrong username or password, please try again");
          setLoginAttempt(loginAttempt + 1);
        } else {
          message.success("Welcome to the Job Finder " + response.user_ID);
        }
      })
      .catch((error) => {});
  };
  return (
    <div className="loginForm">
      <Row className="loginRow">
        <Col span={8}>Username:</Col>
        <Col span={16}>
          <Input
            placeholder="Please enter your username"
            onChange={(e) => {
              setUsername(e.target.value);
            }}
          ></Input>
        </Col>
      </Row>
      <Row className="loginRow">
        <Col span={8}>Password:</Col>
        <Col span={16}>
          <Input
            placeholder="Please enter your Password"
            onChange={(e) => {
              setPassword(e.target.value);
            }}
          ></Input>
        </Col>
      </Row>
      <Row className="loginRow">
        <Button onClick={onLoginSubmit}>Submit</Button>
      </Row>
    </div>
  );
}

export default LoginForm;
