import { useState, useEffect } from "react";

import "./slider.css";






export default function About() {

    const images = [
        {
            imgURL:
            "https://scontent-vie1-1.xx.fbcdn.net/v/t39.30808-6/300799355_6015437488470363_2144838851183215707_n.jpg?_nc_cat=102&ccb=1-7&_nc_sid=5f2048&_nc_ohc=dZC0AdKL_50Q7kNvgHIIM0I&_nc_ht=scontent-vie1-1.xx&oh=00_AYDBs_LZh-fVV0VdPKFHi_OEMMmf-ZlcgXtH_zC3gkXO1Q&oe=664C2B89",
            imgAlt: "img-1"
        },
        {
            imgURL:
            "https://scontent-vie1-1.xx.fbcdn.net/v/t39.30808-6/347285793_722652406532129_7186021193040211342_n.jpg?_nc_cat=103&ccb=1-7&_nc_sid=5f2048&_nc_ohc=eNUmGv1Aw0EQ7kNvgHpWxGu&_nc_ht=scontent-vie1-1.xx&oh=00_AYAGtnP8aYhOjqwMoivCu46PywBuX8SGsUK9z5OChy0atA&oe=664C42CA",
            imgAlt: "img-2"
        },
        {
            imgURL:
            "https://scontent-vie1-1.xx.fbcdn.net/v/t39.30808-6/242626446_4948715581809231_552672788781959324_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=5f2048&_nc_ohc=CI2Vq5QzVmUQ7kNvgHxIPNX&_nc_ht=scontent-vie1-1.xx&oh=00_AYDS2MwAwoAkcF4lcjT8W2X5z8jXng9zMeBe6Lj-GwsWRA&oe=664C5952",
            imgAlt: "img-3"
        },
        {
            imgURL:
                "https://scontent-vie1-1.xx.fbcdn.net/v/t39.30808-6/343929604_138052799159735_6086357164612459070_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_ohc=LSERxGC8YAkQ7kNvgHhg8oN&_nc_ht=scontent-vie1-1.xx&oh=00_AYDXP6qT7GXQbbaEn-AmgfDN0Ck6RkgI6VS897S6PGNRVg&oe=66495E9A",
            imgAlt: "img-4"
        },
        {
            imgURL:
                "https://scontent-vie1-1.xx.fbcdn.net/v/t39.30808-6/280923480_5715486271798821_4512285047606357298_n.jpg?_nc_cat=109&ccb=1-7&_nc_sid=5f2048&_nc_ohc=clORYo_e9dAQ7kNvgGMX2ti&_nc_ht=scontent-vie1-1.xx&oh=00_AYCZFCB9O6h1e61P-NlHDnLmu0Xu3WJk73dgpZB1d533PQ&oe=66496EE5",
            imgAlt: "img-5"
        },
        {
            imgURL:
                "https://scontent-vie1-1.xx.fbcdn.net/v/t39.30808-6/309516217_518776210253084_8638170832818659936_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=5f2048&_nc_ohc=Q3p1iGbV6QoQ7kNvgFVK0VH&_nc_ht=scontent-vie1-1.xx&oh=00_AYCDg-0ua8YaOHyEteaooRXi-3_xAPSXs3Zz_TebqBdwQA&oe=66495AB5",
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







