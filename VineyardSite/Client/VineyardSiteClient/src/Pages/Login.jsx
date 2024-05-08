import {useState} from "react";
import { useNavigate } from "react-router-dom";
import "../index.css";
import notify from "../Utils/Notify";

function Login() 
{
    const navigate = useNavigate();
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    
    async function handleSubmit(event) {
        event.preventDefault();
        try {
            const response = await fetch("/api/Auth/Login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({username, password})
            });
            if (!response.ok) {
                notify("Invalid username or password!", "error");
                throw new Error("Invalid credentials");
            }
            setPassword("");
            setUsername("");
            notify("Login successful!", "success");
            setTimeout(() => {
                navigate("/");
            }, 3100);
            


        } catch (error) {
            notify("Login failed!", "error");
            console.error(error);
        }
    }
    
    return(
        <div className="login">
            <h1>Login</h1>
            <div className="loginForm">
                <form onSubmit={handleSubmit}>
                    <label>
                        Username:
                    </label>
                    <br/>
                    <input type="text" name="username" value={username} onChange={(e) => setUsername(e.target.value)} />
                    <br/>
                    <label>
                        Password:
                    </label>
                    <br/>
                    <input type="password" name="password" value={password} onChange={(e) => setPassword(e.target.value)}/>
                    <br/>
                    <button type="submit">Login</button>
                    <button onClick={() => navigate("/")}>Cancel</button>                   
                      
                </form>
            </div>
        </div>
    )
}

export default Login;