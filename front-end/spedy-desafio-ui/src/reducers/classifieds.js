import {
    CREATE_CLASSIFIED,
    RETRIEVE_CLASSIFIEDS,
    UPDATE_CLASSIFIED,
    DELETE_CLASSIFIED,
    DELETE_ALL_CLASSIFIEDS
} from "../actions/types";

const initialState = [];

function classifiedReducer(classifieds = initialState, action) {
    const { type, payload } = action;

    switch (type) {
        case CREATE_CLASSIFIED:
            return [...classifieds, payload];

        case RETRIEVE_CLASSIFIEDS:
            return payload;

        case UPDATE_CLASSIFIED:
            return classifieds.map((classified) => {
                if (classified.id === payload.id) {
                    return {
                        ...classified,
                        ...payload,
                    };
                } else {
                    return classified;
                }
            });

        case DELETE_CLASSIFIED:
            return classifieds.filter(({ id }) => id !== payload.id);

        case DELETE_ALL_CLASSIFIEDS:
            return [];

        default:
            return classifieds;
    }
};

export default classifiedReducer;