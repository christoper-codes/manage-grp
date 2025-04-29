<script setup lang="ts">
import { computed, onMounted, ref, type Ref, watch } from 'vue';
import BaseBreadcrumb from '@/components/shared/BaseBreadcrumb.vue';
import AddressForm from '@/components/forms/AddressForm.vue';
import ContactForm from '@/components/forms/ContactForm.vue';
import { useI18n } from 'vue-i18n';
import { useField, useForm } from 'vee-validate';
import { useStatesStore } from '@/stores/app/states';
import dataTableImg from '@/assets/images/data/data-table-img.png';
import dataCircleImg from '@/assets/images/data/data-circle-img.jpeg';
import { useMunicipalitiesStore } from '@/stores/app/municipalities';
import { providersStoreOrUpdateSchema } from '@/validation/providers/storeOrUpdate';
import { useDateFormat } from '@/composables/dateFormat';
import { usePrividersStore } from '@/stores/app/providers';
import { useDependenciesStore } from '@/stores/app/dependencies';
import { useAreasStore } from '@/stores/app/areas';
import { usePositionsStore } from '@/stores/app/positions';
import { contactStoreOrUpdateSchema } from '@/validation/contacts/storeOrUpdate';
import { addressStoreOrUpdateSchema } from '@/validation/address/storeOrUpdate';
import { providersSearchSchema } from '@/validation/providers/search';
import { options } from '@fullcalendar/core/preact';





// i18n translation
const { t } = useI18n();
// Composables
const { dateFormat } = useDateFormat();

// Stores
const statesStore = useStatesStore();
const municipalitiesStore = useMunicipalitiesStore();
const dependenciesStore = useDependenciesStore();
const areasStore = useAreasStore();
const positionsStore = usePositionsStore();
const providersStore = usePrividersStore();

// Form for searching dependencies
const { handleSubmit: handleSearchSubmit } = useForm({ validationSchema: providersSearchSchema(t) });
const searchStateSelected = useField('searchStateSelected');
const searchMunicipalitySelected = useField('searchMunicipalitySelected');
const searchDependencySelected = useField('searchDependencySelected');



//DATA
const states: Ref<any[]> = ref([]);
const municipalities: Ref<any[]> = ref([]);
const loading: Ref<boolean> = ref(false);
const search = ref();
const providers: Ref<any[]> = ref([]);
const provider: Ref<object> = ref({});
const dialog = ref(false);
const isProvidersStore = ref(true);
const dialogDelete = ref(false);
const dependencies: Ref<any[]> = ref([]);
const areas: Ref<any[]> = ref([]);
const positions: Ref<any[]> = ref([]);
const providersDatta = ref();
const step = ref(1)
const contactFormRef = ref<any>(null);
const addressFormRef = ref<any>(null);

const totalSteps = 3

function next() {
    
    if (step.value == 1) {
        console.log(step.value)
        handleStoreOrUpdateProviders();
    }
    else if(step.value == 2){
        console.log(step.value)
        contactFormRef.value.handleStoreOrUpdateContact()
    }
}

function finish() {
    addressFormRef.value.handleStoreOrUpdateAddress()
}

function back() {

  if (step.value > 1) {
    step.value= step.value - 1
    console.log(step.value)
  }
}


const scrollInvoked = ref(0)
const  onScroll = () => {
    scrollInvoked.value++
}
const itemContactForEdit = ref();
const itemAddressForEdit = ref();


// Header for the table
const headers = ref([
    { title: t('ITEM_IMAGE_HEADER'), key: 'ITEM_IMAGE_HEADER' },
    { title: t('NAME_HEADER'), key: 'name' },
    { title: t('SOCIAL_REASON_HEADER'), key: 'socialReason' },
    { title: t('CORPORATE_PURPOSE_HEADER'), key: 'corporatePurpose' },
    { title: t('RFC_HEADER'), key: 'rfc' },
    { title: t('CREATED_AT_HEADER'), key: 'createdAt' },
    { title: t('ACTIONS_HEADER'), key: 'actions', sortable: false }
]);


// Form for storing providers

