import TextareaAutosize from "react-textarea-autosize";
import notify from "../../Utils/Notify";
import React from "react";
import { useState } from "react";
import {useNavigate} from "react-router-dom";


function WineTastingForm(){
    const [formData, setFormData] = useState({
        name: "",
        email: "",
        phone: "",
        date: "",
        people: "",
        message: "",
        subject: "Wine tasting request",
    });
    const navigate = useNavigate();
    
    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };
    
    async function handleSubmit(e) {
        e.preventDefault();
        try {
            const response = await fetch("/api/EmailSender/sendRequestEmail", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(formData),
            });
            if (response.ok) {
                notify("Request sent successfully!", "success");
                setFormData({
                    name: "",
                    email: "",
                    phone: "",
                    date: "",
                    people: "",
                    message: "",
                });
            } else {
                notify("Request sending failed!", "error");
            }
        }
        catch (error)
            {
                console.error(error);
                notify("Something went wrong! Try later", "error");
            }

        }
    
    return (
        <div>
            <br></br>
            <h3>Request an offer!</h3>
            <br></br>
            <form onSubmit={handleSubmit}>
                <label>Email:</label>
                <br></br>
                <input type="text" required name="email" onChange={handleChange}  value={formData.email}></input>
                <br></br>
                <label>Name:</label>
                <br></br>
                <input type="text" required name="name" value={formData.name} onChange={handleChange}></input>
                <br></br>
                <label>Phone number:</label>
                <br></br>
                <input type="text" required name="phone" value={formData.phone} onChange={handleChange}></input>
                <br></br>
                <label>Number of people:</label>
                <br></br>
                <input type="number" required name="people" value={formData.people} onChange={handleChange}></input>
                <br></br>
                <label>Date:</label>
                <br></br>
                <input type="date" required name="date" value={formData.date} onChange={handleChange}></input>
                <br></br>
                <label>Message:</label>
                <br></br>
                <TextareaAutosize required name="message" className="textarea" value={formData.message} onChange={handleChange}></TextareaAutosize>
                <br></br>
                <button type="submit">Send request</button>
                <button onClick={() => navigate("/")} >Cancel</button>
            </form>
        </div>
    )
}

export default WineTastingForm;