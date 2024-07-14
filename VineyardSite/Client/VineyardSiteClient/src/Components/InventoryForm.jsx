import "../index.css";

function InventoryForm({ wineName, getVintageByName}) {
  
  

  return (
    <div>
      
      <div>
        <form  onSubmit={getVintageByName}>
        <label>
            Name:
        </label>
        <br/>
            <select required defaultValue={"DEFAULT"} name="wineName">
                <option value="DEFAULT" disabled>Select please</option>
                {wineName.map((wine) => {
                    return <option key={wine.id} value={wine.id}>{wine.name}</option>
                })}
            </select>
        <br/>
        <button type="submit">Select</button>
        <button type="button">Cancel</button>
        </form>
      </div>
    </div>
  );
}

export default InventoryForm;