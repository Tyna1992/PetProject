import React, { useState, useEffect } from "react";
import { useContext } from "react";
import { UserContext } from "../UserContext";
import notify from "../../Utils/Notify";
import AddressForm from "./AddressForm";

const AddAddress = () => {
  const [address, setAddress] = useState({
    street: "",
    houseNumber: "",
    zipCode: "",
    city: "",
    country: "",
  });
  const [haveAddress, setHaveAddress] = useState(false);
  const [editingAddress, setEditingAddress] = useState(false);
  const [isUpdated, setIsUpdated] = useState(false);
  const [modify, setModify] = useState(false);
  const { user } = useContext(UserContext);
  
  const handleChange = (e) => {
    setAddress({
      ...address,
      [e.target.name]: e.target.value,
    });
  };
  
  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(`/api/User/AddAddress/${user.id}`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          ...address,
          userId: user.id,
        }),
      });

      if (response.ok) {
        notify("Address added successfully", "success");
      } else {
        notify("Failed to add address", "error");
        throw new Error("Failed to add address");
      }
    } catch (error) {
      console.error(error);
    }
    setEditingAddress(true);
    setHaveAddress(true);
    
  };

  const handleUpdateSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch(`/api/User/UpdateAddress/${user.id}`, {
        method: "PATCH",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          ...address,
        }),
      });

      if (response.ok) {
        notify("Address updated successfully", "success");
      } else {
        notify("Failed to update address", "error");
        throw new Error("Failed to update address");
      }
    } catch (error) {
      console.error(error);
    }
    
    setIsUpdated(false);
    setModify(false);
    
  };

  const getAddress = async () => {
    try {
      const response = await fetch(`/api/User/GetAddress/${user.id}`, {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      });
      if (response.ok) {
        const data = await response.json();
        setAddress(data);
        setHaveAddress(true);
      } else {
        throw new Error("Failed to get address");
      }
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    getAddress();
  }, [haveAddress]);

  return haveAddress ? (
    <>
      <h3>Your address:</h3>
      <AddressForm
        handleUpdateSubmit={handleUpdateSubmit}
        address={address}
        handleChange={handleChange}
        haveAddress={haveAddress}
        setHaveAddress={setHaveAddress}
        editingAddress={editingAddress}
        setEditingAddress={setEditingAddress}
        isUpdated={isUpdated}
        setIsUpdated={setIsUpdated}
        modify={modify}
        setModify={setModify}
      />
    </>
  ) : (
    <>
      <h3>No address found please add:</h3>
      <AddressForm
        handleSubmit={handleSubmit}
        address={address}
        haveAddress={haveAddress}
        handleChange={handleChange}
        editingAddress={editingAddress}
        setEditingAddress={setEditingAddress}
        isUpdated={isUpdated}
        setIsUpdated={setIsUpdated}
        modify={modify}
        setModify={setModify}
      />
    </>
  );
};

export default AddAddress;
