import axios from 'axios';

const http = axios.create({
  baseURL: 'http://195.133.144.247/api/',
});

export default {
  HTTP: http,
};
