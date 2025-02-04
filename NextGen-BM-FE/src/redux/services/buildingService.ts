import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, {AxiosError} from "axios";
import { apiURL } from "../../api/shared";
import { Building } from "../../models/building";

export const createBuilding=createAsyncThunk("building/new", async(building: Building)=> {
    return await axios.post(`${apiURL}/building/new`, building)
    .then(function(response){
        return response.data;
    }).catch((err: Error | AxiosError) => {
        if(axios.isAxiosError(err))
            return err.response
        return err;
    })
})