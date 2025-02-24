import { createAsyncThunk } from "@reduxjs/toolkit";
import { Property } from "../../models/property";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";
import axiosInstance from "./interceptors/authorizationInterceptors";

export const createProperty = createAsyncThunk('/property/new', async(property:Property)=>{
    return await axiosInstance.post(`${apiURL}/property/new`, property)
        .then(
            function(response){
                return response.data;
            }
        )
        .catch((err: Error | AxiosError) => {
            if(axios.isAxiosError(err))
                return Promise.reject(err.response);
            return Promise.reject(err);
        })
    }
);