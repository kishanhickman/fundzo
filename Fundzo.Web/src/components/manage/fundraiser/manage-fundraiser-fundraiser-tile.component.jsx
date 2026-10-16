import Button from '../../button/button.component';
import clockIcon from '../../../assets/icons/clock.svg';

const FundraiserManageFundraiserTile = ({fundraiser, fundraiserIndex}) => {
  return (
    <div className='card card-compact' key={fundraiserIndex}>
      <div>
        {fundraiser[fundraiserIndex].fundraiserMedias.map((media, index) =>
          <div className='w-full h-64 bg-center bg-no-repeat bg-cover' style={{backgroundImage: `url(${media.staticMedia.blobUrl})`}} alt='' key={index}></div>
        )}
        <div className='card-body'>
          <div className='flex flex-row items-center mb-3'>
            <div className='flex flex-row sm:flex-col 2xl:flex-row gap-4'>
              <div>
                <Button className='btn-accent text-white btn-sm' title={fundraiser[fundraiserIndex].category.name} to={{ pathname: `/category/${fundraiser[fundraiserIndex].category.id}`, state: fundraiser[fundraiserIndex] }} />
              </div>
              <div className='flex items-center gap-2'>
                <img src={clockIcon} alt=''/>
                <div className=''>20 Days Left</div>
              </div>
            </div>
          </div>
            <h3 className='card-title'>{fundraiser[fundraiserIndex].name}</h3>
            <progress className='progress progress-primary bg-base-100 w-full' value={Math.round((30000/fundraiser[fundraiserIndex].goalAmount)*100)} max='100'></progress>
            <div className='flex justify-between my-2'>
              <div>
                <div className='text-base font-medium'>30000</div>
                <div className=''>Raised of {fundraiser[fundraiserIndex].goalAmount}</div>
              </div>  
                <span className='text-sm'>{Math.round((30000/fundraiser[fundraiserIndex].goalAmount)*100)}%</span>
            </div>
            <div className='border-t flex justify-between pt-3 items-center'>
                <div>Created 6hrs ago</div>
                <Button className='btn-primary btn-sm' to={{ pathname: '/manage/fundraiser/manage-fundraiser-single', state: fundraiser[fundraiserIndex] }} title='Manage' /> 
            </div> 
        </div>
      </div>
    </div>
  )
}
        
export default FundraiserManageFundraiserTile;