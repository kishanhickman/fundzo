import { GET_ALL_COUNTRIES } from "../actions/constants";

const initialState = [];

const countryReducer = (state = initialState, action) => {
    const { type, payload } = action;

    switch (type) {
        case GET_ALL_COUNTRIES:
            return payload;
        default:
            return state;
    }
};

export default countryReducer;