import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import Button from '../../button/button.component';
import orgs1 from '../../../assets/images/orgs-1.png';
import orgs2 from '../../../assets/images/orgs-2.png';
import { clearMessage } from "../../../actions/message";
import { history } from "../../../helpers/history";

const CallToActionBanner = () => {
  const { user: currentUser } = useSelector((state) => state.auth);
  const dispatch = useDispatch();

  useEffect(() => {
      history.listen((location) => {
          dispatch(clearMessage()); // clear message when changing location
      });
  }, [dispatch]);

  return (
    <div className='container text-center'>
      <div className='grid md:grid-cols-2 my-20 gap-14'><img src={orgs1} className='max-w-none w-full' alt='orgs1' /><img src={orgs2} className='max-w-none w-full' alt='orgs2' /></div>
        <div className='bg-primary mb-10 rounded-lg'>
          <div className='bg-[url("./assets/images/call-to-action-bg.png")] bg-no-repeat bg-cover'>
            <div className='py-20'>
              <h2 className='font-ot text-5xl xl:text-6xl 2xl:text-7xl mb-16'>Ready to start a project</h2>
              {currentUser ? (
                    <Button to='/manage/fundraiser/fundraiser-new' className='btn-base-content' title='Create Project'/>
              ) : (
                    <Button to='/login' className='btn-base-content' title='Create Project'/>
              )}
            </div>
        </div>
      </div>
    </div>
  )
}

export default CallToActionBanner;