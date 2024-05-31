function WebshopWineCard(data) {
    const wine = data.data;
    return (
        <div className={`${wine.name}-${wine.year}`}>
            <img
                src="https://media.nedigital.sg/fairprice/fpol/media/images/product/XL/10905268_XL1_20230510.jpg"
                alt="data" width="200px" height="200px"/>
            <h3>{wine.name}-{wine.year}</h3>
            <h3>{wine.price} HUF</h3>
            <button>Add to cart</button>
            <button>More details</button>
        </div>
    )
}

export default WebshopWineCard;