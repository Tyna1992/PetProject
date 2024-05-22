import {useEffect, useState} from "react";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";

function WineVariantsForm({addVinatge}) {

    return(
        <div className="admin">
            <button type="button">Add vintage </button>
            <div className="vintageForm">
                <form onSubmit={addVinatge}>
                    <label>
                        Name:
                    </label>
                    <br/>
                    <input type="text" name="name"></input>
                    <br/>
                    <label>
                        Price:
                    </label>
                    <br/>
                    <input type="number" name="price"></input>
                    <br/>
                    <label>
                        Alcohol:
                    </label>
                    <br/>
                    <input type="number" name="alcohol"></input>
                    <br/>
                    <label>
                        Year:
                    </label>
                    <br/>
                    <input type="number" name="year"></input>
                    <br/>
                    <button type="submit">Add</button>
                    <button type="button">Cancel</button>
                </form>
            </div>
        </div>
    )
}

export default WineVariantsForm;