import "../index.css";

function InventoryDetailsForm({addStock, wineVintage}) {
    return (
        <div>
            <label>
                Name:
            </label>
            <form onSubmit={addStock}>
                <select disabled={true} name="wineName">
                    <option value={wineVintage[0].wine.name}>{wineVintage[0].wine.name}</option>
                </select>
                <br/>
                <label>
                    Year:
                </label>
                <br/>
                <select required defaultValue={"DEFAULT"} name="year">
                    <option value="DEFAULT" disabled>Select please</option>
                    {wineVintage.map((wine) => {
                        return <option key={wine.id}
                                       value={`${wine.year} ${wine.alcoholContent}`}>{wine.year + " " + `(${wine.alcoholContent}%)`}</option>
                    })}
                </select>
                <br/>
                <label>
                    Quantity:
                </label>
                <br/>
                <input required type="number" name="quantity"/>
                <br/>
                <button>Submit</button>
            </form>
        </div>
    )
}

export default InventoryDetailsForm;