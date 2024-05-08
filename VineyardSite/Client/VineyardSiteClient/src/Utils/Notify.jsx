import React from 'react';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const notify = (message, type)=>{
    
    toast[type](message, {
        position: "top-right"
    });
   
    

}

export default notify;