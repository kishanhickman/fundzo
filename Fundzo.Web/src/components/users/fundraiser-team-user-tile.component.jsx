import { Component } from 'react';
import UserImg from './user-img.component';
import UserService from "../../services/user.service";

class FundraiserTeamUserTile extends Component {
    constructor(props) {
        super(props);
        this.state = {
            user: {}
        };
    }

    componentDidMount() {
        this.getUserById(3);
    }

    getUserById(uId){
        UserService.getUserById(uId)
        .then( (response) => {
            return response.data
        })
        .then( (json) => {
            this.setState({
                user: json
            })
        });
    }

    render() {
        return (
            <div className='sm:flex sm:flex-row sm:justify-between mb-3 py-4 bg-base-200 border border-base-300 rounded-lg'>
                <div className='flex px-4 mb-3 sm:mb-0'>
                    <UserImg to='/' className='h-12 w-12'/>
                    <div className='px-4'>
                        <div className='font-pjsb text-xl'>{this.state.user.displayName}</div>
                        <div className='text-neutral text-base'>Role</div>
                    </div>
                </div>
                <div className='px-4 lg:pr-24'>
                    <div>Raised £45,262</div>
                    <div>from 2176 donations</div>
                </div>
            </div>
        )
    }
}

export default FundraiserTeamUserTile;