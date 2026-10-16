import { Component } from 'react';
import logo from '../../assets/images/logo-solo.png';

class UnderConsructionModal extends Component {
    render() {

        const logoStyle = {
            width: "50%",
            display: "block",
            marginLeft: "auto",
            marginRight: "auto",
            maxWidth: "200px"
        };

        return (
            <div>

                <div class="fixed inset-0 bg-gray-900 bg-opacity-80 transition-opacity"></div>

                <div class="fixed inset-0 z-10 overflow-y-auto">
                    <div class="flex min-h-full items-end justify-center p-4 text-center sm:items-center sm:p-0">
                        <div class="relative transform overflow-hidden rounded-lg bg-white text-left shadow-xl transition-all">
                            <div class="bg-white px-4 pt-5 pb-4 sm:p-6 sm:pb-4">
                                <div class="sm:flex sm:items-start sm:container">
                                    <img src={logo} style={logoStyle} alt='logo' />
                                    <div class="mt-3 text-center sm:mt-0 sm:ml-4 sm:text-left">
                                        <h1 class="text-gray-900 text-2xl" id="modal-title">Fundzo is coming soon...</h1>
                                        <div class="mt-2">
                                            <p class="text-sm text-gray-500 mt-6">We are busy creating the worlds first <span class="text-gray-900 text-green-600">Community Empowerment Platform</span> which will soon be ready to launch.</p>
                                            <p class="text-sm text-gray-500 mt-4">Our aim is to help low-income communities to create a better, more sustainable future through the use of technology.</p>
                                            <p class="text-sm text-gray-500 mt-4 mb-6"> For more information please email: <a href="mailto:info@gleipnir.org" class="text-blue-600">The Fundzo Team</a></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default UnderConsructionModal;

