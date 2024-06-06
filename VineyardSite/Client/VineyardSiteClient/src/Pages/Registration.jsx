import {useState} from 'react';
import {useNavigate} from 'react-router-dom';
import {toast, ToastContainer} from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import notify from '../Utils/Notify';
import '../index.css';

function RegisterUser() {
    const navigate = useNavigate();
    
   
    async function handleSubmit(event) {
        event.preventDefault();
        const username = event.target.username.value;
        const email = event.target.email.value;
        const password = event.target.password.value;
        const user = {username, email, password};
        
        try{
            const response = await fetch("/api/Auth/Register",{
                method: "POST",
                headers:{
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(user)
                
            });
            if(!response.ok){
                throw new Error("Registration failed!");
            }
            notify("Registration successful!", "success");
           
            const loginResponse = await fetch("/api/Auth/Login",{
                method: "POST",
                headers:{
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({username, password})
            });
            if(!loginResponse.ok){
                throw new Error("Login failed!");
            }
            notify("Login successful!", "success");
            setTimeout(() => {
                navigate("/");
            }, 3100);
            
        }
        catch(error){
            console.error(error);
        }
    }
    
    return(
        <div className="registration">
            <form className="regFrom" onSubmit={handleSubmit}>
                <label>Username:</label>
                <br></br>
                <input type="text" name="username"></input>
                <br></br>
                <label>Email:</label>
                <br></br>
                <input type="email" name="email"></input>
                <br></br>
                <label>Password:</label>
                <br></br>
                <input type="password" name="password"></input>
                <br></br>
                <br></br>
                <button type="submit">Create account</button>
                <button type="button" onClick={() => navigate("/")}>
                    Cancel
                </button>
            </form>
            
        </div>
    )
}

export default RegisterUser;