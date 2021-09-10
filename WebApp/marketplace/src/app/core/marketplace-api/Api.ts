import axios from 'axios'

export default () => {
  return axios.create({
    baseURL: 'https://localhost:44313/api',
    withCredentials: false,
    headers: {
      "content-type": "application/json",
      "Accept": "application/json",
      "Access-Control-Allow-Origin": "*",
      "Access-Control-Allow-Methods": "GET, PUT, POST, DELETE, OPTIONS",
      "Access-Control-Allow-Headers": "Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With,observe",
      "Access-Control-Allow-Credentials": "true",
    }
  })
}