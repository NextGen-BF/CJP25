import axios from "axios";

const axiosInstance = axios.create({});

axiosInstance.interceptors.request.use(async (config) =>{
    config.headers.Authorization = `Bearer ${localStorage.getItem("JWT-BM")}`;
    return config
});

export default axiosInstance;