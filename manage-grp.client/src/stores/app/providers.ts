import axios from "axios";
import { defineStore } from "pinia";
import { error } from "@/utils/toast/Error";
import { success } from "@/utils/toast/Success";
import { ref, type Ref } from "vue";



export const usePrividersStore = defineStore('providers', () => {

  const providers: Ref<any[]> = ref([]);

  const getProvidersBy = async (dependencyId:number, loading:{value: boolean}, t:any) => {
    return providers.value;
  }

  const storeOrUpdateProviders = async (values: any, loading:{value: boolean}, t: any, isbudgetaryKeyDocumentTypeStore: boolean) => {
    providers.value.push(values)
  }

  const deleteProviders = async (id: any, loading:{value: boolean}, t: any) => {
    console.log(id)
    providers.value = providers.value.filter(provider => provider.name !== id.value.name);
    console.log(providers.value)
  }

  return {
    getProvidersBy,
    storeOrUpdateProviders,
    deleteProviders
  }
})
