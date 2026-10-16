import { GET_ALL_FUNDRAISERTYPES } from "../actions/constants";

const initialState = [];

const fundraiserTypeReducer = (state = initialState, action) => {
    const { type, payload } = action;

    switch (type) {
        case GET_ALL_FUNDRAISERTYPES:
            return payload;
        default:
            return state;
    }
};

export default fundraiserTypeReducer;