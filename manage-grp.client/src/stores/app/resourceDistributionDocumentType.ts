import axios from "axios";
import { defineStore } from "pinia";
import { error } from "@/utils/toast/Error";
import { success } from "@/utils/toast/Success";

interface ReosurceDistributionDocumentTypeValues {
  id?: number;
  dependencyId: number;
  name: string;
  description: string;
  isActive: boolean;
  mandatory: boolean;
}


export const useRecourceDistributionDocumentTypeStore = defineStore('resourceDistributionDocumentType', () => {

  const resourceDistributionDocumentTypeByDependency = async (dependencyId:number, loading:{value: boolean}, t:any) => {
      loading.value = true;
      try {
        const response = await axios.get(`/api/ResourceDistributionDocumentType/Dependency/${dependencyId}`);

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

  const storeOrUpdateResourceDistributionDocumentType = async (values: ReosurceDistributionDocumentTypeValues, loading:{value: boolean}, t: any, isbudgetaryKeyDocumentTypeStore: boolean) => {
      loading.value = true;
  
      try {
        const response = isbudgetaryKeyDocumentTypeStore ? await axios.post('/api/ResourceDistributionDocumentType', values)
                          : await axios.put(`/api/ResourceDistributionDocumentType/${values.id}`, values);
  
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

    const deleteResourceDistributionDocumentType = async (id: number, loading:{value: boolean}, t: any) => {
      loading.value = true;
  
      try {
        const response = await axios.delete(`/api/ResourceDistributionDocumentType/${id}`);
  
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
    deleteResourceDistributionDocumentType,
    storeOrUpdateResourceDistributionDocumentType,
    resourceDistributionDocumentTypeByDependency
  }
})
