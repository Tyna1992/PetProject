import React, { useState, useEffect } from "react";
import { useContext } from "react";
import { UserContext } from "../UserContext";
import notify from "../../Utils/Notify";
import AddressForm from "./AddressForm";

const AddAddress = () => {
  const { user } = useContext(UserContext);
  const [address, setAddress] = useState({
    street: "",
    houseNumber: "",
    zipCode: "",
    city: "",
    country: "",
  });
  const [haveAddress, setHaveAddress] = useState(false);

  const handleChange = (e) => {
    setAddress({
      ...address,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const endpoint = haveAddress
      ? `/api/User/UpdateAddress/${user.id}`
      : `/api/User/AddAddress/${user.id}`;
    const method = haveAddress ? "PATCH" : "POST";
    try {
      const response = await fetch(endpoint, {
        method,
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          ...address,
          //userId: user.id,
        }),
      });
      if (response.ok) {
        notify("Address saved successfully", "success");
        setHaveAddress(true);
      } else {
        notify("Failed to save address", "error");
        throw new Error("Failed to save address");
      }
    } catch (error) {
      console.error(error);
    }
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
  }, []);

  return (
    <>
      <h3>
        {haveAddress
          ? "Your address:"
          : "No address found, please add:" ||
            (address.street === "" &&
              address.houseNumber === "" &&
              address.zipCode === "" &&
              address.city === "" &&
              address.country === "") ? "No address found, please add:" : ""}
      </h3>
      <AddressForm
        handleSubmit={handleSubmit}
        address={address}
        handleChange={handleChange}
        haveAddress={haveAddress}
      />
    </>
  );
};

export default AddAddress;
