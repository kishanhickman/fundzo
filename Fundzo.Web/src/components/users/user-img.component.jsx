import { Component } from 'react';

class UserImg extends Component {
    render() {
        return (
            <div className={`avatar ${this.props.status}`} to={this.props.to}>
                <div className={`rounded-full ${this.props.className}`}>
                    <img src='https://api.lorem.space/image/face?hash=28212' alt={this.props.userName} />
                </div>
            </div>
        )
    }
}

export default UserImg;