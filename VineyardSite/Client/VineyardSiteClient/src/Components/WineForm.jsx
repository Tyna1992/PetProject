import {useEffect, useState} from "react";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";


function WineForm({addWines}){

    

    return(
        <div>
            
            
            <div className="wineForm">
                <form onSubmit={addWines}>
                    <label>
                        Name:
                    </label>
                    <br/>
                    <input type="text" name="wineName" required />
                    <br/>
                    <label>
                        Type:
                    </label>
                    <br/>
                    <select required defaultValue={"DEFAULT"} name="type">
                        <option value="DEFAULT" disabled  >Select please</option>
                        <option value="Red">Red</option>
                        <option value="White">White</option>
                        <option value="Rose">Rose</option>
                        <option value="Petnat">Pét-Nat</option>
                        <option value="Non-alcohol">Non-Alcoholic</option>
                        
                    </select>
                    <br/>
                    <label>
                        Sweetness:
                    </label>
                    <br/>
                    <select required defaultValue={"DEFAULT"}  name="sweetness">
                        <option value="DEFAULT" disabled  >Select please</option>
                        <option value="Dry">Dry</option>
                        <option value="Semi-dry">Semi-Dry</option>
                        <option value="Sweet">Sweet</option>
                        <option value="Semi-sweet">Semi-Sweet</option>
                        <option value="Non-alcohol">Non-Alcoholic</option>
                        
                    </select>
                    <br/>
                    <label>
                        Description:
                    </label>
                    <br/>
                    <TextareaAutosize required className="textarea" name="description" />
                    <br/>
                    <button type="submit">Add</button>
                    <button type="button" onClick={()=> setHideWineForm(true)}>Cancel</button>
                    
                </form>
            </div>
        </div>
    )
}

export default WineForm;