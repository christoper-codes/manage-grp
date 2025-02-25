import axios from "axios";
import { defineStore } from "pinia";
import { error } from "@/utils/toast/Error";
import { success } from "@/utils/toast/Success";

interface IPositionValues {
  id?: number;
  dependencyId: number;
  name: string;
  abbreviation: string;
  description: string;
  isActive: boolean;
}

export const usePositionsStore = defineStore('positions', () => {

  const positionsByDependency = async (dependencyId:number, loading:{value: boolean}, t:any) => {
      loading.value = true;
      try {
        const response = await axios.get(`/api/Position/Dependency/${dependencyId}`);

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

  const storeOrUpdatePosition = async (values: IPositionValues, loading:{value: boolean}, t: any, isPositionStore: boolean) => {
    loading.value = true;

    try {
      const response = isPositionStore ? await axios.post('/api/Position', values)
                        : await axios.put(`/api/Position/${values.id}`, values);

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

  const deletePosition = async (id: number, loading:{value: boolean}, t: any) => {
    loading.value = true;

    try {
      const response = await axios.delete(`/api/Position/${id}`);

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
    positionsByDependency,
    storeOrUpdatePosition,
    deletePosition
  }
})
