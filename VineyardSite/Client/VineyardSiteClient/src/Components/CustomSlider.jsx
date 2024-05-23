import { useState, useEffect } from "react";




import "./slider.css";






export default function About({images}) {

    
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







