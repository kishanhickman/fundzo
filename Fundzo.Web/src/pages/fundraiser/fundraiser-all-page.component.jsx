import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import Select from '../../components/input/select.component';
import Search from '../../components/input/search.component';
import { retrieveCategories } from '../../actions/admin';
import { retrieveFundraisers } from '../../actions/fundraiser';
import FundraiserTile from '../../components/fundraiser/fundraiser-tiles/fundraiser-tile.component';

const FundraiserAllPage = () => {
    const categories = useSelector(state => state.category);
    const fundraisers = useSelector(state => state.fundraiser);

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(retrieveCategories());
        dispatch(retrieveFundraisers());
    }, [dispatch]);

    const [name, setName] = useState("");

    const [foundFundraiser, setFoundFundraiser] = useState(fundraisers);

    const [selectedCategory, setSelectedCategory] = useState("");

    const handleFilterBySearch = (event) => {
        setName(event.target.value);
    };

    const handleCategoryChange = (event) => {
        setSelectedCategory(event.target.value);
    };

    useEffect(() => {
        const filterByCategory = (filteredData) => {
            if (!selectedCategory || selectedCategory === "Select Category") {
                return filteredData;
            }
    
            const filteredFundraisers = filteredData.filter(
                (fundraiser) => fundraiser.category.name === selectedCategory
            );
    
            return filteredFundraisers;
        }

        const filter = (filteredData) => {
            if (!name) {
                return filteredData;
            }

            const filteredFundraisers = filteredData.filter(
                (fundraiser) => fundraiser.name.toLowerCase().includes(name.toLowerCase())
            );

            return filteredFundraisers;
        };

        var filteredData = filterByCategory(fundraisers);
        filteredData = filter(filteredData);
        setFoundFundraiser(filteredData);
    }, [selectedCategory, name, fundraisers])

    return (
        <div className='container my-10'>
            <h2 className='mb-8 text-2xl'>Explore all fundraisers</h2>
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
                    <Select defaultValue={selectedCategory} onChange={handleCategoryChange} selectTitle="Category"
                        options={categories.map(category => <option key={category.id} id={category.id}>{category.name}</option>)}
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
    
export default FundraiserAllPage ;

