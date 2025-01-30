import { createAsyncThunk } from "@reduxjs/toolkit";
import axios, { AxiosError } from "axios";
import { apiURL } from "../../api/shared";

interface loginCredential {
    email: string,
    password: string,
}

export const loginCall = createAsyncThunk("account/login", async (credentials: loginCredential) => {
    return await axios.post(`${apiURL}/account/login`, credentials
).then(function (response) {
        return response.data
    }).catch((err: Error | AxiosError) => { 
        if (axios.isAxiosError(err))
            return err.response
        return err;
    })
})