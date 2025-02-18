import axios from "axios";
import { defineStore } from "pinia";
import { useRouter } from "vue-router";
import { error } from "@/utils/toast/Error";

interface LoginValues {
  email: string;
  password: string;
  remember: boolean;
}

export const useAuthStore = defineStore('auth', () => {
  const router = useRouter();

  const isAuthenticated = () => {
    return localStorage.getItem('jwtTokens') !== null;
  }

  const roles = () => {
    return JSON.parse(localStorage.getItem('roles') || '[]');
  }

  const login = async (values: LoginValues, loading:{value: boolean}, t: any) => {
    loading.value = true;
    try {
      const response = await axios.post('/api/Users/Login', values);

      if(response.status === 200){
        localStorage.setItem('jwtTokens', JSON.stringify(response.data.data.jwtTokens));
        localStorage.setItem('user', JSON.stringify(response.data.data.user));
        localStorage.setItem('roles', JSON.stringify(response.data.data.roles || ['member', 'admin', 'superadmin']));
        router.push({ name: 'dashboard' });
        return;
      }

      error(t('ERROR_MESSAGE'));
    } catch (error: any) {
      error(error.response.data.message);
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
