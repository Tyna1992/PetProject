import React, { useState, useEffect } from "react";
import notify from "../Utils/Notify.jsx";
import "../index.css";

function OrderTable() {
    const [orders, setOrders] = useState([]);
    const [selectedOrderId, setSelectedOrderId] = useState(null);
    const [editedStatus, setEditedStatus] = useState("");

    const handleEdit = (order) => {
        setSelectedOrderId(order.id);
        setEditedStatus(order.status);
    };

    const handleStatusChange = (event) => {
        setEditedStatus(event.target.value);
    };

    const handleCancelClick = () => {
        setSelectedOrderId(null);
        setEditedStatus("");
    };

    const handleSave = async (order) => {
        const updatedOrder = { ...order, status: editedStatus };
        try {
            const response = await fetch(`api/Order/UpdateOrder/${order.id}/${updatedOrder.status}`, {
                method: "PATCH",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(order.id,updatedOrder.status)
            });
            if (response.ok) {
                setOrders(orders.map(o => o.id === order.id ? updatedOrder : o));
                notify("Order updated successfully", "success")
                setSelectedOrderId(null);
                setEditedStatus("");
            } else {
                notify('Failed to update order status', "error");
            }
        } catch (err) {
            console.error(err);
        }
    };

    useEffect(() => {
        async function getOrders() {
            try {
                const response = await fetch("/api/Order/GetOrders", {
                    method: "GET",
                    credentials: "include",
                    headers: {
                        "Content-Type": "application/json"
                    }
                });
                if (response.ok) {
                    const data = await response.json();
                    setOrders(data);
                }
            } catch (error) {
                console.error(error);
            }
        }

        getOrders();
    }, []);

    return (
        <table>
            <thead>
            <tr>
                <th>#</th>
                <th>Order ID</th>
                <th>Email</th>
                <th>Address</th>
                <th>Delivery Type</th>
                <th>Order Date</th>
                <th>Payment Type</th>
                <th>Order Status</th>
                <th>Total Price</th>
                <th>Edit</th>
            </tr>
            </thead>
            <tbody>
            {orders.map((order, i) => (
                <tr key={i}>
                    <th>{i + 1}</th>
                    <td>{order.id}</td>
                    <td>{order.email}</td>
                    <td>{order.address}</td>
                    <td>{order.deliveryType}</td>
                    <td>{order.date}</td>
                    <td>{order.paymentType}</td>
                    <td>
                        {selectedOrderId === order.id ? (
                            <select value={editedStatus} onChange={handleStatusChange}>
                                <option value="Pending">Pending</option>
                                <option value="In delivery">In delivery</option>
                                <option value="Completed">Completed</option>
                                <option value="Deleted">Deleted</option>
                            </select>
                        ) : (
                            order.status
                        )}
                    </td>
                    <td>{order.totalPrice}</td>
                    <td>
                        {selectedOrderId === order.id ? (
                            <>
                                <button onClick={() => handleSave(order)}>Save</button>
                                <button onClick={handleCancelClick}>Cancel</button>
                            </>
                        ) : (
                            <button onClick={() => handleEdit(order)}>Edit</button>
                        )}
                    </td>
                </tr>
            ))}
            </tbody>
        </table>
    );
}

export default OrderTable;
