import React from "react";
import { useState, useEffect } from "react";
import "./ChangePassword.css";
import notify from "../../Utils/Notify";
import { UserContext } from "../UserContext";

const ChangePassword = () => {
  const [oldPassword, setOldPassword] = useState("");
  const [newPassword, setNewPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [inputErrors, setInputErrors] = useState("");
  const { user } = React.useContext(UserContext);

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (newPassword !== confirmPassword) {
      setInputErrors("pass-not-match");
      notify("Passwords do not match!", "error");
      return;
    }

    try {
      const response = await fetch(`/api/User/ChangePassword/${user.id}`, {
        method: "PATCH",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ oldPassword, newPassword }),
      });
      console.log(response);
      if (!response.ok) {
        notify("Failed to change password!", "error");
        setOldPassword("");
        setNewPassword("");
        setConfirmPassword("");
        throw new Error("Failed to change password!");
      }
      if (response.ok) {
        notify("Password changed successfully!", "success");
        setOldPassword("");
        setNewPassword("");
        setConfirmPassword("");
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    if (name === "oldPassword") {
      setOldPassword(value);
    } else if (name === "newPassword") {
      setNewPassword(value);
    } else if (name === "confirmPassword") {
      setConfirmPassword(value);
    }
  };

  return (
    <>
      <div className="profile-container">
        <div className="editModal">
          <h3>Change Password</h3>
          <form onSubmit={handleSubmit}>
            <label>
              Old Password:
              <input
                type="password"
                name="oldPassword"
                value={oldPassword}
                onChange={handleInputChange}
              />
            </label>
            <label>
              New Password:
              <input
                type="password"
                name="newPassword"
                value={newPassword}
                className={inputErrors === "pass-not-match" ? "error" : ""}
                onChange={handleInputChange}
              />
            </label>
            <label>
              Confirm Password:
              <input
                type="password"
                name="confirmPassword"
                value={confirmPassword}
                className={inputErrors === "pass-not-match" ? "error" : ""}
                onChange={handleInputChange}
              />
            </label>
            <button type="submit">Change Password</button>
          </form>
        </div>
      </div>
    </>
  );
};

export default ChangePassword;
