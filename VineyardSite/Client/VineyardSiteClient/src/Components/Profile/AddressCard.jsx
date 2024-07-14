import React from "react";
import { Link } from "react-router-dom";
import "./AddressCard.css";

const AddressCard = ({
  address,
  user,
  handleModifyClick,
  handleDeleteAddress,
  showDeleteModal,
}) => {

  return (
    <div className="card address-card">
      <div className="card-body">
        <div className="row align-items-center">
          <div className="col-auto">
            <i className="fas fa-map-marker-alt fa-2x text-primary"></i>
          </div>
          <div className="col">
            <h5 className="card-title">{user.userName}</h5>
            <p className="card-text">
              {address.street} street {address.houseNumber}. {address.zipCode},{" "}
              {address.city}, {address.country}
            </p>
          </div>
        </div>
        <div className="mt-2">
          <Link
            className="address-action"
            onClick={() => handleModifyClick(address)}
          >
            Modify
          </Link>
          <Link onClick={(e) => handleDeleteAddress(e, address)}>Delete</Link>
        </div>
      </div>
    </div>
  );
};

export default AddressCard;
