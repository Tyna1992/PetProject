import {useEffect, useState} from "react";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";
import notify from "../Utils/Notify";
import WineForm from "../Components/WineForm";
import WineVariantsForm from "../Components/WineVariantsForm";


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

    async function addWineVariants(event) {
        event.preventDefault();
        const name = event.target.name.value;
        const price = parseFloat(event.target.price.value);
        const alcohol = parseFloat(event.target.alcohol.value);
        const year = parseInt(event.target.year.value);
        
        
            const response = await fetch(`/api/Variant/AddWineVariant/${name}/${price}/${alcohol}/${year}`, {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    name: name,
                    price: price,
                    alcohol: alcohol,
                    year: year
                
                }),
                
            })
            console.log(response.body);
            console.log(response);
            if(!response.ok) {
                notify("Failed to add vintage to the catalog", "error");
            }
            notify("Vintage added to the catalog", "success");
            event.target.name.value = "";
            event.target.price.value = "";
            event.target.alcohol.value = "";
            event.target.year.value = "";


    }

    
    return(
        <div className="admin">
            <WineForm addWines={addWines} />
            <WineVariantsForm addVinatge={addWineVariants}/>
        </div>
    )
}

export default Admin;