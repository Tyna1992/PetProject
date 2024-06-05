import {useState, useEffect} from 'react'
import {Link, Outlet, useLocation} from 'react-router-dom'
import './index.css'
import LogoutButton from './Components/LogoutButton.jsx';
import { UserContext } from './Components/UserContext.jsx';
function Home() {
    const [user, setUser] = useState(null);
    const location = useLocation();

    useEffect(() => {
        async function fetchData() {
            try {
                const response = await fetch("/api/Auth/WhoAmI", {
                    method: "GET",
                    credentials: "include",
                    headers: {
                        "Content-Type": "application/json",
                    },
                });
                const data = await response.json();
                if (data) {
                    setUser({ userName: data.userName, id: data.id});
                }
            } catch (error) {
                console.error(error);
            }
        }

        fetchData();
    }, [location.pathname]);

    return (
            <UserContext.Provider value={{user, setUser}}>
            <div className="Layout">
                <nav>
                    <Link to="/">
                    <img src="/Images/logo.jpg" alt="logo" className="links"/>
                </Link>
                    {user === null ? (
                        <>
                            <Link to="/register">
                                <button className="homeButton" type="button">Register</button>
                            </Link>
                            <Link to="/login">
                                <button className="homeButton" type="button">Login</button>
                            </Link>
                            <Link to="/webshop">
                                <button className="homeButton" type="button">Webshop</button>
                            </Link>
                            <Link to="/winetasting">
                                <button className="homeButton" type="button">Wine tasting</button>
                            </Link>
                            <Link to="/about">
                                <button className="homeButton" type="button">About us</button>
                            </Link>
                            <Link to="/contact">
                                <button className="homeButton" type="button">Contact</button>
                            </Link>
                            <Link to="/checkout">
                                <button className="homeButton" type="button">Cart</button>
                            </Link>
                        </>
                    ) : user !== "admin" ? (
                        <>
                            <Link  to="/profile">
                                <button className="homeButton" type="button">Profile</button>
                            </Link>

                            <Link to="/webshop">
                                <button className="homeButton" type="button">Webshop</button>
                            </Link>
                            <Link to="/winetasting">
                                <button className="homeButton" type="button">Wine tasting</button>
                            </Link>
                            <Link to="/about">
                                <button className="homeButton" type="button">About us</button>
                            </Link>
                            <Link to="/contact">
                                <button className="homeButton" type="button">Contact</button>
                            </Link>
                            <Link to="/checkout">
                                <button className="homeButton" type="button">Cart</button>
                            </Link>
                            <LogoutButton/>

                        </>
                    ) : (
                        <>
                            <Link to="/admin">
                                <button className="homeButton" type="button">Admin site</button>
                            </Link>
                            <Link to="/webshop">
                                <button className="homeButton" type="button">Webshop</button>
                            </Link>
                            <Link to="/winetasting">
                                <button className="homeButton" type="button">Wine tasting</button>
                            </Link>
                            <Link  to="/about">
                                <button className="homeButton" type="button">About us</button>
                            </Link>
                            <Link to="/contact">
                                <button className="homeButton" type="button">Contact</button>
                            </Link>
                            <Link to="/checkout">
                                <button className="homeButton" type="button">Cart</button>
                            </Link>
                            <LogoutButton/>
                        </>
                    )}
                </nav>
                <Outlet/>
                
            </div>
            </UserContext.Provider>

    )
}

export default Home
