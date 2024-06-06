import React from "react";
import { FaGear } from "react-icons/fa6";

const PersonalInformation = ({ editMode, handleFormSubmit, formData, handleInputChange, handleEditToggle}) => {

    return (
        <div className="profile-container">
          {editMode === false ? (
            <div className="editModal">
              <form onSubmit={handleFormSubmit}>
                <label>
                  User Name:
                  <input
                    type="text"
                    name="userName"
                    value={formData.userName}
                    disabled
                    onChange={handleInputChange}
                  />
                </label>
                <label>
                  Email:
                  <input
                    type="email"
                    name="email"
                    value={formData.email}
                    disabled
                    onChange={handleInputChange}
                  />
                </label>
                <label>
                  Phone Number:
                  <input
                    type="tel"
                    name="phoneNumber"
                    value={formData.phoneNumber}
                    disabled
                    onChange={handleInputChange}
                  />
                </label>
                <FaGear className="edit-icon" onClick={handleEditToggle} />
              </form>
            </div>
          ) : (
            <div className="editModal">
              <h3>Edit Personal Information</h3>
              <form onSubmit={handleFormSubmit}>
                <label>
                  User Name:
                  <input
                    type="text"
                    name="userName"
                    disabled
                    value={formData.userName}
                    onChange={handleInputChange}
                  />
                </label>
                <label>
                Email:
                  <input
                    type="email"
                    name="email"
                    value={formData.email}
                    onChange={handleInputChange}
                  />
                </label>
                <label>
                  Phone Number:
                  <input
                    type="tel"
                    name="phoneNumber"
                    value={formData.phoneNumber}
                    onChange={handleInputChange}
                  />
                </label>
                <button type="submit">Save</button>
                <button type="button" onClick={handleEditToggle}>
                  Cancel
                </button>
              </form>
            </div>
          )}
        </div>
      );
};

export default PersonalInformation;
    