import CustomSlider from '../Components/CustomSlider.jsx';
import images from '../Components/ImageData.jsx';


function Welcome()
{
    return(
        <div>
            <CustomSlider images={images}/>
        </div>
    )

}

export default Welcome;