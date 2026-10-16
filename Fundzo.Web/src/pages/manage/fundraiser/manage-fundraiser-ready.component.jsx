import { Component } from 'react';
import Button from '../../../components/button/button.component';
import FieldClipboardCopy from '../../../components/input/field-clipboard-copy.component';
import copyClipboardIcon from '../../../assets/icons/outline/copy-clipboard.svg';
import fundraiserReady from '../../../assets/images/fundraiser-ready.svg';
import shareFacebook from '../../../assets/icons/share/facebook.svg';
import shareTwitter from '../../../assets/icons/share/twitter.svg';
import shareYoutube from '../../../assets/icons/share/youtube.svg';
import shareInstagram from '../../../assets/icons/share/instagram.svg';
import shareMail from '../../../assets/icons/share/mail.svg';
import shareSnapchat from '../../../assets/icons/share/snapchat.svg';
import shareTelegram from '../../../assets/icons/share/telegram.svg';
import shareWhatsapp from '../../../assets/icons/share/whatsapp.svg';
import shareLinkedin from '../../../assets/icons/share/linkedin.svg';
import shareLink from '../../../assets/icons/share/link.svg';

class FundraiserReady extends Component {
    render() {
        return (
                  <div className='my-16 w-full'>
                    <div className='flex flex-col'>
                      <img src={fundraiserReady} alt='Ready to share' />
                      <div className='text-center mx-auto max-w-lg'>
                        <div className='text-3xl my-5'>Your fundraiser is ready</div>
                        <div>Let’s start raising donations! share with friend and ask them to help  you share.Fundraisers shared on social networks raise up to 5x more.</div>
                      </div>
                      <div className='mx-auto'>
                        <div className='max-w-md'>
                          <FieldClipboardCopy title='https://fundzo.com/f/ppf?' icon={copyClipboardIcon} />
                        </div>
                      </div>
                      <div className='mx-auto'>  
                        <div className='grid grid-cols-3 sm:grid-cols-5 justify-items-center gap-4 my-4 max-w-md'>
                          <img src={shareFacebook} alt='Share on Facebook' />
                          <img src={shareTwitter} alt='Share on Twitter' />
                          <img src={shareYoutube} alt='Share on Youtube'/>
                          <img src={shareInstagram} alt='Share on Instagram' />
                          <img src={shareMail} alt='Share as Mail' />
                          <img src={shareSnapchat} alt='Share on Snapchat' />
                          <img src={shareTelegram} alt='Share on Telegram' />
                          <img src={shareWhatsapp} alt='Share on Whatsapp' />
                          <img src={shareLinkedin} alt='Share on Linkedin' />
                          <img src={shareLink} alt='Share as Link' />
                        </div>
                      </div>
                      <Button className='btn-block btn-primary max-w-sm mx-auto' title='Share Fundraiser'/>
                  </div>
                </div>
    )
  }
}

export default FundraiserReady;