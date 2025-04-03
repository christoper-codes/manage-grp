<script setup lang="ts">
import { computed, onMounted, ref, type Ref, watch } from 'vue';
import dataCircleImg from '@/assets/images/data/data-circle-img.jpeg';
import dataTableImg from '@/assets/images/data/data-table-img.png';
import BaseBreadcrumb from '@/components/shared/BaseBreadcrumb.vue';
import { useI18n } from 'vue-i18n';
import { useField, useForm } from 'vee-validate';
import { resourceDistributionDocumentTypeSearchSchema } from '@/validation/resourceDistributionDocumentType/search';
import { useMunicipalitiesStore } from '@/stores/app/municipalities';
import { resourceDistributionDocumentTypeStoreOrUpdateSchema } from '@/validation/resourceDistributionDocumentType/storeOrUpdate';

import { useStatesStore } from '@/stores/app/states';
import { useDependenciesStore } from '@/stores/app/dependencies';
import { useRecourceDistributionDocumentTypeStore } from '@/stores/app/resourceDistributionDocumentType';
import { useDateFormat } from '@/composables/dateFormat';




// i18n translation
const { t } = useI18n();

// Composables
const { dateFormat } = useDateFormat();

//Stores
const statesStore = useStatesStore();
const municipalitiesStore = useMunicipalitiesStore();
const dependenciesStore = useDependenciesStore();
const resoruceDistributionDocumentTypeStore = useRecourceDistributionDocumentTypeStore();




// Form for searching resourcedistributiondocumentstypes
const { handleSubmit: handleSearchSubmit } = useForm({ validationSchema: resourceDistributionDocumentTypeSearchSchema(t) });
const searchStateSelected = useField('searchStateSelected');
const searchMunicipalitySelected = useField('searchMunicipalitySelected');
const searchDependencySelected = useField('searchDependencySelected');

// Form for storing resourceDistributionDocumentType
const { handleSubmit: handleStoreOrUpdateSubmit, resetForm } = useForm({
  validationSchema: resourceDistributionDocumentTypeStoreOrUpdateSchema(t),
  initialValues: {
    isActive: true,
    mandatory: true
  },
});


const id = useField('id');
const dependencyId = useField('dependencyId');
const name = useField('name');
const mandatory = useField('mandatory');
const description = useField('description');
const isActive = useField('isActive');

// Header for the table
const headers = ref([
    { title: t('ITEM_IMAGE_HEADER'), key: 'ITEM_IMAGE_HEADER' },
    { title: t('DEPENDENCY_HEADER') + ' ID', key: 'dependencyId' },
    { title: t('NAME_HEADER'), key: 'name' },
    { title: t('DESCRIPTION_HEADER'), key: 'description' },
    { title: t('STATUS_HEADER'), key: 'isActive' },
    { title: t('MANDATORY_HEADER'), key: 'mandatory' },
    { title: t('CREATED_AT_HEADER'), key: 'createdAt' },
    { title: t('ACTIONS_HEADER'), key: 'actions', sortable: false }
]);


//DATA
const search = ref();
const dependencies: Ref<any[]> = ref([]);
const municipalities: Ref<any[]> = ref([]);
const loading: Ref<boolean> = ref(false);
const dialog = ref(false);
const isResourceDistributionDocumentTypeStore = ref(true);
const states: Ref<any[]> = ref([]);
const resourceDistributionDocumentTypes: Ref<any[]> = ref([]);
const resourceDistributionDocumentType: Ref<object> = ref({});
const dialogDelete = ref(false);


// Watchers,
const handleSearchResourceDistributionDocumentTypes = handleSearchSubmit(async (values: Record<string, any>) => {
  await indexResourceDistributionDocumentType(values.searchDependencySelected.id);
});

const handleStoreOrUpdateBudgetaryKeyDocumentType = handleStoreOrUpdateSubmit(async (values: Record<string, any>) => {
  await resoruceDistributionDocumentTypeStore.storeOrUpdateResourceDistributionDocumentType(values, loading, t, isResourceDistributionDocumentTypeStore.value);
  await indexResourceDistributionDocumentType(values.dependencyId);
  close();
});

const indexResourceDistributionDocumentType = async (id:number) => {
resourceDistributionDocumentTypes.value = await resoruceDistributionDocumentTypeStore.resourceDistributionDocumentTypeByDependency(id, loading, t);
  console.log(resourceDistributionDocumentTypes.value);
};

const handleDeleteBudgetaryKeyDocumentType = async () => {
  await resoruceDistributionDocumentTypeStore.deleteResourceDistributionDocumentType(resourceDistributionDocumentType.value.id, loading, t);
  await indexResourceDistributionDocumentType(resourceDistributionDocumentType.value.dependencyId);
  resourceDistributionDocumentType.value = {};
  close();
}

onMounted(async () => {
  states.value = await statesStore.index(loading, t);
});


