import { Component } from 'react';
import UserImg from './user-img.component';
import heartIcon from '../../assets/icons/outline/heart.svg';
import heartIconFill from '../../assets/icons/outline/heart-fill.svg';
import ButtonSwap from "../button/button-swap.component";

class FundraiserTileUserTile extends Component {
    render() {
        return (
            <div className='flex items-center justify-between border-t pt-4' to={this.props.to}>
                <div className='flex items-center'>
                    <UserImg to='/' className='h-7 w-7'/>
                    <div className='px-4'>
                        <div className='font-medium'>John</div>
                    </div>
                </div>
                <ButtonSwap offIcon={heartIcon} onIcon={heartIconFill} />
            </div>
        )
    }
}

export default FundraiserTileUserTile;