import React from "react";

const AddressForm = ({handleSubmit, handleChange, address}) => {

  return (
    <div className="form-container">
      <div className="editModal">
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Street</label>
            <input
              type="text"
              name="street"
              required
              onChange={handleChange}
              value={address.street}
            />
          </div>

          <div className="form-group">
            <label>House Number</label>
            <input
              type="text"
              name="houseNumber"
              required
              onChange={handleChange}
              value={address.houseNumber}
            />
          </div>

          <div className="form-group">
            <label>Zip Code</label>
            <input
              type="text"
              name="zipCode"
              required
              onChange={handleChange}
              value={address.zipCode}
            />
          </div>

          <div className="form-group">
            <label>City</label>
            <input
              type="text"
              name="city"
              required
              onChange={handleChange}
              value={address.city}
            />
          </div>

          <div className="form-group">
            <label>Country</label>
            <input
              type="text"
              name="country"
              required
              onChange={handleChange}
              value={address.country}
            />
          </div>

          <button type="submit" className="button">
            Submit
          </button>
        </form>
      </div>
    </div>
  );
};

export default AddressForm;