const { handleSubmit: handleStoreOrUpdateSubmit, resetForm } = useForm({
  validationSchema: providersStoreOrUpdateSchema(t),
});

const socialReason = useField('socialReason');
const name = useField('name');
const corporatePurpose = useField('corporatePurpose');
const rfc = useField('rfc');

const dependencyId = useField('dependencyId');


// Arrow functions




const itemGenericProps = (item: any) => {
  return {
    title: item.name,
    subtitle: item.abbreviation,
  };
};

const editProvider = (item: any) => {
    console.log(item)
    isProvidersStore.value = false;
    socialReason.value.value = item.socialReason
    name.value.value = item.name
    corporatePurpose.value.value = item.corporatePurpose
    rfc.value.value = item.rfc
    itemContactForEdit.value = item.contact
    itemAddressForEdit.value = item.address
    dialog.value = true;
};

const deleteProvider = (item: object) => {
    dialogDelete.value = true;
    provider.value = item;
}

const storePosition = () => {
    console.log(step.value)
    itemContactForEdit.value = null
    itemAddressForEdit.value = null
    resetForm();
    isProvidersStore.value = true;
}

const close = () => {
    dialog.value = false;
    dialogDelete.value = false;
    isProvidersStore.value = true;
    step.value = 1;
    resetForm();
};

const formTitle = computed(() => {
    return isProvidersStore.value ? t('ADD_NEW_ITEM_FIELD') : t('UPDATE_ITEM_FIELD');
});

// Watchers, lifecycle hooks, and async functions

watch(dependencyId.value, async (val) => {
  if (val) {
    const [areasData, positionsData] = await Promise.all([
        areasStore.areasByDependency(val, loading, t),
        positionsStore.positionsByDependency(val, loading, t)
    ]);
    areas.value = areasData;
    positions.value = positionsData;
  }
});

watch(searchMunicipalitySelected.value, async (val) => {
  if (val) {
    dependencies.value = await dependenciesStore.dependenciesByMunicipality(val.id, loading, t);
  }
});

onMounted(async () => {
  states.value = await statesStore.index(loading, t);
});

watch(searchStateSelected.value, async (val) => {
  if (val) {
    municipalities.value = await municipalitiesStore.index(val.id, loading, t);
  }
});


const handleSearchProviders = handleSearchSubmit(async (values: Record<string, any>) => {
  await indexProviders(values.searchDependencySelected.id);
});


const validationContactProviders = async (values: Record<string, any>) => {
    step.value = step.value + 1
    providersDatta.value['contact'] = values
    console.log(providersDatta.value)
};

const handleStoreOrUpdateProviders = handleStoreOrUpdateSubmit(async (values: Record<string, any>) => {
    step.value = step.value + 1
    providersDatta.value = values;
    console.log(providersDatta.value)
});

const addAddress = async (values: any) => {
    console.log(values)
    providersDatta.value['address'] = values
    providersDatta.value['createdAt']=  "2025-04-15T03:22:59.9792028";
    console.log(providersDatta.value)
    await providersStore.storeOrUpdateProviders(providersDatta.value, loading, t, isProvidersStore.value);
    await indexProviders(providersDatta.value.contact.dependencyId);
    close();
};

const indexProviders = async (id:number) => {
    providers.value = await providersStore.getProvidersBy(id, loading, t);
};

const handleDeleteProvider = async () => {
  await providersStore.deleteProviders(provider.value, loading, t);
  await indexProviders(0);
  provider.value = {};
  close();
}




