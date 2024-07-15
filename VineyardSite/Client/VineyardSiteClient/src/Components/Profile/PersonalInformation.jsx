import React from "react";

const PersonalInformation = ({
  editMode,
  handleFormSubmit,
  formData,
  handleInputChange,
  handleEditToggle,
}) => {

  const handleEditClick = (e) => {
    e.preventDefault();
    handleEditToggle();
  };

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
            <button onClick={(e) => handleEditClick(e)}>
              Edit
            </button>
          </form>
        </div>
      ) : (
        <div className="editModal">
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
