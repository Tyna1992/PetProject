import {useEffect, useState} from "react";
import { useNavigate } from "react-router-dom";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";
import notify from "../Utils/Notify";


function Admin()
{
    const navigate = useNavigate();
    const [hideWineForm, setHideWineForm] = useState(true);
    const [hideSnackForm, setHideSnackForm] = useState(true);
    const [hidePackageForm, setHidePackageForm] = useState(true);
    
    
    async function addWines(event)
    {
        event.preventDefault();
        const wineName = event.target.wineName.value;
        const type = event.target.type.value;
        const price = parseFloat(event.target.price.value);
        const alcoholPercentage = parseFloat(event.target.alcoholPercentage.value);
        const description = event.target.description.value;
        const year = parseInt(event.target.year.value);
        
        try {
            const response = await fetch("/api/Wine/AddWine", {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    "Name": wineName,
                    "Type": type,
                    "AlcoholContent": alcoholPercentage,
                    "Price": price,
                    "Description": description,
                    "Year": year

                })

            })
            console.log(response);
            if (!response.ok) {
                notify("Failed to add wine to the inventory!", "error");
                throw new Error("Failed to add wine to the inventory!");
            }
            notify("Wine added to the inventory!", "success");
            event.target.wineName.value = "";
            event.target.type.value = "";
            event.target.price.value = "";
            event.target.alcoholPercentage.value = "";
            event.target.description.value = "";
        }
        
        catch (error) {
            notify("Failed to add wine to the inventory!", "error");
            console.error(error);
        }        
    }
    
    return(
        <div className="admin">
            <button type="button" onClick={()=> setHideWineForm(false)}>Add wines to the inventory</button>
            <button type="button">Add snacks to the inventory</button>
            <button type="button">Create wine tasting package</button>
            <div hidden={hideWineForm} className="wineForm">
                <form onSubmit={addWines}>
                    <label>
                        Wine name:
                    </label>
                    <br/>
                    <input type="text" name="wineName"  />
                    <br/>
                    <label>
                        Wine type:
                    </label>
                    <br/>
                    <select name="type">
                        <option disabled selected >Select please</option>
                        <option value="red">Red</option>
                        <option value="white">White</option>
                        <option value="rose">Rose</option>
                    </select>
                    <br/>
                    <label>
                        Price:
                    </label>
                    <br/>
                    <input type="number" name="price" />
                    <br/>
                    <label>
                        Year:
                    </label>
                    <br/>
                    <input type="number" name="year" />
                    <br/>
                    <label>
                        Alcohol percentage:
                    </label>
                    <br/>
                    <input type="number" name="alcoholPercentage" />
                    <br/>
                    <label>
                        Description:
                    </label>
                    <br/>
                    <TextareaAutosize name="description" />
                    <br/>
                    <button type="submit">Add</button>
                    <button type="button" onClick={()=> setHideWineForm(true)}>Cancel</button>
                    
                </form>
            </div>
        </div>
    )
}

export default Admin;