import { Component } from 'react';

class FundraiserManageStatTile extends Component {
    render() {
        return (
            <div className='flex gap-4'>
                <div className='bg-base-200 btn-circle p-3'>
                    <img src={this.props.icon} alt='icon'/>
                </div>
                <div className='flex flex-col'>
                    <div className='text-neutral'>{this.props.title}</div>
                    <div>{this.props.text}</div>
                </div>
            </div>
            )
}
}
        
export default FundraiserManageStatTile;
