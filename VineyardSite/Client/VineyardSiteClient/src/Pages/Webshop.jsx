import {useEffect, useState} from "react";
import WebshopWineCard from "../Components/WebshopWineCard.jsx";
import "../index.css";
function Webshop() {
    const [inventory, setInventory] = useState([]);

    useEffect(()=>{
        async function getInventory(){
            try {
                const response = await fetch("/api/Inventory/GetInventory",{
                    method: "GET",
                    credentials: "include",
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
                </div>
            </div>
        </div>
    )
}

export default Webshop;