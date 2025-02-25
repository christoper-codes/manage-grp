import axios from "axios";
import { defineStore } from "pinia";
import { error } from "@/utils/toast/Error";
import { success } from "@/utils/toast/Success";

interface IContactValues {
  id?: number;
  dependencyId: number;
  areaId: number;
  positionId: number;
  firstName: string;
  middleName: string;
  paternalLastName: string;
  maternalLastName: string;
  email: string;
  phone: string;
  isActive: boolean;
}

export const useContactsStore = defineStore('contacts', () => {

  const contactsByDependency = async (dependencyId:number, loading:{value: boolean}, t:any) => {
      loading.value = true;
      try {
        const response = await axios.get(`/api/Contact/Dependency/${dependencyId}`);

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

  const storeOrUpdateContact = async (values: IContactValues, loading:{value: boolean}, t: any, isContactStore: boolean) => {
    loading.value = true;

    try {
      const response = isContactStore ? await axios.post('/api/Contact', values)
                        : await axios.put(`/api/Contact/${values.id}`, values);

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

  const deleteContact = async (id: number, loading:{value: boolean}, t: any) => {
    loading.value = true;

    try {
      const response = await axios.delete(`/api/Contact/${id}`);

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
    contactsByDependency,
    storeOrUpdateContact,
    deleteContact
  }
})