watch(searchStateSelected.value, async (val) => {
  if (val) {
    municipalities.value = await municipalitiesStore.index(val.id, loading, t);
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

//ARRAY FUCTIONS

const formTitle = computed(() => {
    return isResourceDistributionDocumentTypeStore.value ? t('ADD_NEW_ITEM_FIELD') : t('UPDATE_ITEM_FIELD');
});
const storePosition = () => {
  resetForm();
  isResourceDistributionDocumentTypeStore.value = true;
}
const itemGenericProps = (item: any) => {
  return {
    title: item.name,
    subtitle: item.abbreviation,
  };
};


const editPosition = (item: any) => {
    isResourceDistributionDocumentTypeStore.value = false;
    id.value.value = item.id;
    dependencyId.value.value = item.dependencyId;
    name.value.value = item.name;
    mandatory.value.value = item.mandatory;
    description.value.value = item.description;
    dialog.value = true;
};

const deletePosition = (item: object) => {
  dialogDelete.value = true;
  resourceDistributionDocumentType.value = item;
}

const close = () => {
    dialog.value = false;
    //dialogDelete.value = false;
    isResourceDistributionDocumentTypeStore.value = true;
    resetForm();
};





</script>

<template>
    <div data-aos="fade-left" data-aos-duration="1500">
      <BaseBreadcrumb title="RESOURCE_DISTRIBUTION_DOCUMENT_TYPES"></BaseBreadcrumb>
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
          <v-btn @click="handleSearchResourceDistributionDocumentTypes" :loading="loading" :disabled="loading" class="!tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white !tw-mb-6" variant="flat" size="large" dark>{{ $t('SEARCH_FIELD') + ' ' + $t('RESOURCE_DISTRIBUTION_DOCUMENT_TYPES') }}</v-btn>
        </div>
    </div>

    <v-row>
        <v-col cols="12">
            <v-card elevation="10">
                <v-data-table
                    class=" rounded-md datatabels productlist"
                    :headers="headers"
                    :items="resourceDistributionDocumentTypes"
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
                    <template v-slot:item.isActive="{ item }">
                        <div class="d-flex gap-2 align-center">
                            <Icon icon="carbon:dot-mark" v-if="item.isActive" class="text-success" />
                            <Icon icon="carbon:dot-mark" v-else class="text-error" />
                            {{ item.isActive ? $t('STATE_ACTIVE') : $t('STATE_INACTIVE') }}
                        </div>
                    </template>
                    <template v-slot:item.mandatory="{ item }">
                        <div class="d-flex gap-2 align-center">
                            <Icon icon="carbon:dot-mark" v-if="item.mandatory" class="text-success" />
                            <Icon icon="carbon:dot-mark" v-else class="text-error" />
                            {{ item.mandatory ? $t('STATE_ACTIVE') : $t('STATE_INACTIVE') }}
                        </div>
                    </template>
                    <template v-slot:top>
                        <v-toolbar class="bg-surface" flat>
                            <v-dialog v-model="dialog" max-width="800px">
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
                                <v-card>
                                    <v-card-title class="pa-4 !tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white">
                                        <span class="text-h5">{{ formTitle }}</span>
                                    </v-card-title>

                                      <div class="tw-grid tw-grid-cols-2 tw-w-full tw-gap-5 tw-px-10 tw-pt-10">
                                        <v-select
                                          color="primary"
                                          clearable
                                          :label="$t('ACTIVE_DEPENDENCIES')"
                                          v-model="dependencyId.value.value"
                                          :item-props="itemGenericProps"
                                          :items="dependencies"
                                          :item-value="'id'"
                                          :error-messages="dependencyId.errorMessage.value"
                                          :hint="$t('DEPENDENCY_FIELD_NOTICE')"
                                          persistent-hint
                                        ></v-select>
                                        <v-text-field clearable v-model="name.value.value" :label="$t('NAME_HEADER')" :error-messages="name.errorMessage.value"></v-text-field>
                                        <v-textarea
                                            class="!tw-w-full !tw-col-span-2"
                                            :label="$t('DESCRIPTION_FIELD')"
                                            row-height="30"
                                            color="primary"
                                            clearable
                                            rows="3"
                                            auto-grow
                                            v-model="description.value.value"
                                            :error-messages="description.errorMessage.value"
                                        ></v-textarea>
                                        <v-switch
                                          v-model="mandatory.value.value"
                                          :label="$t('MANDATORY_FIELD')"
                                          hide-details
                                          :error-messages="mandatory.errorMessage.value"
                                          color="primary"
                                          inset
                                        ></v-switch>
                                        <v-switch
                                          v-model="isActive.value.value"
                                          :label="$t('STATUS_FIELD')"
                                          hide-details
                                          :error-messages="isActive.errorMessage.value"
                                          color="primary"
                                          inset
                                        ></v-switch>
                                      </div>

                                    <v-card-actions class="pa-4">
                                        <v-btn color="error" variant="flat" dark @click="close"> {{ $t('CANCEL_FIELD') }} </v-btn>
                                        <v-btn color="success" :loading="loading" :disabled="loading" variant="flat" dark @click="handleStoreOrUpdateBudgetaryKeyDocumentType"> {{ $t('SAVE_FIELD') }} </v-btn>
                                    </v-card-actions>
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
                                        <v-btn color="success" variant="flat" dark @click="handleDeleteBudgetaryKeyDocumentType">{{ $t('CONFIRM_FIELD') }}</v-btn>
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
                                @click="editPosition(item)"
                            />
                            <Icon
                                icon="solar:trash-bin-minimalistic-linear"
                                height="20"
                                class="text-error cursor-pointer"
                                size="small"
                                @click="deletePosition(item)"
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

</template>