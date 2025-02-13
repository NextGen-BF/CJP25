import { createAsyncThunk } from "@reduxjs/toolkit";
import { Property } from "../../models/property";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";

export const getProperty = async(propertyId:number)=>{
    return await axios.get(`${apiURL}/property/${propertyId}`, {
        headers: 
            {Authorization: `Bearer ${localStorage.getItem('JWT-BM')}`}
        })
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
    };
export const deleteProperty = createAsyncThunk("property/delete", async(propertyId:number)=>{
    return await axios.get(`${apiURL}/property/delete/${propertyId}`, {
        headers: 
            {Authorization: `Bearer ${localStorage.getItem('JWT-BM')}`}
        })
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