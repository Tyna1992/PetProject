import {useEffect, useState} from "react";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";

function InventoryForm({addStock}) {
    


  return (
    <div>
      
      <div>
        <form  onSubmit={addStock}>
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
            Alcohol:
        </label>
        <br/>
        <input required type="number" name="alcohol"  />
        <br/>
        <label>
            Quantity:
        </label>
        <br/>
        <input required type="number" name="quantity"  />
        <br/>
        <button type="submit">Add</button>
        <button type="button">Cancel</button>
        </form>
      </div>
    </div>
  );
}

export default InventoryForm;