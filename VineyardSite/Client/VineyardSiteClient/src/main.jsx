import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import {ToastContainer} from "react-toastify";
import Home from './Home.jsx'
import Register from './Pages/Registration.jsx'
import './index.css'


const router = createBrowserRouter([
    {
        path:"/",
        element:<Home/>,
        children:[
            {
                path:"/register",
                element:<Register/>
            }
            
        ]
    }
]);



const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
    <React.StrictMode>
        <RouterProvider router={router}/>
        <ToastContainer/>
    </React.StrictMode>
)