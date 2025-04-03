import axios from "axios";
import { defineStore } from "pinia";
import { error } from "@/utils/toast/Error";
import { success } from "@/utils/toast/Success";

interface IBudgetaryKeyDocumentTypeValues {
  id?: number;
  dependencyId: number;
  key: string;
  description: string;
  isActive: boolean;
  mandatory: boolean;
}

export const useTenderDocumentTypeStore = defineStore('tenderDocumentType', () => {

  const tenderDocumentTypeByDependency = async (dependencyId:number, loading:{value: boolean}, t:any) => {
      loading.value = true;
      try {
        const response = await axios.get(`/api/TenderDocumentType/Dependency/${dependencyId}`);

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

  const storeOrUpdateTenderDocumentType = async (values: IBudgetaryKeyDocumentTypeValues, loading:{value: boolean}, t: any, isbudgetaryKeyDocumentTypeStore: boolean) => {
    loading.value = true;

    console.log('valor de actualizacion');
    console.log(values);

    try {
      const response = isbudgetaryKeyDocumentTypeStore ? await axios.post('/api/TenderDocumentType', values)
                        : await axios.put(`/api/TenderDocumentType/${values.id}`, values);

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

  const deleteTenderDocumentType = async (id: number, loading:{value: boolean}, t: any) => {
    loading.value = true;

    try {
      const response = await axios.delete(`/api/TenderDocumentType/${id}`);

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
    tenderDocumentTypeByDependency,
    storeOrUpdateTenderDocumentType,
    deleteTenderDocumentType
  }
})
