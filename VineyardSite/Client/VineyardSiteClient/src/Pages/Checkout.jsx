import {useEffect, useState, useContext} from "react";
import "../index.css";
import OrderForm from "../Components/OrderForm.jsx";
import { UserContext } from "../Components/UserContext.jsx";

function Checkout() {
    const {user, setUser} = useContext(UserContext);
    const [cart, setCart] = useState([]);

    useEffect(() =>{
        async function GetCart()
        {
            
                const response = await fetch(`/api/Cart/GetCart/${user}`,{
                    method: "GET",
                    credentials: "include",
                    headers: {
                        "Content-Type": "application/json"
                    }
                })
                if(response.ok)
                {
                    const data = await response.json();
                    setCart(data);
                    console.log(data);
                
                }


        }
        GetCart();
    },[])

    return (
        <div>
            <h1>Cart</h1>
            <div>
                {cart.map((item, index) => (
                    <div key={`${item.drinkName}-${index}`}>
                        <h3>{item.drinkName}</h3>
                        <h3>{item.quantity}</h3>
                        
                    </div>
                ))}
            <h1>Check out</h1>
            <OrderForm />
        </div>
    </div>
    )
}
export default Checkout;