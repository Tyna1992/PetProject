import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import {ToastContainer} from "react-toastify";
import Home from './Home.jsx'
import Register from './Pages/Registration.jsx'
import Login from './Pages/Login.jsx'
import Admin from './Pages/Admin.jsx'
import Welcome from './Pages/Welcome.jsx'
import './index.css'
import Webshop from './Pages/Webshop.jsx'
import Checkout from "./Pages/Checkout.jsx";
import Profile from "./Pages/Profile/Profile.jsx";
import Terroir from "./Pages/Terroir.jsx";
import About from "./Pages/About.jsx";

const router = createBrowserRouter([
    {
        path:"/",
        element:<Home/>,
        children:[
            {
                path:"/",
                element:<Welcome/>
            },
            {
                path:"/register",
                element:<Register/>
            },
            {
                path:"/login",
                element:<Login/>
            },
            {
                path: "/admin",
                element: <Admin/>
            },
            {
                path: "/webshop",
                element: <Webshop/>
            },
            {
                path: "/checkout",
                element: <Checkout/>
            },
            {
                path: "/profile",
                element: <Profile/>
            },
            {
                path: "/csobanc",
                element: <Terroir/>
            },
            {
                path: "/about",
                element: <About/>
                
            }
            
        ]
    }
]);



const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
    <React.StrictMode>
        <RouterProvider router={router}/>
        <ToastContainer 
            autoClose={3000} 
            pauseOnFocusLoss={false} 
            pauseOnHover={true} />
    </React.StrictMode>
)