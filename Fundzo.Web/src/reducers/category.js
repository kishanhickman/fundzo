import { GET_ALL_CATEGORIES } from "../actions/constants";

const initialState = [];

const categoryReducer = (state = initialState, action) => {
    const { type, payload } = action;

    switch (type) {
        case GET_ALL_CATEGORIES:
            return payload;
        default:
            return state;
    }
};

export default categoryReducer;