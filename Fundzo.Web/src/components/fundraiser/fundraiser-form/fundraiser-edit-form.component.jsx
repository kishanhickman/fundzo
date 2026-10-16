import React, { useState, useEffect, useRef } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { Redirect, useLocation } from 'react-router-dom';
import toastr from 'toastr';
import LabelBlockDescription from '../../input/label-block-description.component';
import LabelDescription from '../../input/label-description.component';
import Radio from '../../input/radio.component';
import Input from '../../input/input.component';
import Textarea from '../../input/textarea.component';
import Select from '../../input/select.component';
import { retrieveFundraiserTypes } from "../../../actions/fundraiser";
import { retrieveCategories, retrieveOrganisations, retrieveCurrency } from "../../../actions/admin";
import FundraiserService from '../../../services/fundraiser.service';


// Import React FilePond
import { FilePond, registerPlugin } from 'react-filepond'

// Import FilePond styles
import 'filepond/dist/filepond.min.css'

// Import the Image EXIF Orientation and Image Preview plugins
// Note: These need to be installed separately
// `npm i filepond-plugin-image-preview filepond-plugin-image-exif-orientation --save`
import FilePondPluginImageExifOrientation from "filepond-plugin-image-exif-orientation";
import FilePondPluginImagePreview from "filepond-plugin-image-preview";
import FilePondPluginImageResize from "filepond-plugin-image-resize";
import FilePondPluginImageTransform from "filepond-plugin-image-transform";
import FilePondPluginImageEdit from "filepond-plugin-image-edit";
import FilePondPluginFilePoster from "filepond-plugin-file-poster";

// FilePond CSS.
import "filepond-plugin-image-preview/dist/filepond-plugin-image-preview.css";
import "filepond-plugin-image-edit/dist/filepond-plugin-image-edit.css";
import "filepond-plugin-file-poster/dist/filepond-plugin-file-poster.css";
import "../../../assets/vendor/doka.min.css";
import { create } from "../../../assets/vendor/doka.esm.min";

// Register the FilePond plugins
registerPlugin(
    FilePondPluginImageExifOrientation,
    FilePondPluginImagePreview,
    FilePondPluginImageResize,
    FilePondPluginImageTransform,
    FilePondPluginImageEdit,
    FilePondPluginFilePoster
);

