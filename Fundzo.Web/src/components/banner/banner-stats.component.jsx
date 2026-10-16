import React from 'react';

const content = [
    { id:1, number: '120.000', text: 'dontations' },
    { id:2, number: '4M+', text: 'People helped' },
    { id:3, number: '€8.9M', text: 'Funds Collected' },
    { id:4, number: '50k+', text: 'Fund Campaign' },
  ]

const BannerStats = () => (
    <div className='grid grid-cols-2 lg:grid-cols-4'>
        {content.map((item) => (
            <div key={item.id} className='py-6'>
            <h2 className='text-4xl mb-3'>{item.number}</h2>
            <p className='text-neutral'>{item.text}</p>
        </div>            
        ))}
    </div>
)

export default BannerStats