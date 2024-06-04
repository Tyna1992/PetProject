import {useEffect, useState, useContext} from "react";
import WebshopWineCard from "../Components/WebshopWineCard.jsx";
import "../index.css";
import { UserContext } from "../Components/UserContext.jsx";

function Webshop() {
    const [inventory, setInventory] = useState([]);
    const {user, setUser} = useContext(UserContext);

    useEffect(()=>{
        async function getInventory(){
            try {
                const response = await fetch("/api/Inventory/GetInventory",{
                    method: "GET",
                    headers: {
                        "Content-Type": "application/json"
                    }

                })
                if(response.ok)
                {
                    const data = await response.json();
                    console.log(data);
                    setInventory(data);
                }
                
            } catch (error) {
                console.error(error);
            }
        }
        getInventory();
    },[])
    return (
        <div className="webshop">
            <div className="webshop-container-wrapper">
                <div className="webshop-container">
                    {inventory.map((item, index) => (
                        <WebshopWineCard key={`${item.name}-${index}`} data={item}/>
                    ))}
                </div>
            </div>
        </div>
    )
}

export default Webshop;