const FundraiserEditForm = () => {
    const { state } = useLocation();

    const [submitted, setSubmitted] = useState(false);

    const fundraiserTypes = useSelector(state => state.fundraiserType);

    const dispatch = useDispatch();

    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [goalAmount, setGoalAmount] = useState("");
    const [fundraiserType, setFundraiserType] = useState(null);
    const [category, setCategory] = useState(null);
    const [organisation, setOrganisation] = useState(null);
    //const [fundraiserStatus, setFundraiserStatus] = useState(null);
    const [currency, setCurrency] = useState(null);
    //const [user, setUser] = useState(null);

    const handleFundraiserTypeIdChange = event => {
        setFundraiserType(event.target._wrapperState.initialValue);
    };

    const handleCategoryIdChange = event => {
        const index = event.target.selectedIndex;
        setCategory(index);
    };

    const handleOrganisationIdChange = event => {
        const index = event.target.selectedIndex;
        setOrganisation(index);
    };

    const handleCurrencyIdChange = event => {
        const index = event.target.selectedIndex;
        setCurrency(index);
    };

    // Validation.
    const [nameError, setNameError] = useState('');
    const [descriptionError, setDescriptionError] = useState('');
    const [goalAmountError, setGoalAmountError] = useState('');
    const [fundraiserTypeError, setFundraiserTypeError] = useState('');
    const [categoryError, setCategoryError] = useState('');
    const [organisationError, setOrganisationError] = useState('');
    const [currencyError, setCurrencyError] = useState('');
    const [imageError, setImageError] = useState('');

    function validateForm() {
        setNameError('');
        setDescriptionError('');
        setCategoryError('');
        setGoalAmountError('');
        setFundraiserTypeError('');
        setOrganisationError('');
        setCurrencyError('');
        
        if (name === '') { setNameError('Fundraiser title is required.') }
        if (description === '') { setDescriptionError('Story is required.') }
        if (goalAmount === '') { setGoalAmountError('Fundraiser goal amount is required.') }
        if (fundraiserType === null) { setFundraiserTypeError('Account type is required.') }
        if (category === null) { setCategoryError('Category is required.'); }
        if (organisation === null) { setOrganisationError('Organistation is required.') }
        if (currency === null) { setCurrencyError('Currency is required.') }

        return true;
    }

    const filePondRef = useRef(null);

    async function getEditedImage() {
        const data = await filePondRef.current.prepareFiles();
        const getOriginalFile = filePondRef.current.getFiles();
        setImageError('');

        if(data[0] === undefined) {
            return setImageError('Image or video is required.');
        } else {
            const blobToFile = new File([data[0].output], getOriginalFile[0].file.name, {
                type: getOriginalFile[0].file.type,
            });

            return blobToFile;
        }
    }

    const submitform = async (event) => {
        event.preventDefault()
        const formData = new FormData();
        const fileItem = await getEditedImage();
        formData.append("name", name);
        formData.append("description", description);
        formData.append("goalAmount", goalAmount);
        formData.append("fundraiserTypeId", fundraiserType);
        formData.append("categoryId", category);
        formData.append("organisationId", organisation);
        formData.append("fundraiserStatusId", 1);
        formData.append("currencyId", currency);
        formData.append("userId", "2580866c-79b8-478e-9318-fc5d3ba4f047");
        formData.append("files", fileItem);

        if (validateForm()) {
            FundraiserService.updateFundraiser(state.id, state.fundraiserMedias[0].staticMedia.id, state.fundraiserMedias[0].id, formData)
            .then(() => {
                toastr.success('The form was successfully submitted!', 'Success!');
                setSubmitted(true);
            })
            .catch(() => {
                toastr.error('The form was not successfully submitted!', 'Failed!');
                setSubmitted(false);
            });
        } else {
            toastr.error('The form was not successfully submitted!', 'Failed!');
            setSubmitted(false);
        }
    };

    // Admin redux part.
    const categories = useSelector(state => state.category);
    const organisations = useSelector(state => state.organisation);
    const currencies = useSelector(state => state.currency);

    useEffect(() => {
        dispatch(retrieveCategories());
        dispatch(retrieveOrganisations());
        dispatch(retrieveCurrency());
        dispatch(retrieveFundraiserTypes());
    }, [dispatch]);

    useEffect(() => {
        setName(state.name);
        setDescription(state.description);
        setGoalAmount(state.goalAmount);
        setFundraiserType(state.type.id);
        setCurrency(state.currency.id);
        setCategory(state.category.id);
        setOrganisation(state.organisation.id);
    }, [state])

    var files = [{
        source: state.fundraiserMedias[0].staticMedia.blobUrl,
        options: {
            file: {
                name: state.fundraiserMedias[0].staticMedia.name,
                size: 189397,
                type: state.fundraiserMedias[0].staticMedia.extension
            },
            metadata: {
                poster:
                    state.fundraiserMedias[0].staticMedia.blobUrl
            }
        }
    }];

    return (
        <div>
            {submitted ? (
                <Redirect to="/manage/dashboard" />
            ) : (
                <div className='my-4 py-4 border-t'>
                    <form>
                            <div className='block mb-4'>
                            <p className='font-ob text-2xl mb-2'>{state.name}</p>
                            <p className='text-neutral text-xl mb-6'>$47000 Raised of {state.goalAmount} - Created 6hrs ago.</p>
                            <p className='text-lg'>Who are you raising money for?</p>
                            <p className='text-neutral mb-2'>Please choose the type of account that will be receiving your funds.</p>
                            </div>
                            <div className='flex flex-row gap-10'>
                                {fundraiserTypes.map((fundraiserType) => <Radio name='radios' className='toggle-primary' key={fundraiserType.id} id={fundraiserType.id} value={fundraiserType.id} onChange={handleFundraiserTypeIdChange} title={fundraiserType.type} defaultChecked={fundraiserType.id === state.type.id} />)}
                                <span className="font-bold text-error mb-4">{fundraiserTypeError}</span>
                            </div>
                            <div className='input-block grid lg:grid-cols-8 gap-4'>
                                <div className='col-span-1 lg:col-span-2'>
                                    <LabelBlockDescription title='Organisation' />
                                </div>
                                <div className='lg:col-start-4 lg:col-span-5'>    
                                <Select defaultInputValue={organisation} onChange={handleOrganisationIdChange} selectTitle="Organisation" errorMessage={organisationError}
                                    options={organisations.map(organisation => <option key={organisation.id} id={organisation.id} selected={organisation.id === state.organisation.id}>{organisation.name}</option>)}
                                />
                                </div>
                            </div>
                            <div className='input-block grid lg:grid-cols-8 gap-4'>
                                <div className='col-span-1 lg:col-span-2'>
                                    <LabelBlockDescription title='Fundraiser Title' text='What is the title of your Fundraiser?' />
                                </div>
                                <div className='lg:col-start-4 lg:col-span-5'>
                                    <Input placeholder='My Fundraiser Title' type="text" defaultValue={name} onChange={(e) => setName(e.target.value)} name="name" errorMessage={nameError}/>
                                    <LabelDescription text='At least 80 characters' />
                                </div>
                            </div>
                            <div className='input-block grid lg:grid-cols-8 gap-4'>
                                <div className='col-span-1 lg:col-span-2'>
                                    <LabelBlockDescription title='Story' text='Tell donors more about your fundraising.' />
                                </div>
                                <div className='lg:col-start-4 lg:col-span-5'>
                                    <Textarea rows='8' placeholder='Tell your story' defaultValue={description} onChange={(e) => setDescription(e.target.value)} name="description" errorMessage={descriptionError}/>
                                    <LabelDescription text='Maximum 500 characters' />
                                </div>
                            </div>
                            <div className='input-block grid lg:grid-cols-8 gap-4'>
                                <div className='col-span-1 lg:col-span-2'>
                                    <LabelBlockDescription title='Category' text='Select a category that describes why youre fundraising?' />
                                </div>
                                <div className='lg:col-start-4 lg:col-span-5'>
                                    <Select defaultValue={category} onChange={handleCategoryIdChange} selectTitle="Category" errorMessage={categoryError}
                                        options={categories.map(category => <option key={category.id} id={category.id} selected={category.id === state.category.id}>{category.name}</option>)}
                                    />   
                                </div>
                            </div>
                            <div className='input-block grid lg:grid-cols-8 gap-4'>
                                <div className='col-span-1 lg:col-span-2'>
                                    <LabelBlockDescription title='Fundraiser Goal Amount' text='How much money would you like to raise for this Fundraiser?' />
                                </div>
                                <div className='lg:col-start-4 lg:col-span-5'>
                                    <Input placeholder='Goal amount' type="text" defaultValue={goalAmount} onChange={(e) => setGoalAmount(e.target.value)} name="number" errorMessage={goalAmountError}/>
                                    <LabelDescription text='Learn more about ' link='country limitations.' path='' />
                                </div>
                            </div>
                            <div className='input-block grid lg:grid-cols-8 gap-4'>
                                <div className='col-span-1 lg:col-span-2'>
                                    <LabelBlockDescription title='Currency' />
                                </div>
                                <div className='lg:col-start-4 lg:col-span-5'>
                                    <Select defaultValue={currency} onChange={handleCurrencyIdChange} selectTitle="Currency" errorMessage={currencyError}
                                        options={currencies.map(currency => <option key={currency.id} id={currency.id} selected={currency.id === state.currency.id}>{currency.name}</option>)}
                                    />
                                </div>
                            </div>
                            <div className='input-block grid lg:grid-cols-8 gap-4'>
                                <div className='col-span-1 lg:col-span-2'>
                                <LabelBlockDescription title='Cover Photo or Video' text='Add a video or image to appear on the top of your Fundraiser.' />
                                </div>
                                <div className='lg:col-start-4 lg:col-span-5'>
                                    <FilePond
                                        ref={filePondRef}
                                        files={files}
                                        allowMultiple={true}
                                        allowReorder={true}
                                        maxFiles={3}
                                        name="files"
                                        labelIdle={'<div class="flex flex-col"><div class="font-osb"><span class="filepond--label-action text-primary">Click to upload</span> or drag here</div><div class="text-neutral">PNG, JPG or MP4 (max. 2mb)</div></div>'}
                                        onpreparefile={(file, output) => {
                                            const img = document.createElement("img");
                                            img.src = URL.createObjectURL(output);
                                        }}
                                        imageResizeTargetWidth={null}
                                        imageResizeTargetHeight={null}
                                        imageResizeUpscale={false}
                                        imageResizeMode={"contain"}
                                        imageEditEditor={create({
                                            cropMinImageWidth: 128,
                                            cropMinImageHeight: 128
                                        })}
                                    />
                                    <span className="font-bold text-error mb-4">{imageError}</span>
                                </div>
                                <div className='lg:col-start-4 lg:col-span-5'>
                                    <div class='divider text-neutral'>or</div>
                                </div>
                                <div className='lg:col-start-4 lg:col-span-5'>
                                    <Input placeholder='Add a Youtube link' type='text' />
                                    <LabelDescription text='Youtube Video Link' />
                                </div>
                            </div>
                            <div className='form-control my-3'>
                                <label className='cursor-pointer flex'>
                                    <input type='checkbox' className='checkbox checkbox-accent'></input>
                                    <span className='label-text mx-2'>Agree to terms and services</span>
                                </label>
                            </div>
                        <div className='flex justify-end'>
                            <button onClick={submitform} className='btn btn-primary my-4'>
                                Update Fundraiser
                            </button>
                        </div> 
                    </form>
                </div>
            )}
        </div>
    );
}

export default FundraiserEditForm;