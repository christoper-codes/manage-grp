import axios from "axios";
import { defineStore } from "pinia";
import { error } from "@/utils/toast/Error";
import { success } from "@/utils/toast/Success";

export const useStatesStore = defineStore('states', () => {

  const index = async (loading:{value: boolean}, t: any) => {
      loading.value = true;
      try {
        const response = await axios.get('/api/States');

        if(response.status === 200){
          success(t(response.data.message));
          return response.data.data;
        }

        error(t('ERROR_MESSAGE'));
        return [];
      } catch (ex: any) {
        error(ex.response.data.message || t('ERROR_MESSAGE'));
      } finally {
        loading.value = false;
      }
  }

  return {
    index
  }
})
