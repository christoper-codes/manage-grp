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

export const useBudgetaryKeyDocumentTypeStore = defineStore('budgetaryKeyDocumentType', () => {

  const budgetaryKeyDocumentTypeByDependency = async (dependencyId:number, loading:{value: boolean}, t:any) => {
      loading.value = true;
      try {
        const response = await axios.get(`/api/BudgetKeyDefault/Dependency/${dependencyId}`);

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

  const storeOrUpdatebudgetaryKeyDocumentType = async (values: IBudgetaryKeyDocumentTypeValues, loading:{value: boolean}, t: any, isbudgetaryKeyDocumentTypeStore: boolean) => {
    loading.value = true;

    try {
      const response = isbudgetaryKeyDocumentTypeStore ? await axios.post('/api/BudgetKeyDefault', values)
                        : await axios.put(`/api/BudgetKeyDefault/${values.id}`, values);

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

  const deletebudgetaryKeyDocumentType = async (id: number, loading:{value: boolean}, t: any) => {
    loading.value = true;

    try {
      const response = await axios.delete(`/api/BudgetKeyDefault/${id}`);

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
    budgetaryKeyDocumentTypeByDependency,
    storeOrUpdatebudgetaryKeyDocumentType,
    deletebudgetaryKeyDocumentType
  }
})
