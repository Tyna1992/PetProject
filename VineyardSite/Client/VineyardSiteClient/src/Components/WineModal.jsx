import "../index.css";
function WineModal({data, closeModal}) {
    const wine = data.data;
    return (
        <div className="modal-backdrop">
            <div className="modal">
                <img
                    src="https://media.nedigital.sg/fairprice/fpol/media/images/product/XL/10905268_XL1_20230510.jpg"
                    alt="data" width="200px" height="200px"/>

                <h3 className="modal-wine-name">{wine.name}-{wine.year}</h3>
                <h3 className="modal-wine-price">{wine.price} HUF</h3>
                <button>Add to cart</button>
                <button onClick={() => closeModal()}>Close</button>
            </div>
        </div>
    )
}

export default WineModal;