import axios from "axios";
import { defineStore } from "pinia";
import { error } from "@/utils/toast/Error";
import { success } from "@/utils/toast/Success";

interface IAreaValues {
  id?: number;
  dependencyId: number;
  name: string;
  acronym: string;
  description: string;
  isActive: boolean;
}

export const useAreasStore = defineStore('areas', () => {

  const areasByDependency = async (dependencyId:number, loading:{value: boolean}, t:any) => {
      loading.value = true;
      try {
        const response = await axios.get(`/api/Area/Dependency/${dependencyId}`);

        if(response.status === 200){
          success(t(response.data.message));
          return response.data.data;
        }

        error(t('ERROR_MESSAGE'));
        return [];
      } catch (ex: any) {
        error(ex.response.data.message);
      } finally {
        loading.value = false
      }
  }

  const storeOrUpdateArea = async (values: IAreaValues, loading:{value: boolean}, t: any, isAreaStore: boolean) => {
    loading.value = true;

    try {
      const response = isAreaStore ? await axios.post('/api/Area', values)
                        : await axios.put(`/api/Area/${values.id}`, values);

      if(response.status === 200){
        success(t(response.data.message));
        return;
      }

      error(t('ERROR_MESSAGE'));
      return [];
    } catch (ex: any) {
      error(ex.response.data.message || t('ERROR_MESSAGE'));
    }
    finally {
      loading.value = false;
    }
  }

  const deleteArea = async (id: number, loading:{value: boolean}, t: any) => {
    loading.value = true;

    try {
      const response = await axios.delete(`/api/Area/${id}`);

      if(response.status === 200){
        success(t(response.data.message));
        return;
      }

      error(t('ERROR_MESSAGE'));
    } catch(ex: any) {
      error(ex.response.data.message || t('ERROR_MESSAGE'));
    } finally {
      loading.value = false;
    }
  }

  return {
    areasByDependency,
    storeOrUpdateArea,
    deleteArea
  }
})
