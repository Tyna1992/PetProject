import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Home from './Home.jsx'
import './index.css'


const router = createBrowserRouter([
    {
        path:"/",
        element:<Home/>,
        children:[
            
        ]
    }
]);



const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
    <React.StrictMode>
        <RouterProvider router={router}/>
    </React.StrictMode>
)