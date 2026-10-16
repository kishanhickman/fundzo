import { CREATE_FUNDRAISER, GET_ALL_FUNDRAISERS, UPDATE_FUNDRAISER } from "../actions/constants";

const initialState = [];

const fundraiserReducer = (state = initialState, action) => {
    const { type, payload } = action;

    switch (type) {
        case CREATE_FUNDRAISER:
            return [...state, payload];
        case GET_ALL_FUNDRAISERS:
            return payload;
        case UPDATE_FUNDRAISER:
            return state.map((fundraiser) => {
                if (fundraiser.id === payload.id) {
                    return {
                        ...fundraiser,
                        ...payload,
                    };
                } else {
                    return fundraiser;
                }
            });
        default:
            return state;
    }
};

export default fundraiserReducer;