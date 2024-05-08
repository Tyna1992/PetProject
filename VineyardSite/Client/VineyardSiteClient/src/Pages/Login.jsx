import {useState} from "react";
import { useNavigate } from "react-router-dom";

function Login() 
{
    const navigate = useNavigate();
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    
    return(
        <div className="login">
            <h1>Login</h1>
            <div className="container">
                <form>
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
                    <input type="text" name="password" value={password} onChange={(e) => setPassword(e.target.value)}/>
                    <br/>
                    <button type="submit">Login</button>
                    <button onClick={() => navigate("/")}>Cancel</button>                   
                       <button/> 
                </form>
            </div>
        </div>
    )
}

export default Login;