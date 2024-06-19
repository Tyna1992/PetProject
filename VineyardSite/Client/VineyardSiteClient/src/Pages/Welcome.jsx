import CustomSlider from '../Components/CustomSlider.jsx';
import images from '../Components/ImageData.jsx';
import {SocialIcon} from "react-social-icons";
import '../index.css';

function Welcome() {
    return (
        <div>

            <CustomSlider images={images}/>

            <div className="welcome">
                <h1>Welcome to Csobánci Bormanufaktúra!</h1>
                <div className="terroir">
                    <h3>Csobánc</h3>
                    <img src="https://borvidekmania.hu/wp-content/uploads/2020/08/csobanc2.jpg"></img>
                    <p>Our winery is located in the heart of the Balaton Uplands, at the foot of the Csobánc hill. </p>
                    <p>The hill's volcanic soil, rich in minerals, combined with its elevated position, provides
                        excellent drainage and a favorable microclimate for viticulture</p>
                    <p>These conditions contribute to the distinctive character of the wines produced here, often marked
                        by a pronounced minerality and vibrant acidity.</p>
                    <button>Read more</button>
                </div>
                <div className="petnat">
                    <h3>Pét-Nat, the "ancient champagne"</h3>
                    <img src="https://scontent-vie1-1.xx.fbcdn.net/v/t39.30808-6/347636043_738229681641068_8581718604760421778_n.jpg?stp=cp6_dst-jpg_p526x296&_nc_cat=105&ccb=1-7&_nc_sid=5f2048&_nc_ohc=7jR0TfYY3lUQ7kNvgEZQrM5&_nc_ht=scontent-vie1-1.xx&oh=00_AYC24lUqQ9BIt0PQBX2qRwc_PhWfUGF2zEqD-gMglt-7hA&oe=6677AFC3"></img>
                    <p>Pétillant Naturel, commonly known as Pét Nat, is a type of sparkling wine that is produced using
                        the
                        méthode ancestrale.</p>
                    <p>This method is the oldest way of making sparkling wine, predating the méthode champenoise used to
                        make Champagne.</p>
                    <p>The result is a naturally sparkling wine that is often slightly cloudy, with lively bubbles and a
                        fresh, fruity character. </p>
                    <button>Read more</button>
                </div>
                <p>We look forward to welcoming you at our winery!</p>


            </div>


            <footer className="footer">

                <div className="contact">
                    <h3>Contact</h3>
                    <p>Email: csobancibormanufaktura@gmail.com</p>
                    <p>Phone: +36 30 123 4567</p>
                </div>
                <div className="social">
                    <p>Follow us!</p>
                    <SocialIcon url="https://www.facebook.com/csobancibormanufaktura"/>
                    <SocialIcon url="https://www.instagram.com/csobancibormanufaktura/"/>
                </div>

            </footer>


        </div>
    )

}

export default Welcome;