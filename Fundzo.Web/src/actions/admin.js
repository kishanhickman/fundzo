import { GET_ALL_CATEGORIES, GET_ALL_ORGANISATIONS, GET_ALL_CURRENCIES, GET_ALL_COUNTRIES } from "./constants";
import AdminService from "../services/admin.service";

export const retrieveCategories = () => async (dispatch) => {
    try {
        const res = await AdminService.getAllCategories();
        dispatch({
            type: GET_ALL_CATEGORIES,
            payload: res.data,
        });
    } catch (err) {
        console.log(err);
    }
};

export const retrieveOrganisations = () => async (dispatch) => {
    try {
        const res = await AdminService.getAllOrganisations();
        dispatch({
            type: GET_ALL_ORGANISATIONS,
            payload: res.data,
        });
    } catch (err) {
        console.log(err);
    }
};

export const retrieveCurrency = () => async (dispatch) => {
    try {
        const res = await AdminService.getAllCurrencies();
        dispatch({
            type: GET_ALL_CURRENCIES,
            payload: res.data,
        });
    } catch (err) {
        console.log(err);
    }
};

export const retrieveCountries = () => async (dispatch) => {
    try {
        const res = await AdminService.getAllCountries();
        dispatch({
            type: GET_ALL_COUNTRIES,
            payload: res.data,
        });
    } catch (err) {
        console.log(err);
    }
};