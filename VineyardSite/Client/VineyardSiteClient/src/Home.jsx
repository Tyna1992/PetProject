import {useState, useEffect} from 'react'
import {Link, Outlet, useLocation} from 'react-router-dom'
import './index.css'

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
                    setUser(data.userName);
                }
            } catch (error) {
                console.error(error);
            }
        }
        fetchData();
    }, [location.pathname]);

        return (
            
                <div className="home">
                    <div className="container">
                        <Link to="/">
                            <img src="/logo.jpg" alt="logo" className="image"/>
                        </Link>
                        
                    </div>
                    <div className="Layout">
                        <nav>
                            {user === null ? (
                                <>
                                    <Link to="/register">
                                        <button type="button">Register</button>
                                    </Link>
                                    <Link to="/login">
                                        <button type="button">Login</button>
                                    </Link>
                                </>
                            ) : user !== "admin" ? (
                                <>
                                    <Link to="/profile">
                                        <button type="button">Profile</button>
                                    </Link>
                                    
                                    <Link to="/webshop">
                                        <button type="button"> Webshop </button>
                                    </Link>
                                    <Link to="/winetasting">
                                        <button type="button">Wine tasting</button>
                                    </Link>
                                    <Link to="/about">
                                        <button type="button">About us</button>
                                    </Link>
                                    <Link to="/contact">
                                        <button type="button">Contact</button>
                                    </Link>
                                    
                                </>
                            ) : (
                                <>
                                    <Link to="/admin">
                                        <button type="button">Admin site</button>
                                    </Link>
                                    
                                </>
                            )}
                            <Link to="/webshop">
                                <button type="button">Webshop</button>
                            </Link>
                            <Link to="/winetasting">
                                <button type="button">Wine tasting</button>
                            </Link>
                            <Link to="/about">
                                <button type="button">About us</button>
                            </Link>
                            <Link to="/contact">
                                <button type="button">Contact</button>
                            </Link>
                        </nav>
                        <Outlet />
                    </div>

                    <div/>
</div>
                    
                )
                }

                export default Home
