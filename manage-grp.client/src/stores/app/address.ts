import axios from "axios";
import { defineStore } from "pinia";
import { error } from "@/utils/toast/Error";
import { success } from "@/utils/toast/Success";

interface IAddressValues {
  id?: number;
  dependencyId: number;
  neighborhood: string;
  street: string;
  exteriorNumber: string;
  interiorNumber: string;
  postalCode: string;
  latitude: string;
  longitude: string;
  reference: string;
  isActive: boolean;
}

export const useAddressStore = defineStore('address', () => {


  const storeOrUpdateAddress = async (values: IAddressValues, loading:{value: boolean}, t: any, isAddressStore: boolean) => {
    loading.value = true;

    try {
      const response = isAddressStore ? await axios.post('/api/Address', values)
                        : await axios.put(`/api/Address/${values.id}`, values);

      if(response.status === 200){
        console.log(response.data);
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

  return {
    storeOrUpdateAddress,
  }
})
