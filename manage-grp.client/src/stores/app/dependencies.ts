import axios from "axios";
import { defineStore } from "pinia";
import { error } from "@/utils/toast/Error";
import { success } from "@/utils/toast/Success";

interface DependencyValues {
  id?: number;
  municipalityId: number;
  name: string;
  acronym: string;
  rfc: string;
  isActive: boolean;
}

export const useDependenciesStore = defineStore('dependencies', () => {

  const dependenciesByMunicipality = async (municipalityId:number, loading:{value: boolean}, t:any) => {
      loading.value = true;
      try {
        const response = await axios.get(`/api/Dependency/Municipality/${municipalityId}`);

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

  const storeOrUpdateDependency = async (values: DependencyValues, loading:{value: boolean}, t: any, isDependencyStore: boolean) => {
    loading.value = true;

    try {
      const response = isDependencyStore ? await axios.post('/api/Dependency', values)
                        : await axios.put(`/api/Dependency/${values.id}`, values);

      if(response.status === 200){
        console.log('exito');
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

  const deleteDependency = async (id: number, loading:{value: boolean}, t: any) => {
    loading.value = true;

    try {
      const response = await axios.delete(`/api/Dependency/${id}`);

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
    dependenciesByMunicipality,
    storeOrUpdateDependency,
    deleteDependency
  }
})
