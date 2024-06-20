import React from 'react';
import "../index.css";
import balaton_view from "../Images/balaton_view.jpg";


function Terroir() {
    return(
        <div>
        <h1>Our Home, Csobánc</h1>
            <br></br>
        <div>
            <div className="terroir-image">
                <img  src={balaton_view}/>
            </div>

            <br></br>
            <div>
                <p>Csobánc [ˈtʃobaːnts] is a hill in the Tapolca Basin, Hungary.


                    Panoramic view from the top with Lake Balaton in the background
                    Geography and environment
                    Csobánc is one of the highlights of the region. Similar to the other hills in the area, it is of volcanic origin. These hills are witness hills. The expression originates from the fact that these hills “witnessed” the decrease of the land surface level during volcanic activity millions of years ago. They preserve the original surface since the Pliocene period.

                    Protected natural assets
                    Csobánc is one of the unique and peculiar monadnocks of Tapolca Basin. It is a result of basalt volcanism 3.5 million years ago. Numerous rare habitats in need of protection have been preserved due to the relatively secluded and undisturbed area. The natural assets of Csobánc granted the hill increased protection from the Balaton Uplands National Park and the Bakony-Balaton Geopark.</p>
            </div>
            <h1>Notable Sights</h1>
            <p></p>
            <h3>Castle ruins</h3>
            <p>The castle has been attacked by the Turks between 1554 and 1567.[1]


                Memorial tablet on the castle wall
                Construction works began in 1255 for the first time. The Italian Rátóti Gyulaffy family owned the castle for more than 40 years. Csobánc fell under numerous unsuccessful Turkish sieges in the 16th century. In 1669 the Esterházy family took control over the castle. During the Rákóczi's War for Independence, the heroic Hungarian kuruc defenders were triumphantly able to manage resistance against immense Austrian-Danish united attacks in February 1707. The castle was first destroyed in the 18th century.[2]

                The Foundation for the Castle of Csobánc from the neighbouring village Gyulakeszi makes efforts to reconstruct the ruins of the castle. Cultural and historical programs such as riding shows, mediaeval knights in period dresses, Turkish belly dance etc.[3] are offered to raise fund.[4] The most significant festival, Gyulaffy Days (Gyulaffy napok [ˈɟulɒffi ˈnɒpok]), is held annually.</p>
            
            <div>
                
            </div>
        </div>
    </div>

    )
}

export default Terroir;