import WineModal from "./WineModal.jsx";
import {useState} from "react";
function WebshopWineCard(data) {
    const wine = data.data;
    const [showModal, setShowModal] = useState(false);
    function handleMoreDetails() {
        setShowModal(true)
    }
    function closeModal() {
        setShowModal(false);
    }

    return (
        <div className={`${wine.name}-${wine.year}`}>
            <img
                src="https://media.nedigital.sg/fairprice/fpol/media/images/product/XL/10905268_XL1_20230510.jpg"
                alt="data" width="200px" height="200px"/>
            <h3>{wine.name}-{wine.year}</h3>
            <h3>{wine.price} HUF</h3>
            <button>Add to cart</button>
            <button onClick={handleMoreDetails}>More details</button>
            {showModal && <WineModal data={data} closeModal={closeModal}/>}
        </div>
    )
}

export default WebshopWineCard;