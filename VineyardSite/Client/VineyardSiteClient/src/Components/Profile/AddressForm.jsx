import React from "react";

const AddressForm = ({ handleSubmit, address, handleChange, haveAddress }) => {
  return (
    <div className="form-container">
      <div className="editModal">
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Street</label>
            <input
              type="text"
              name="street"
              value={address.street}
              onChange={handleChange}
              required
            />
          </div>

          <div className="form-group">
            <label>House Number</label>
            <input
              type="text"
              name="houseNumber"
              value={address.houseNumber}
              onChange={handleChange}
              required
            />
          </div>

          <div className="form-group">
            <label>Zip Code</label>
            <input
              type="text"
              name="zipCode"
              value={address.zipCode}
              onChange={handleChange}
              required
            />
          </div>

          <div className="form-group">
            <label>City</label>
            <input
              type="text"
              name="city"
              value={address.city}
              onChange={handleChange}
              required
            />
          </div>

          <div className="form-group">
            <label>Country</label>
            <input
              type="text"
              name="country"
              value={address.country}
              onChange={handleChange}
              required
            />
          </div>

          <button type="submit" className="button">
            {haveAddress ? "Update" : "Submit"}
          </button>
        </form>
      </div>
    </div>
  );
};

export default AddressForm;
