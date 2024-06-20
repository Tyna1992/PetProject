import React from "react";
import { Modal } from "react-bootstrap";
import AddressForm from "./AddressForm";

const AddressModal = ({
  showModifyModal,
  setShowModifyModal,
  showAddModal,
  setShowAddModal,
  address,
  setAddress,
  selectedAddress,
  setSelectedAddress,
  handleAddInputChange,
  handleModifyInputChange,
  handleUpdateAddress,
  handleAddAddress,
}) => {

  return (
    <Modal
      show={showModifyModal || showAddModal}
      onHide={() => {
        setShowModifyModal(false);
        setShowAddModal(false);
      }}
      centered
    >
      <Modal.Header>
        <Modal.Title>
          {showAddModal ? "Add address:" : "Modify address:"}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {showAddModal ? (
          <AddressForm
            address={address}
            handleChange={handleAddInputChange}
            handleSubmit={handleAddAddress}
          />
        ) : (
          <AddressForm
            address={selectedAddress}
            handleChange={handleModifyInputChange}
            handleSubmit={handleUpdateAddress}
          />
        )}
      </Modal.Body>
    </Modal>
  );
};

export default AddressModal;
