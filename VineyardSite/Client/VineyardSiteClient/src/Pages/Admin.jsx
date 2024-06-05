import { useState } from "react";
import InventoryTable from "../Components/InventoryTable";
import "../index.css";
import notify from "../Utils/Notify";
import WineForm from "../Components/WineForm";
import WineVariantsForm from "../Components/WineVariantsForm";
import InventoryForm from "../Components/InventoryForm";


function Admin() {
    const [showInventory, setShowInventory] = useState(false);
    const [hideWineForm, setHideWineForm] = useState(false);
    const  [hideVintageForm, setHideVintageForm] = useState(false);
    const [hideInventoryForm, setHideInventoryForm] = useState(false);
    
    const handleClick = () => {
        setShowInventory(!showInventory);
    }

    const handleClickWineForm = () => {
        setHideWineForm(!hideWineForm);
    }

    const handleClickVintageForm = () => {
        setHideVintageForm(!hideVintageForm);
    }

    const handleClickInventoryForm = () => {
        setHideInventoryForm(!hideInventoryForm);
    }

    async function addWines(event) {
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
                body: JSON.stringify({ name, type, sweetness, description })

            })
            if (!response.ok) {
                notify(`The drink, ${name} is already in the catalog`, "error");

            }
            else {
                notify(`${name} added to the catalog`, "success");
                event.target.wineName.value = "";
                event.target.type.value = "";
                event.target.sweetness.value = "";
                event.target.description.value = "";

            }


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

        if (response.status === 404) {
            notify("Failed to add vintage to the catalog, please check the name!", "error");

        }
        else if (response.status === 500) {
            notify(`Vintage ${name} - ${year} with ${alcohol}% and ${price} HUF already in the catalog`, "error");
        }
        else if (response.status === 406) {
            notify("Invalid year", "error");
        }
        else {

            notify(`Vintage, ${name} - ${year} with ${alcohol}% and ${price} HUF added to the catalog`, "success");
            event.target.name.value = "";
            event.target.price.value = "";
            event.target.alcohol.value = "";
            event.target.year.value = "";
        }
    }

    async function addStock(event) {
        event.preventDefault();
        const wineName = event.target.wineName.value;
        const year = parseInt(event.target.year.value);
        const quantity = parseInt(event.target.quantity.value);
        const alcohol = parseFloat(event.target.alcohol.value);
        try {
            const response = await fetch(`/api/Inventory/AddInventory/${wineName}/${year}/${quantity}/${alcohol}`, {
                method: "POST",
                credentials: "include",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    wineName: wineName,
                    year: year,
                    quantity: quantity,
                    alcohol: alcohol
                })
            })
            if (response.status === 404) {
                notify(`${wineName} or ${wineName} - ${year} not in the catalog`, "error");

            }
            else {
                notify(`${wineName}-${year} added ${quantity} bottles to the inventory `, "success");
                event.target.wineName.value = "";
                event.target.year.value = "";
                event.target.quantity.value = "";
                event.target.alcohol.value = "";

            }

        } catch (error) {
            notify("An error occured adding stock", "error");
            console.error(error);
        }
    }

    return (
        <div className="admin">
            <div className="admin-buttons">
            <button type="button" onClick={handleClickWineForm}>{hideWineForm ? "Close wine-cataloge form" : "Add drink to the catalog"} </button>
            <button type="button" onClick={handleClickVintageForm}>{hideVintageForm ? "Close vintage-form" : "Add vintage to the catalog"} </button>
            <button type="button" onClick={handleClickInventoryForm}>{hideInventoryForm ? "Close inventory-form" : "Add vintage to the inventory"}</button>
            <button onClick={handleClick}>{showInventory ? 'Hide' : 'Show'} Inventory
                </button>
            </div>
            <div className="admin-container-wrapper">
            <div className="admin-container">
            {hideWineForm && <WineForm addWines={addWines} />}
            {hideVintageForm && <WineVariantsForm addVinatge={addWineVariants} />}
            {hideInventoryForm && <InventoryForm addStock={addStock} />}
            </div>
            </div>
            <div className="table">
            {showInventory && <InventoryTable />}
            </div>
            
        </div>
    )
}

export default Admin;