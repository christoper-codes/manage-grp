import axios from "axios";
import { defineStore } from "pinia";
import { useRouter } from "vue-router";
import { toast } from 'vue3-toastify'

interface LoginValues {
  email: string;
  password: string;
  remember: boolean;
}

export const useAuthStore = defineStore('auth', () => {
  const router = useRouter();

  const isAuthenticated = () => {
    return localStorage.getItem('token') !== null;
  }

  const roles = () => {
    return JSON.parse(localStorage.getItem('roles') || '[]');
  }

  const login = async (values: LoginValues, loading:{value: boolean}) => {
    loading.value = true;
    try {
      //const baseUrl = `${import.meta.env.VITE_API_URL}/users`;
      //const user = await fetchWrapper.post(`${baseUrl}/authenticate`, { username, password });

      //const response = await axios.post('http://localhost:3000/auth/login', values);
      //fake data for response
      const response = {
        status: 200,
        data: {
          token: 'aASDsxaADSsd13223casASF2345vdsFW3',
          user: {
            id: 1,
            email: 'lila@gmail.com',
            name: 'Lila',
          },
          roles: ['member', 'admin']
        }
      };

      if(response.status === 200){
        localStorage.setItem('token', response.data.token);
        localStorage.setItem('user', JSON.stringify(response.data.user));
        localStorage.setItem('roles', JSON.stringify(response.data.roles));

        router.push({ name: 'dashboard' });
      }
    } catch (error: any) {
      toast(error.response.data.message, {
        "theme": "auto",
        "type": "error",
        "dangerouslyHTMLString": true
      });
    } finally {
      loading.value = false;
    }
  }

  return {
    isAuthenticated,
    roles,
    login
  }
})
