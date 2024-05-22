import {useEffect, useState} from "react";
import { useNavigate } from "react-router-dom";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";
import notify from "../Utils/Notify";


function Admin()
{
    const navigate = useNavigate();
    const [hideWineForm, setHideWineForm] = useState(true);

    
    
    async function addWines(event)
    {
        event.preventDefault();
        const name = event.target.wineName.value;
        const type = event.target.type.value;
        const sweetness = event.target.sweetness.value;
        const description = event.target.description.value;

        try {
            const response = await fetch("/api/Wine/addWine", {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({name, type, sweetness, description})
            
            })
            if(!response.ok)
            {
                notify("Failed to add drink to the catalog", "error");

            }
            notify("Drink added to the catalog", "success");
            event.target.wineName.value = "";
            event.target.type.value = "";
            event.target.sweetness.value = "";
            event.target.description.value = "";

            
        } catch (error) {
            notify("Failed to add drink to the catalog", "error");
            console.error(error);
        }
        
    }
    
    return(
        <div className="admin">
            <button type="button" onClick={()=> setHideWineForm(false)}>Add drink to the catalog</button>
            
            <div hidden={hideWineForm} className="wineForm">
                <form onSubmit={addWines}>
                    <label>
                        Name:
                    </label>
                    <br/>
                    <input type="text" name="wineName"  />
                    <br/>
                    <label>
                        Type:
                    </label>
                    <br/>
                    <select defaultValue={"DEFAULT"} name="type">
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
                    <select defaultValue={"DEFAULT"}  name="sweetness">
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
                    <TextareaAutosize className="textarea" name="description" />
                    <br/>
                    <button type="submit">Add</button>
                    <button type="button" onClick={()=> setHideWineForm(true)}>Cancel</button>
                    
                </form>
            </div>
        </div>
    )
}

export default Admin;