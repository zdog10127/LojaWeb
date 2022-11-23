import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:7271/'
});

export default api;