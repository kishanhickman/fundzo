import { GET_ALL_ORGANISATIONS } from "../actions/constants";

const initialState = [];

const organisationReducer = (state = initialState, action) => {
    const { type, payload } = action;

    switch (type) {
        case GET_ALL_ORGANISATIONS:
            return payload;
        default:
            return state;
    }
};

export default organisationReducer;