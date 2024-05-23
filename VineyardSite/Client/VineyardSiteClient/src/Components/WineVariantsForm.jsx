import {useEffect, useState} from "react";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";

function WineVariantsForm({addVinatge}) {

    const [hideForm, setHideForm] = useState(true);
    return(
        <div className="admin">
            <button type="button" onClick={()=> setHideForm(false)}>Add vintage to the catalog </button>
            <div className="vintageForm">
                <form hidden={hideForm} onSubmit={addVinatge}>
                    <label>
                        Name:
                    </label>
                    <br/>
                    <input required type="text" name="name"></input>
                    <br/>
                    <label>
                        Price:
                    </label>
                    <br/>
                    <input required type="number" name="price"></input>
                    <br/>
                    <label>
                        Alcohol:
                    </label>
                    <br/>
                    <input required type="number" name="alcohol"></input>
                    <br/>
                    <label>
                        Year:
                    </label>
                    <br/>
                    <input required type="number" name="year"></input>
                    <br/>
                    <button type="submit">Add</button>
                    <button type="button" onClick={() => setHideForm(true)}>Cancel</button>
                </form>
            </div>
        </div>
    )
}

export default WineVariantsForm;