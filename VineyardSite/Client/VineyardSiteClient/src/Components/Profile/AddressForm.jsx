import React from "react";

const AddressForm = ({
  handleSubmit,
  address,
  handleChange,
  haveAddress,
  handleUpdateSubmit,
  editingAddress,
  setEditingAddress,
  isUpdated,
  setIsUpdated,
  modify,
  setModify
}) => {

  return (editingAddress === false && modify === false && isUpdated === false) ||
    (editingAddress === true && modify === false && isUpdated === false) ? (
    <div className="form-container">
      <div className="editModal">
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Street</label>
            <input
              type="text"
              name="street"
              disabled={haveAddress}
              value={address.street}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>House Number</label>
            <input
              type="text"
              name="houseNumber"
              disabled={haveAddress}
              value={address.houseNumber}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>Zip Code</label>
            <input
              type="text"
              name="zipCode"
              disabled={haveAddress}
              value={address.zipCode}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>City</label>
            <input
              type="text"
              name="city"
              disabled={haveAddress}
              value={address.city}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>Country</label>
            <input
              type="text"
              name="country"
              disabled={haveAddress}
              value={address.country}
              onChange={handleChange}
            />
          </div>
          <button
            hidden={haveAddress}
            type="submit"
            className="button"
            onClick={() => {
              setEditingAddress(true);
            }}
          >
            Submit
          </button>
        </form>
        <button
          hidden={!haveAddress}
          style={{
            marginBottom: "100px",
          }}
          onClick={() => {setModify(true); setIsUpdated(true)}}
        >
          Modify
        </button>
      </div>
    </div>
  ) : (
    <div className="form-container">
      <div className="editModal">
        <form onSubmit={handleUpdateSubmit}>
          <div className="form-group">
            <label>Street</label>
            <input
              type="text"
              name="street"
              value={address.street}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>House Number</label>
            <input
              type="text"
              name="houseNumber"
              value={address.houseNumber}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>Zip Code</label>
            <input
              type="text"
              name="zipCode"
              value={address.zipCode}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>City</label>
            <input
              type="text"
              name="city"
              value={address.city}
              onChange={handleChange}
            />
          </div>

          <div className="form-group">
            <label>Country</label>
            <input
              type="text"
              name="country"
              value={address.country}
              onChange={handleChange}
            />
          </div>

          <button
            type="submit"
            className="button"
          >
            Save
          </button>
        </form>
        <button
          className="button"
          onClick={() => {
            setEditingAddress(false);
            setModify(false);
          }}
        >
          Cancel
        </button>
      </div>
    </div>
  );
};

export default AddressForm;
