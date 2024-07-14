import React, { useState, useEffect } from "react";
import { useContext } from "react";
import { UserContext } from "../UserContext";
import notify from "../../Utils/Notify";
import AddressCard from "./AddressCard";
import "./Address.css";
import AddressModal from "./AddressModal";

const Address = () => {
  const { user } = useContext(UserContext);
  const [haveAddress, setHaveAddress] = useState(false);
  const [address, setAddress] = useState({
    street: "",
    houseNumber: "",
    zipCode: "",
    city: "",
    country: "",
  });
  const [addresses, setAddresses] = useState([]);
  const [showAddModal, setShowAddModal] = useState(false);
  const [showModifyModal, setShowModifyModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [selectedAddress, setSelectedAddress] = useState({
    street: "",
    houseNumber: "",
    zipCode: "",
    city: "",
    country: "",
  });

  const handleAddInputChange = (e) => {
    setAddress({
      ...address,
      [e.target.name]: e.target.value,
    });
  };

  const handleModifyInputChange = (e) => {
    setSelectedAddress({
      ...selectedAddress,
      [e.target.name]: e.target.value,
    });
  };

  const handleModifyClick = (address) => {
    setSelectedAddress(address);
    setShowModifyModal(true);
  };

  const handleAddAddress = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(`/api/User/AddAddress/${user.id}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          ...address,
          UserId: user.id,
        }),
      });
      if (response.ok) {
        notify("Address added successfully", "success");
        setShowAddModal(false);
        setAddress({
          street: "",
          houseNumber: "",
          zipCode: "",
          city: "",
          country: "",
        });
        getAllAddresses(); // Frissítjük a címek listáját a hozzáadás után
      } else {
        notify("Failed to add address", "error");
        throw new Error("Failed to add address");
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleUpdateAddress = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(
        `/api/User/UpdateAddress/${selectedAddress.addressId}`,
        {
          method: "PATCH",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            ...selectedAddress,
            UserId: user.id,
          }),
        }
      );
      if (response.ok) {
        notify("Address updated successfully", "success");
        setShowModifyModal(false);
        setSelectedAddress({
          street: "",
          houseNumber: "",
          zipCode: "",
          city: "",
          country: "",
        });
        getAllAddresses(); // Frissítjük a címek listáját a módosítás után
      } else {
        notify("Failed to update address", "error");
        throw new Error("Failed to update address");
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleDeleteAddress = async (e, address) => {
    e.preventDefault();
    setShowDeleteModal(true);
    try {
      const response = await fetch(
        `/api/User/DeleteAddress/${address.addressId}`,
        {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      if (response.ok) {
        notify("Address deleted successfully", "success");
        setShowModifyModal(false);
        setSelectedAddress({
          street: "",
          houseNumber: "",
          zipCode: "",
          city: "",
          country: "",
        });
        setShowDeleteModal(false);
        setAddresses(
          addresses.filter((a) => a.addressId !== address.addressId)
        );
      } else {
        notify("Failed to delete address", "error");
        throw new Error("Failed to delete address");
      }
    } catch (error) {
      console.log(error);
    }
  };

  const getAllAddresses = async () => {
    try {
      const response = await fetch(`/api/User/GetAllAddress/${user.id}`, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      });
      const data = await response.json();
      if (data.length > 0) {
        setHaveAddress(true);
      }
      setAddresses(data);
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    getAllAddresses();
  }, [user]);

  return (
    <>
      <div className="add-address">
        <h2 className="title">Your addresses:</h2>
        <button
          type="button"
          className="btn btn-primary"
          onClick={() => {
            setShowAddModal(true);
            setAddress({
              street: "",
              houseNumber: "",
              zipCode: "",
              city: "",
              country: "",
            });
          }}
        >
          + Add address
        </button>
      </div>

      <div className="addresses-container">
        {haveAddress &&
          addresses.map((address) => (
            <AddressCard
              key={address.addressId}
              address={address}
              user={user}
              handleModifyClick={handleModifyClick}
              handleDeleteAddress={handleDeleteAddress}
              showDeleteModal={showDeleteModal}
            />
          ))}
        <AddressModal
          showModifyModal={showModifyModal}
          setShowModifyModal={setShowModifyModal}
          showAddModal={showAddModal}
          setShowAddModal={setShowAddModal}
          selectedAddress={selectedAddress}
          setSelectedAddress={setSelectedAddress}
          address={address}
          setAddress={setAddress}
          handleAddInputChange={handleAddInputChange}
          handleModifyInputChange={handleModifyInputChange}
          handleUpdateAddress={handleUpdateAddress}
          handleAddAddress={handleAddAddress}
        />
      </div>
    </>
  );
};

export default Address;
