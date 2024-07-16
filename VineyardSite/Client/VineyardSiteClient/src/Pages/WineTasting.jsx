import {useEffect, useState, useContext} from "react";
import { UserContext } from "../Components/UserContext.jsx";
import TextareaAutosize from 'react-textarea-autosize';
import image2 from "../Images/178577674_4495965910417536_1190073409921344859_n.jpg";
import image3 from "../Images/217823819_4723751814305610_2816810440140348969_n.jpg";

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

                <div>
                    <br></br>
                    <h3>Request an offer!</h3>
                    <br></br>
                    <form>
                        <label>Email:</label>
                        <br></br>
                        <input type="text" name="user-email" value={user !== null ? user.email : "" }></input>
                        <br></br>
                        <label>Name:</label>
                        <br></br>
                        <input type="text" name="user-name"></input>
                        <br></br>
                        <label>Phone number:</label>
                        <br></br>
                        <input type="text" name="user-phone"></input>
                        <br></br>
                        <label>Number of people:</label>
                        <br></br>
                        <input type="number" name="user-people"></input>
                        <br></br>
                        <label>Date:</label>
                        <br></br>
                        <input type="date" name="user-date"></input>
                        <br></br>
                        <label>Message:</label>
                        <br></br>
                        <TextareaAutosize required name="message" className="textarea"></TextareaAutosize>
                        <br></br>
                        <button type="submit">Send request</button>
                        <button>Cancel</button>
                    </form>
                </div>

            </div>

            <h2></h2>
        </div>
    )
}

export default WineTasting;