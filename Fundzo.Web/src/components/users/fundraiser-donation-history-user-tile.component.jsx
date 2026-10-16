import { Component } from "react";
import UserImg from "./user-img.component";

class FundraiserDonationHistoryUserTile extends Component {
    render() {
        return (
            <div className='flex items-center border-t py-4'>
                <UserImg to='/' className='h-12 w-12'/>
                <div className='px-4'>
                    <div>{this.props.userName}</div>
                    <div className='text-neutral'>{this.props.time}</div>
                </div>
            </div>
        )
    }
}

export default FundraiserDonationHistoryUserTile;