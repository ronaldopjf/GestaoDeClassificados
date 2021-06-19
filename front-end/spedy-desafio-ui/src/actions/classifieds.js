import {
    CREATE_CLASSIFIED,
    RETRIEVE_CLASSIFIEDS,
    UPDATE_CLASSIFIED,
    DELETE_CLASSIFIED,
    DELETE_ALL_CLASSIFIEDS
} from "./types";

import ClassifiedService from "../services/classified.service";

export const createClassified = (title, description) => async (dispatch) => {
    try {
        const res = await ClassifiedService.create({ title, description });

        dispatch({
            type: CREATE_CLASSIFIED,
            payload: res.data,
        });

        return Promise.resolve(res.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const retrieveClassifieds = () => async (dispatch) => {
    try {
        const res = await ClassifiedService.getAll();

        dispatch({
            type: RETRIEVE_CLASSIFIEDS,
            payload: res.data,
        });
    } catch (err) {
        console.log(err);
    }
};

export const updateClassified = (id, data) => async (dispatch) => {
    try {
        const res = await ClassifiedService.update(id, data);

        dispatch({
            type: UPDATE_CLASSIFIED,
            payload: data,
        });

        return Promise.resolve(res.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const deleteClassified = (id) => async (dispatch) => {
    try {
        await ClassifiedService.delete(id);

        dispatch({
            type: DELETE_CLASSIFIED,
            payload: { id },
        });
    } catch (err) {
        console.log(err);
    }
};

export const deleteAllClassifieds = () => async (dispatch) => {
    try {
        const res = await ClassifiedService.deleteAll();

        dispatch({
            type: DELETE_ALL_CLASSIFIEDS,
            payload: res.data,
        });

        return Promise.resolve(res.data);
    } catch (err) {
        return Promise.reject(err);
    }
};

export const findClassifiedsByTitle = (title) => async (dispatch) => {
    try {
        const res = await ClassifiedService.findByTitle(title);

        dispatch({
            type: RETRIEVE_CLASSIFIEDS,
            payload: res.data,
        });
    } catch (err) {
        console.log(err);
    }
};