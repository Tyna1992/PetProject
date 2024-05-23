import { useState, useEffect } from "react";
import "../index.css";


function InventoryTable({onDelete, onEdit})
{
    const [inventory, setInventory] = useState([]);

    useEffect(()=>{
        async function getInventory(){
            try {
                const response = await fetch("/api/Inventory/GetInventory",{
                    method: "GET",
                    credentials: "include",
                    headers: {
                        "Content-Type": "application/json"
                    }

                })
                if(response.ok)
                {
                    const data = await response.json();
                    console.log(data);
                    setInventory(data);
                }
            } catch (error) {
                console.error(error);
            }
        }
        getInventory();
    },[])

    return(
        <div className="inventoryTable">
            <table>
                <thead>
                    <tr>
                        <th>Wine Name</th>
                        <th>Year</th>
                        <th>Price</th>
                        <th>Alcohol Content</th>
                        <th>Quantity</th>
                        <th>Delete item</th>
                        <th>Edit item</th>
                    </tr>
                </thead>
                <tbody>
                    {inventory.map((item, index) => (
                        <tr key={index}>
                            <td>{item.name}</td>
                            <td>{item.year}</td>
                            <td>{item.price} HUF</td>
                            <td>{item.alcoholContent}%</td>
                            <td>{item.quantity} bottles</td>
                            <td><button onClick={() => onDelete}>Delete</button></td>
                            <td><button onClick={() => onEdit}>Edit</button></td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    )
}

export default InventoryTable;