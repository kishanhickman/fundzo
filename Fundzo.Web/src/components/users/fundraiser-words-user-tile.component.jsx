import { Component } from 'react';
import UserImg from './user-img.component';

class FundraiserWordsUserTile extends Component {
    render() {
        return (
            <div className='border-b-base-100 border-b mb-4'>
            <p className='text-accent font-pjsb'>Donated $5000</p>
            <div><p>I decided to watch your story on Netflix after an interview Cecilie had with my local radio station (AUS) and I am so glad I did. Your story is quite phenomenal and I hope it can spread awareness and help others. I also hope we can get enough donations (big and small) to get you all back to living your best lives.</p></div>
            <div className='flex flex-row p-4' to={this.props.to}>
                <UserImg to='/' className='h-10 w-10'/>
                <div className='px-4'>
                    <div>User Name</div>
                    <div>Jun 03-10, 2022</div>
                </div>
            </div>
            </div>
        )
    }
}

export default FundraiserWordsUserTile;