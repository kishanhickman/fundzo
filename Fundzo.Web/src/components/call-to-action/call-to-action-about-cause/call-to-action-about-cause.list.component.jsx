import { Component } from 'react';

class CallToActionCauseList extends Component {
    render() {
        return (
            <div className='flex flex-row gap-4 my-7'>
            <img src={this.props.icon} className='h-12' alt={this.props.title} />
                <div>
                    <h3 className=''>{this.props.title}</h3>
                    <div className='text-neutral'>{this.props.text}</div>   
                </div>
            </div>
        )
    }
}

export default CallToActionCauseList;