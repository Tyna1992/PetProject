import {useEffect, useState, useContext} from "react";
import { UserContext } from "../Components/UserContext.jsx";
import TextareaAutosize from 'react-textarea-autosize';
import image2 from "../Images/178577674_4495965910417536_1190073409921344859_n.jpg";
import image3 from "../Images/217823819_4723751814305610_2816810440140348969_n.jpg";
import WineTastingForm from "../Components/WineTastingRequestForm/WinetastingForm.jsx";
function WineTasting()
{
    const {user, setUser} = useContext(UserContext);
    
    
    return(
        <div >
            
            <div className="winetasting-image">
                
                <img src={image2}></img>
                <img src={image3}></img>
            </div>
            <div className="winetasting">
                
                <p>Experience the vibrant, fruity wines of Csobánci Bormanufaktúra in Diszel and discover the art of winemaking!
                    Book an appointment to explore the storied history of our winery. Join us for an insightful tour where you'll learn about our state-of-the-art vinification methods and visit our barrel ageing rooms.
                    At our show cellar, enjoy an interactive demonstration of our wine-making process. Of course, you'll also have the opportunity to sample a selection of wines from our exclusive portfolio.</p>
                
            </div>
            <div className="form-container" >

                <WineTastingForm/>

            </div>

            <h2></h2>
        </div>
    )
}

export default WineTasting;