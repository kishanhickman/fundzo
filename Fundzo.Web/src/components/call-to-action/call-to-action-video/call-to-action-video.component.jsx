import React from 'react';
import CallToActionVideoTile from './call-to-action-video-tile.component';

const content = [
    {   
        video: 'https://www.youtube.com/embed/7nyZdzGA1Q0',
        title: 'video', 
        text:  'My life has changed forever because of Norma and what happened. It gave me hope again. Changing someones life will change your own forever.',
        username: 'User Name One',
        usernamestat: 'Raised $200k to help homeless people', 
        id: 1 
    },
    {   
        video: 'https://www.youtube.com/embed/xhZ4bTFcwTY',
        title: 'video', 
        text:  'Workers from the Ukrainian Red Cross have been visiting people in shelters and distributing aid in Mariupol, amid a growing humanitarian crisis in the besieged port city.',
        username: 'Red Cross',
        usernamestat: 'Raised $80k to help neighbour',
        id: 2
    }
]

const CallToActionVideo = () => (
    <div className='bg-base-200 mb-20'>
        <div  className='container lg:px-40 py-20'>
            <h2 className='text-5xl my-10 flex justify-center'>See what people are saying</h2>
            <p className='my-10 flex justify-center'>2,157 people have said how good we are</p>
            <div className='grid grid-cols-1 md:grid-cols-2 gap-16'>
                {content.map((item) => (
                    <CallToActionVideoTile key={item.id} video={item.video} text={item.text} username={item.username} usernamestat={item.usernamestat} />
                ))}
            </div>
        </div>
    </div>
)

export default CallToActionVideo