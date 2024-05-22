import {useEffect, useState} from "react";
import TextareaAutosize from 'react-textarea-autosize';
import "../index.css";
import notify from "../Utils/Notify";
import WineForm from "../Components/WineForm";
import WineVariantsForm from "../Components/WineVariantsForm";
import InventoryForm from "../Components/InventoryForm";


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
            if(response.status === 404) {
                notify("Failed to add vintage to the catalog, please check the name!", "error");
                event.target.name.value = "";
                event.target.price.value = "";
                event.target.alcohol.value = "";
                event.target.year.value = "";
                throw new Error("Failed to add vintage to the catalog");
            }
            notify("Vintage added to the catalog", "success");
            event.target.name.value = "";
            event.target.price.value = "";
            event.target.alcohol.value = "";
            event.target.year.value = "";
    }

    async function addStock(event)
    {
        event.preventDefault();
        const wineName = event.target.wineName.value;
        const year = parseInt(event.target.year.value);
        const quantity = parseInt(event.target.quantity.value);
        try {
            const response = await fetch(`/api/Inventory/AddInventory/${wineName}/${year}/${quantity}`, {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    wineName: wineName,
                    year: year,
                    quantity: quantity
                })
            })
            if(!response.ok)
            {
                notify("Failed to add stock", "error");
                throw new Error("Failed to add stock");
            }
            notify("Stock added", "success");
            event.target.wineName.value = "";
            event.target.year.value = "";
            event.target.quantity.value = "";

        } catch (error) {
            notify("An error occured adding stock", "error");
            console.error(error);
        }
    }
    
    return(
        <div className="admin-container">
            <WineForm addWines={addWines} />
            <WineVariantsForm addVinatge={addWineVariants}/>
            <InventoryForm addStock={addStock} />

        </div>
    )
}

export default Admin;