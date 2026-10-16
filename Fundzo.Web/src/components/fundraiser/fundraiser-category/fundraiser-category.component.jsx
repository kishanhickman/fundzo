import React from 'react';
import CategoryTiles from './fundraiser-category-tiles.component';
import medicalIcon from '../../../assets/icons/category/medical.svg';
import foodIcon from '../../../assets/icons/category/food.svg';
import emergencyIcon from '../../../assets/icons/category/emergency.svg';
import nonprofitIcon from '../../../assets/icons/category/nonprofit.svg';
import educationIcon from '../../../assets/icons/category/education.svg';
import covidIcon from '../../../assets/icons/category/covid.svg';
import entrepreneurshipIcon from '../../../assets/icons/category/entrepreneurship.svg';
import homeIcon from '../../../assets/icons/category/home.svg';

const content = [
    {   
        to: 'category/5',
        icon: medicalIcon,
        title: 'Medical',
        numberof: '10k',
        id: 1  
    },
    {
        to: 'category/6',
        icon: foodIcon,
        title: 'Food',
        numberof: '8k',
        id: 2 
    },
    {
        to: 'category/3',
        icon: emergencyIcon,
        title: 'Emergency',
        numberof: '2k',
        id: 3
    },
    {
        to: 'category/2',
        icon: nonprofitIcon,
        title: 'Nonprofit',
        numberof: '500',
        id: 4
    },
    {
        to: 'category/4',
        icon: educationIcon,
        title: 'Education',
        numberof: '20k',
        id: 5
    },
    {
        to: 'category/8',
        icon: covidIcon,
        title: 'Covid-19',
        numberof: '585',
        id: 6
    },
    {
        to: 'category/7',
        icon: entrepreneurshipIcon,
        title: 'Entrepreneurship',
        numberof: '21k',
        id: 7
    },
    {
        to: 'category/1',
        icon: homeIcon,
        title: 'Home',
        numberof: '5k',
        id: 8
    }
  ]

const FundraiserCategory = () => (
    <div className='container my-10'>
        <div>
            <h2 className='text-3xl md:text-4xl lg:text-5xl'>Explore by project category</h2>
        </div>
            <ul className='menu grid grid-cols-1 md:grid-cols-3 lg:grid-cols-4 gap-4 md:gap-8 my-10'>   
            {content.map((item) => (
                <CategoryTiles to={item.to} icon={item.icon} title={item.title} numberof={item.numberof} key={item.id} />              
            ))}
            </ul>
        </div>
)
export default FundraiserCategory;