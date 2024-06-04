import WineModal from "./WineModal.jsx";
import {useState, useContext} from "react";
import { useNavigate } from "react-router-dom";
import notify from "../Utils/Notify";
import { UserContext } from "./UserContext.jsx";


function WebshopWineCard(data) {
    const wine = data.data;
    const [showModal, setShowModal] = useState(false);
    const {user, setUser} = useContext(UserContext);
    const navigate = useNavigate();

    function handleMoreDetails() {
        setShowModal(true)
    }
    function closeModal() {
        setShowModal(false);
    }

    async function addToCart(id)
    {
        const userName = user.userName;
        
        const quantity = 1;
        
        try {
            const response = await fetch(`/api/Cart/AddCartItem/${id}/${quantity}/${userName}`,
            {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({id, quantity, userName})
            })
            if(response.ok)
            {
                notify("Item added to cart", "success")
            }
            else
            {
                notify("Error adding item to cart", "error")
            }
        } catch (error) {
            console.error(error);
            notify("Error adding item to cart", "error")
        }
    }

    return (
        <div className={`${wine.name}-${wine.year}`}>
            <img
                src="https://media.nedigital.sg/fairprice/fpol/media/images/product/XL/10905268_XL1_20230510.jpg"
                alt="data" width="200px" height="200px"/>
            <h3>{wine.name}-{wine.year}</h3>
            <h3>{wine.price} HUF</h3>
            <button onClick={()=> addToCart(wine.drinkId)}>Add to cart</button>
            <button onClick={handleMoreDetails}>More details</button>
            {showModal && <WineModal data={data} closeModal={closeModal}/>}
        </div>
    )
}

export default WebshopWineCard;