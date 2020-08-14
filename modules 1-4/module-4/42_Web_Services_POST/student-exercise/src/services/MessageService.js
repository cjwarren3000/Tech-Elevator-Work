import axios from 'axios';

const http = axios.create({
  baseURL: "http://localhost:3000"
});

export default {

  get(id) {
    return http.get(`/messages/${id}`);
  },

  newMessage(message){
    return http.post('/messages', message);
  },

  updateMessage(message, id){
    return http.put(`/messages/${id}`, message);
  },

  deleteMessage(id){
    return http.delete(`/messages/${id}`);
  }

}