</script>
<template>
    <div data-aos="fade-left" data-aos-duration="1500">
        <BaseBreadcrumb title="PROVIDERS"></BaseBreadcrumb>
        <div class="tw-pt-7 tw-pb-1 tw-px-7 tw-rounded-xl tw-bg-container-bg tw-shadow-sm tw-w-full mb-8 tw-flex tw-items-center tw-gap-5">
            <v-select
              color="primary"
              clearable
              :label="$t('ACTIVE_STATES')"
              v-model="searchStateSelected.value.value"
              :item-props="itemGenericProps"
              :items="states"
              :error-messages="searchStateSelected.errorMessage.value"
            ></v-select>
            <v-select
              color="primary"
              clearable
              :label="$t('ACTIVE_MUNICIPALITIES')"
              v-model="searchMunicipalitySelected.value.value"
              :item-props="itemGenericProps"
              :items="municipalities"
              :error-messages="searchMunicipalitySelected.errorMessage.value"
            ></v-select>
            <v-select
              color="primary"
              clearable
              :label="$t('ACTIVE_DEPENDENCIES')"
              v-model="searchDependencySelected.value.value"
              :item-props="itemGenericProps"
              :items="dependencies"
              :error-messages="searchDependencySelected.errorMessage.value"
          ></v-select>
          <v-btn @click="handleSearchProviders" :loading="loading" :disabled="loading" class="!tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white !tw-mb-6" variant="flat" size="large" dark>{{ $t('SEARCH_FIELD') + ' ' + $t('PROVIDERS') }}</v-btn>
        </div>
        <v-row>
        <v-col cols="12">
            <v-card elevation="10">
                <v-data-table
                    class=" rounded-md datatabels productlist"
                    :headers="headers"
                    :items="providers"
                    v-model:search="search"
                    items-per-page="5"
                    item-value="key"
                    color="primary"
                    show-select
                    :sort-by="[{ key: 'name', order: 'asc' }]"
                >
                    <template v-slot:item.ITEM_IMAGE_HEADER="{ item }">
                        <div class="d-flex gap-3 align-center">
                            <div>
                                <v-img :src="dataCircleImg" height="55" width="55" class="rounded-circle" cover></v-img>
                            </div>
                            <div>
                                <h6 class="text-h6">{{ item.key }}</h6>
                                <p class="textSecondary">{{ item.description }}</p>
                            </div>
                        </div>
                    </template>
                    <template v-slot:top>
                        <v-toolbar class="bg-surface" flat>
                            <v-dialog v-model="dialog" max-width="700">
                                <template v-slot:activator="{ props }">
                                    <div class="d-md-flex block justify-space-between w-100 pa-6 align-center">
                                        <v-text-field
                                            clearable
                                            v-model="search"
                                            append-inner-icon="mdi-magnify"
                                            :label="$t('SEARCH_FIELD')"
                                            single-line
                                            hide-details
                                            class="mb-md-0 mb-3"
                                        />
                                        <v-btn color="success" variant="flat" size="large" dark v-bind="props" @click="storePosition" >{{ $t('ADD_NEW_ITEM_FIELD') }}</v-btn>
                                    </div>
                                </template>

                                    
                            
                                    <v-card
                                        class="mx-auto tw-py-3"
                                    >
                                    

                                    <v-stepper v-model="step">

                                        <v-stepper-header>
                                            <v-stepper-item :title="$t('LEARN_FIELD')" :complete="step > 1" :step="1" :value="1"></v-stepper-item>
                                            <v-divider></v-divider>
                                            <v-stepper-item :title="$t('CONTACTS')" :complete="step > 2" :step="2" :value="2"></v-stepper-item>
                                            <v-divider></v-divider>
                                            <v-stepper-item :title="$t('ADDRESSES')" :complete="step > 3" :step="3" :value="3"></v-stepper-item>
                                        </v-stepper-header>

                                        <v-stepper-window>
                                            <v-stepper-window-item :value="1">
                                                <v-card v-scroll.self="onScroll" class="overflow-y-auto" max-height="400">
                                                    <div class="tw-grid tw-grid-cols-2 tw-w-full tw-gap-5 tw-px-10 tw-p-5">
                                                        <v-text-field clearable v-model="name.value.value" :label="$t('NAME_FIELD')" :error-messages="name.errorMessage.value"></v-text-field>
                                                        <v-text-field clearable v-model="rfc.value.value" :label="$t('RFC_HEADER')" :error-messages="rfc.errorMessage.value"></v-text-field>
                                                        <v-textarea
                                                            class="!tw-w-full !tw-col-span-2"
                                                            :label="$t('SOCIAL_REASON_HEADER')"
                                                            row-height="30"
                                                            color="primary"
                                                            clearable
                                                            rows="3"
                                                            auto-grow
                                                            v-model="socialReason.value.value"
                                                            :error-messages="socialReason.errorMessage.value"
                                                        ></v-textarea>
                                                        <v-textarea
                                                            class="!tw-w-full !tw-col-span-2"
                                                            :label="$t('CORPORATE_PURPOSE_HEADER')"
                                                            row-height="30"
                                                            color="primary"
                                                            clearable
                                                            rows="3"
                                                            auto-grow
                                                            v-model="corporatePurpose.value.value"
                                                            :error-messages="corporatePurpose.errorMessage.value"
                                                        ></v-textarea>
                                                    </div>
                                                </v-card>
                                            </v-stepper-window-item>
                                            <v-stepper-window-item :value="2">
                                                <v-card v-scroll.self="onScroll" class="overflow-y-auto" max-height="300">
                                                    <ContactForm ref="contactFormRef" :itemForEdit="itemContactForEdit" :dependencies="dependencies" @storeOrUpdateContact="validationContactProviders"/>
                                                </v-card>
                                            </v-stepper-window-item>
                                            <v-stepper-window-item :value="3">
                                                <v-card v-scroll.self="onScroll" class="overflow-y-auto" max-height="300" max-width="1000">
                                                    <AddressForm ref="addressFormRef" :itemForEdit="itemAddressForEdit" :dependencies="dependencies" :loading="loading" @storeOrUpdateDireccion="addAddress"/>
                                                </v-card>
                                            </v-stepper-window-item>
                                        </v-stepper-window>

                                        <v-stepper-actions>
                                            <template #prev>
                                                <v-btn @click="back" :disabled="step === 1">{{ $t('BACK_FIELD') }}</v-btn>
                                            </template>

                                            <template #next>
                                                <v-btn
                                                    @click="step === totalSteps ? finish() : next()"
                                                    :disabled="step === totalSteps + 1"
                                                >
                                                    {{ step === totalSteps ? $t('SAVE_FIELD') : $t('NEXT_FIELD') }}
                                                </v-btn>
                                            </template>
                                        </v-stepper-actions>

                                    </v-stepper>

                                    </v-card>

                            </v-dialog>
                            
                            <v-dialog v-model="dialogDelete" max-width="600px">
                                <v-card>
                                    <v-card-title class="pa-4 !tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white !tw-mb-7">
                                        <span class="tw-text-base tw-font-bold">{{ $t('DELETE_ITEM_NOTICE') }}</span>
                                    </v-card-title>
                                    <v-card-actions class="!tw-my-3">
                                        <v-spacer></v-spacer>
                                        <v-btn color="error" variant="flat" dark @click="close">{{ $t('CANCEL_FIELD') }}</v-btn>
                                        <v-btn color="success" variant="flat" dark @click="handleDeleteProvider">{{ $t('CONFIRM_FIELD') }}</v-btn>
                                        <v-spacer></v-spacer>
                                    </v-card-actions>
                                </v-card>
                            </v-dialog>
                        </v-toolbar>
                    </template>

                    <template v-slot:item.createdAt="{ item }">
                        <span>{{ dateFormat(item.createdAt) }}</span>
                    </template>
                    <template v-slot:item.actions="{ item }">
                        <div class="d-flex gap-3">
                            <Icon
                                icon="solar:pen-new-square-broken"
                                height="20"
                                class="text-primary cursor-pointer"
                                size="small"
                                @click="editProvider(item)"
                            />
                            <Icon
                                icon="solar:trash-bin-minimalistic-linear"
                                height="20"
                                class="text-error cursor-pointer"
                                size="small"
                                @click="deleteProvider(item)"
                            />
                        </div>
                    </template>
                    <template v-slot:no-data>
                      <v-img :src="dataTableImg" class="tw-w-60 tw-h-auto tw-mx-auto" cover></v-img>
                    </template>
                </v-data-table>
            </v-card>
        </v-col>
    </v-row>
    </div>

    
    
</template>