import React from "react";
import { useState, useEffect } from "react";
import { UserContext } from "../UserContext";
import notify from "../../Utils/Notify";

const Orders = () => {
  const [orders, setOrders] = useState([]);
  const { user } = React.useContext(UserContext);

  const fetchOrders = async () => {
    const response = await fetch(`/api/Order/GetOrdersByUserId/${user.id}`, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
      credentials: "include",
    });
    console.log(response);
    if (response.ok) {
      const data = await response.json();
      setOrders(data);
    }

    if (!response.ok) {
      notify("Failed to fetch orders", "error");
    }
  };

  useEffect(() => {
    fetchOrders();
  }, []);

  console.log(orders);
return (
    <table>
        <thead>
            <tr>
                <th>#</th>
                <th>Order ID</th>
                <th>Address</th>
                <th>Order Date</th>
                <th>Payment Type</th>
                <th>Payment Status</th>
                <th>Total Price</th>
            </tr>
        </thead>
        <tbody>
            {orders.map((order, i) => {
              return(
                <tr key={i}>
                  <th>{i+1}</th>
                  <td>{order.id}</td>
                  <td>{order.address}</td>
                  <td>{order.date}</td>
                  <td>{order.paymentType}</td>
                  <td>{order.status}</td>
                  <td>{order.totalPrice}</td>
                </tr>
              )
            })}
        </tbody>
    </table>
);
};

export default Orders;
