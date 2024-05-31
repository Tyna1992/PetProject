import {useState} from "react";
import WebshopWineCard from "../Components/WebshopWineCard.jsx";
import "../index.css";
function Webshop() {
    const [wine, setWine] = useState({name: "Chardonnay", year: 2010, price: 3200});

    return (
        <div className="webshop">
            <div className="webshop-container-wrapper">
                <div className="webshop-container">
                    <WebshopWineCard data={wine}/>
                </div>
            </div>
        </div>
    )
}

export default Webshop;