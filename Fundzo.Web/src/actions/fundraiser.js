import { CREATE_FUNDRAISER, GET_ALL_FUNDRAISERS, GET_ALL_FUNDRAISERTYPES, UPDATE_FUNDRAISER } from "./constants";
import FundraiserService from "../services/fundraiser.service";

export const createFundraiser = (name, description, goalAmount, fundraiserTypeId, categoryId, organisationId, fundraiserStatusId, currencyId, userId, files) => async (dispatch) => {
    try {
        const res = await FundraiserService.create({ name, description, goalAmount, fundraiserTypeId, categoryId, organisationId, fundraiserStatusId, currencyId, userId, files });
        dispatch({
            type: CREATE_FUNDRAISER,
            payload: res.data,
        });
        return Promise.resolve(res.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const retrieveFundraisers = () => async (dispatch) => {
    try {
        const res = await FundraiserService.getAllFundraisers();
        dispatch({
            type: GET_ALL_FUNDRAISERS,
            payload: res.data,
        });
    } catch (err) {
        console.log(err);
    }
};

export const retrieveFundraiserTypes = () => async (dispatch) => {
    try {
        const res = await FundraiserService.getAllFundraiserTypes();
        dispatch({
            type: GET_ALL_FUNDRAISERTYPES,
            payload: res.data,
        });
    } catch (err) {
        console.log(err);
    }
};

export const updateFundraiser = (id, staticMediaId, fundraiserMediaId, data) => async (dispatch) => {
    try {
        const res = await FundraiserService.updateFundraiser(id, staticMediaId, fundraiserMediaId, data); 
        dispatch({
            type: UPDATE_FUNDRAISER,
            payload: data,
        });
        return Promise.resolve(res.data);
    } catch (err) {
        return Promise.reject(err);
    }
};
