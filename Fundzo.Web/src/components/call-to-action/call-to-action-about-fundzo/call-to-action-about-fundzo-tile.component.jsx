import { Component } from 'react';

class CallToActionAboutFundzoTile extends Component {
    render() {
        return (
                <div className='grid grid-flow-col md:block'>   
                    <div className='mr-3 md:mb-6'>
                        <img src={this.props.icon} className='h-16 w-16' alt={this.props.title} />
                    </div>
                    <div className=''>
                        <h3 className='text-2xl mb-4'>{this.props.title}</h3>
                        <div className='text-neutral'>{this.props.text}</div>   
                    </div>
                </div>
        )
    }
}

export default CallToActionAboutFundzoTile;