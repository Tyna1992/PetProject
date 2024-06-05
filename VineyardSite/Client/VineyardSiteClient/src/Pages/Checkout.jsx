import {useEffect, useState, useContext} from "react";
import "../index.css";
import OrderForm from "../Components/OrderForm.jsx";
import { UserContext } from "../Components/UserContext.jsx";

function Checkout() {
    const {user, setUser} = useContext(UserContext);
    const [cart, setCart] = useState([]);
    const [totalPrice, setTotalPrice] = useState(0);

    useEffect(() =>{
        async function GetCart()
        {
            const userName = user.userName;
                const response = await fetch(`/api/Cart/GetCart/${userName}`,{
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

                    const total = data.reduce((sum, item) => sum + (item.wineVersion.price * item.quantity), 0);
                    setTotalPrice(total);
                
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
                        <h3>{item.wineVersion.wine.name} - {item.quantity} - {item.wineVersion.price * item.quantity} HUF</h3>
                            
                        
                        
                        
                    </div>
                ))}
                <h3>Total: {totalPrice} HUF</h3>
            <h1>Check out</h1>
            <OrderForm />
        </div>
    </div>
    )
}
export default Checkout;