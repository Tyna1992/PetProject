import {useEffect, useState} from "react";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";

function InventoryForm({addStock}) {
    const [hideForm, setHideForm] = useState(true);


  return (
    <div className="admin">
      <button type="button" onClick={() => setHideForm(false)}>Add drink to the inventory</button>
      <div>
        <form hidden={hideForm} onSubmit={addStock}>
        <label>
            Name:
        </label>
        <br/>
        <input required type="text" name="wineName"  />
        <br/>
        <label>
            Year:
        </label>
        <br/>
        <input required type="number" name="year"  />
        <br/>
        <label>
            Quantity:
        </label>
        <br/>
        <input required type="number" name="quantity"  />
        <br/>
        <button type="submit">Add</button>
        <button type="button" onClick={() => setHideForm(true)}>Cancel</button>
        </form>
      </div>
    </div>
  );
}

export default InventoryForm;