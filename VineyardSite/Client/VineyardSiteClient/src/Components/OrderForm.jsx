import "../index.css";

function OrderForm() {
    return (
        <div className="orderForm">
            <div>
                <form>
                    <label>
                        Email:
                    </label>
                    <br/>
                    <input required type="email" name="orderEmail"/>
                    <br/>
                    <label>
                        Address:
                    </label>
                    <br/>
                    <input required type="text" name="orderAddress"/>
                    <br/>
                    <label>
                        Quantity:
                    </label>
                    <br/>
                    <input required type="number" name="orderQuantity"/>
                    <br/>
                    <button type="submit">Send Order</button>
                    <button type="button">Cancel</button>
                </form>
            </div>
        </div>
    )
}

export default OrderForm;