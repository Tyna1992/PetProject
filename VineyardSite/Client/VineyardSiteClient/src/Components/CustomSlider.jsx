import { useState, useEffect } from "react";

import "./slider.css";


function CustomCarousel({ images }) {
    const [activeIndex, setActiveIndex] = useState(0);

    useEffect(() => {
        const interval = setInterval(() => {
            slideNext();
        }, 5000);

        return () => clearInterval(interval);
    }, []);

    const slideNext = () => {
        setActiveIndex((prevIndex) =>
            prevIndex === images.length - 1 ? 0 : prevIndex + 1
        );
    };

    const slidePrev = () => {
        setActiveIndex((prevIndex) =>
            prevIndex === 0 ? images.length - 1 : prevIndex - 1
        );
    };

    return (
        <div className="container__slider">
            {images.map((image, index) => (
                <div
                    className="slider__item"
                    key={index}
                    style={{
                        transform: `translateX(${-100 * activeIndex}%)`,
                    }}
                >
                    <img src={image.imgURL} alt={image.imgAlt} />
                </div>
            ))}

            <button className="slider__btn-next" onClick={slideNext}>
                {">"}
            </button>
            <button className="slider__btn-prev" onClick={slidePrev}>
                {"<"}
            </button>
        </div>
    );
}


export default CustomCarousel;








