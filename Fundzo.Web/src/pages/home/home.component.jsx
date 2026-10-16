import React from "react";
import Banner from "../../components/banner/banner.component";
import CallToActionAboutFundzo from "../../components/call-to-action/call-to-action-about-fundzo/call-to-action-about-fundzo.component";
import FundraiserCategory from "../../components/fundraiser/fundraiser-category/fundraiser-category.component";
import CallToActionAboutCause from "../../components/call-to-action/call-to-action-about-cause/call-to-action-about-cause.component";
import FundraiserExploreTiles from "../../components/fundraiser/fundraiser-tiles/fundraiser-explore-tiles.component";
import CallToActionBanner from "../../components/call-to-action/call-to-action-banner/call-to-action-banner.component";
import CallToActionVideo from "../../components/call-to-action/call-to-action-video/call-to-action-video.component";
import UnderConsructionModal from "../../components/modal/modal-underconstruction.component";
import { useLocation } from "react-router-dom"; 


const HomePage = () => {

    const search = useLocation().search;
    const devMode = new URLSearchParams(search).get('devmode');
    const UnderConstruction = devMode === 'true' ? '' : <UnderConsructionModal />

    return (

        <div className='flex flex-col flex-grow'>
            { UnderConstruction }
            <Banner />
            <CallToActionAboutFundzo />
            <FundraiserCategory />
            <CallToActionAboutCause />
            <FundraiserExploreTiles />
            <CallToActionVideo />
            <CallToActionBanner />
        </div>
    )
}



export default HomePage;