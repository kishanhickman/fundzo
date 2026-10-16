import { Component } from 'react';

class CallToActionVideoTile extends Component {
    render() {
        return (
            <div>
            <iframe className='rounded-lg aspect-video w-full' allow='fullscreen' target='_parent' src={this.props.video} title={this.props.title}></iframe>
            <p className='my-4'>{this.props.text}</p>
            <p>{this.props.username}</p>
            <p>{this.props.usernamestat}</p>
            </div>
        )
    }
}

export default CallToActionVideoTile;