import { useState, useEffect } from "react";
import image1 from "../Images/image1.jpg";
import image2 from "../Images/image2.jpg";
import image3 from "../Images/image3.jpg";
import  image4 from "../Images/image4.jpg";
import  image5 from "../Images/image5.jpg";
import  image6 from "../Images/image6.jpg";

import "./slider.css";






export default function About() {

    const images = [
        {
            imgURL:
            image1,
            imgAlt: "img-1"
        },
        {
            imgURL:
            image2,
            imgAlt: "img-2"
        },
        {
            imgURL:
            image3,
            imgAlt: "img-3"
        },
        {
            imgURL:
            image4,
            imgAlt: "img-4"
        },
        {
            imgURL:
               image5,
            imgAlt: "img-5"
        },
        {
            imgURL:
               image6,
            imgAlt: "img-6"
        }
    ];
    const [currentIndex, setCurrentIndex] = useState(0);

    useEffect(() => {
        const intervalId = setInterval(() => {
            setCurrentIndex((prevIndex) => (prevIndex + 1) % images.length);
        }, 3000);

        return () => clearInterval(intervalId);
    }, [images.length]);



    return(
        <main>

            <div className="container__slider">
                {images.map((image, index) => (
                    <div
                        key={index}
                        className={`carousel__item ${
                            index === currentIndex ? 'active' : ''
                        }`}
                        style={{ backgroundImage: `url(${image.imgURL})` }}
                    />
                ))}
            </div>
        </main>
    )
}







