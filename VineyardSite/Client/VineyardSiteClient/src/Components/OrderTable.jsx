import React, {useState, useEffect} from "react";
import "../index.css";

function OrderTable() {
    const [orders, setOrders] = useState([]);
    
    useEffect(() => {
        async function getOrders() {
            try {
                const response = await fetch("/api/Order/GetOrders", {
                    method: "GET",
                    credentials: "include",
                    headers: {
                        "Content-Type": "application/json"                    
                    }
                }) 
                if (response.ok) {
                    const data = await response.json();
                    console.log(data);
                    setOrders(data)
                }
            } catch (error) {
                console.error(error)
            }
        }
        
        getOrders();
    }, [])
    
    return(
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
                <th>Edit</th>
                <th>Delete</th>
            </tr>
            </thead>
            <tbody>
            {orders.map((order, i) => {
                return (
                    <tr key={i}>
                        <th>{i + 1}</th>
                        <td>{order.id}</td>
                        <td>{order.address}</td>
                        <td>{order.date}</td>
                        <td>{order.paymentType}</td>
                        <td>{order.status}</td>
                        <td>{order.totalPrice}</td>
                        <td>
                            <button>Edit</button>
                        </td>
                        <td>
                            <button>Delete</button>
                        </td>
                    </tr>
                )
            })}
            </tbody>
        </table>
    )
}

export default OrderTable;