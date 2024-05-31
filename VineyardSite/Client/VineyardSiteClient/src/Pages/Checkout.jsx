import {useEffect, useState} from "react";
import "../index.css";
import OrderForm from "../Components/OrderForm.jsx";

function Checkout() {

    return (
        <div>
            <h1>Check out</h1>
            <OrderForm />
        </div>
    )
}
export default Checkout;