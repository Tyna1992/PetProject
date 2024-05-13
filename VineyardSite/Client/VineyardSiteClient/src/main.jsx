import React from 'react'
import ReactDOM from 'react-dom/client'
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import {ToastContainer} from "react-toastify";
import Home from './Home.jsx'
import Register from './Pages/Registration.jsx'
import Login from './Pages/Login.jsx'
import Admin from './Pages/Admin.jsx'
import './index.css'


const router = createBrowserRouter([
    {
        path:"/",
        element:<Home/>,
        children:[
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