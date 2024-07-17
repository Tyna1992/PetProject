import "../index.css";
import {useContext, useEffect, useState} from "react";
import {UserContext} from "./UserContext.jsx";
import notify from "../Utils/Notify";

function OrderForm() {
    const {user, setUser} = useContext(UserContext);
    const [address, setAddress] = useState([]);

    async function sendOrder(event) {
        event.preventDefault();
        const payment = event.target.payment.value;
        const delivery = event.target.delivery.value;
        const notes = event.target.notes.value;
        const userAddress = event.target.address.value;
        const userId = user.id;
        console.log(user);

        try {
            const response = await fetch("/api/Order/AddOrder", {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    UserId: userId,
                    PaymentType: payment,
                    DeliveryType: delivery,
                    Notes: notes,
                    Address: userAddress
                })
            })
            if (response.ok) {
                notify("Order sent", "success")
            }
        } catch (error) {
            notify("Error sending order", "error")
        }
    }

    async function GetUserAddress() {
        try {
            const response = await fetch(`api/User/GetAllAddress/${user.id}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                },
                credentials: "include"
            });
            if (!response.ok) {
                throw new Error("Failed to fetch user address");
            }
            const data = await response.json();
            setAddress(data);
            console.log(address);
        } catch (e) {
            console.error(e);
        }
    }

    useEffect(() => {
        if (user && user.id) {
            GetUserAddress();
        }
    }, [user]);
    return (
        <div className="orderForm">
            <div>
                <form onSubmit={sendOrder}>
                    <label>
                        Payment
                    </label>
                    <br/>
                    <select name="payment">
                        <option value="Card">Credit Card</option>
                        <option value="Transfer">Bank transfer</option>
                        <option value="CoD">Cash on delivery</option>
                        <option value="CoP">Cash on pickup</option>
                    </select>
                    <br/>
                    <label>
                        Delivery:
                    </label>
                    <br/>
                    <select name="delivery">
                        <option value="Pickup">Pickup</option>
                        <option value="GLS-point">GLS parcel point</option>
                        <option value="GLS-home">GLS Home delivery</option>
                        <option value="GLS-machine">GLS parcel machine</option>
                    </select>
                    <br/>
                    <label>
                        Address:
                    </label>
                    <br/>
                    <select name="address">
                        {address.map((item)=>{
                           return <option key={item.addressId} value={item}>{item.city}, {item.street}</option>
                        })}
                    </select>
                    <br/>
                    <label>
                        Note to the seller:
                    </label>
                    <br/>
                    <input type="text" name="notes"/>
                    <br/>
                    <button type="submit">Send Order</button>
                    <button type="button">Cancel</button>
                </form>
            </div>
        </div>
    )

}

export default OrderForm;