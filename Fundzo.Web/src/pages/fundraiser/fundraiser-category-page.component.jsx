import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { useLocation } from 'react-router-dom';
import FundraiserTile from '../../components/fundraiser/fundraiser-tiles/fundraiser-tile.component';
import Search from '../../components/input/search.component';
import { retrieveFundraisers } from '../../actions/fundraiser';

const FundraiserCategoryPage = () => {
    const fundraisers = useSelector(state => state.fundraiser);

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(retrieveFundraisers());
    }, [dispatch]);

    const { state } = useLocation();

    const fundraiserCategory = fundraisers.filter((fundraiser) => fundraiser.category.name === state.category.name);

    const [name, setName] = useState("");
    const [foundFundraiser, setFoundFundraiser] = useState(fundraiserCategory);

    const handleFilterBySearch = (event) => {
        setName(event.target.value);
    };

    useEffect(() => {
        const filter = (filteredData) => {
            if (!name) {
                return filteredData;
            }

            const filteredFundraisers = filteredData.filter(
                (fundraiser) => fundraiser.name.toLowerCase().includes(name.toLowerCase())
            );

            return filteredFundraisers;
        };

        var filteredData = filter(fundraiserCategory);
        setFoundFundraiser(filteredData);
    // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [name, fundraisers])

    return (
        <div className='container my-10'>
            <h2 className='mb-8 text-2xl'>{state.category.name}</h2>
            <div className='flex flex-col'>
                <form className='flex gap-4 items-center mb-10'>
                    <Search
                        type="search"
                        value={name}
                        onChange={handleFilterBySearch}
                        btnClassName='bg-base-200'
                        className='bg-base-200 border-l-base-200 focus:outline-none focus:ring-0 focus:border-primary'
                        placeholder="Filter"
                    /> 
                </form>
            </div>
            <div className='grid sm:grid-cols-2 lg:grid-cols-3 gap-10 mb-6'>
                {foundFundraiser && foundFundraiser.length > 0 ? (
                    foundFundraiser.map((_, index) => (
                        <FundraiserTile key={index} fundraiser={foundFundraiser} fundraiserIndex={index}/>
                    ))
                ) : (
                    <h1>No Results.</h1>
                )}
            </div>                 
        </div>
    )
}
    
export default FundraiserCategoryPage ;

