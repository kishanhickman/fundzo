import { GET_ALL_CURRENCIES } from "../actions/constants";

const initialState = [];

const currencyReducer = (state = initialState, action) => {
    const { type, payload } = action;

    switch (type) {
        case GET_ALL_CURRENCIES:
            return payload;
        default:
            return state;
    }
};

export default currencyReducer;