import { useState, useEffect, useContext } from "react";
import { UserContext } from "../../Components/UserContext";
import "./Profile.css";
import notify from "../../Utils/Notify";
import PersonalInformation from "../../Components/Profile/PersonalInformation";
import ProfileNavbar from "../../Components/Profile/ProfileNavbar";
import ChangePassword from "../../Components/Profile/ChangePassword";
import AddAddress from "../../Components/Profile/AddAddress";

const Profile = () => {
  const { user } = useContext(UserContext);
  const [editMode, setEditMode] = useState(false);
  const [formData, setFormData] = useState({
    email: "",
    phoneNumber: "",
  });
  const [activeTab, setActiveTab] = useState("personalInformation");

  const fetchUserDetails = async () => {
    try {
      const response = await fetch(
        `/api/User/GetUserDetails/${user.id}`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
          credentials: "include",
        }
      );
      if (!response.ok) {
        throw new Error("Failed to fetch user details");
      }
      const data = await response.json();
      setFormData({
        email: data.email || "",
        phoneNumber: data.phoneNumber || "",
        userName: data.userName || "",
      });
    } catch (error) {
      console.error(error);
    }
  };

  const handleFormSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(`/api/User/UpdateUser/${user.id}`, {
        method: "PATCH",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(formData),
      });
      notify("User details updated successfully", "success");
      if (!response.ok) {
        notify("Failed to update user details", "error");
        throw new Error("Failed to update user details");
      }
      if (response.status === 401) {
        notify("Your session has expired, please log in again", "warning");
        throw new Error("You are not authorized to update user details");
      }
      fetchUserDetails();
      setEditMode(false);
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    fetchUserDetails();
  }, [user]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleEditToggle = () => {
    setEditMode(!editMode);
  };

  return (
    <div className="profile">
      <h1>Profile Settings</h1>
      <h2>Welcome, {user.userName}!</h2>
      <ProfileNavbar setActiveTab={setActiveTab} activeTab={activeTab} />

      {activeTab === "personalInformation" && (
        <PersonalInformation
          editMode={editMode}
          handleFormSubmit={handleFormSubmit}
          formData={formData}
          handleInputChange={handleInputChange}
          handleEditToggle={handleEditToggle}
        />
      )}
      {activeTab === "change-password" && <ChangePassword />}

      {activeTab === "add-address" && <AddAddress />}
    </div>
  );
};

export default Profile;
