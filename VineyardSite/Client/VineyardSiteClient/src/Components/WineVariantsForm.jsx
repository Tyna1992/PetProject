import {useEffect, useState} from "react";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";

function WineVariantsForm({addVinatge, wineName}) {

    const [hideForm, setHideForm] = useState(true);
    return(
        <div>
            
            <div className="vintageForm">
                <form  onSubmit={addVinatge}>
                    <label>
                        Name:
                    </label>
                    <br/>
                    <select required defaultValue={"DEFAULT"} name="name">
                        <option value="DEFAULT" disabled>Select please</option>
                        {wineName.map(wine => {
                            return <option key={wine.id} value={wine.name}>{wine.name}</option>
                        })}

                    </select>
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