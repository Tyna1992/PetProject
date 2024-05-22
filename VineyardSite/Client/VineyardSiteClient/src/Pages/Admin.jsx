import {useEffect, useState} from "react";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";
import notify from "../Utils/Notify";
import WineForm from "../Components/WineForm";


function Admin()
{


    
    
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
            <WineForm addWines={addWines} />
        </div>
    )
}

export default Admin;