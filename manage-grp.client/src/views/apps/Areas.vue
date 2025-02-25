<script setup lang="ts">
import { computed, onMounted, ref, type Ref, watch } from 'vue';
import BaseBreadcrumb from '@/components/shared/BaseBreadcrumb.vue';
import dataTableImg from '@/assets/images/data/data-table-img.png';
import dataCircleImg from '@/assets/images/data/data-circle-img.jpeg';
import { Icon } from '@iconify/vue';
import { useI18n } from 'vue-i18n';
import { useStatesStore } from '@/stores/app/states';
import { useMunicipalitiesStore } from '@/stores/app/municipalities';
import { useDependenciesStore } from '@/stores/app/dependencies';
import { areaSearchSchema } from '@/validation/areas/search';
import { areaStoreOrUpdateSchema } from '@/validation/areas/storeOrUpdate';
import { useField, useForm } from 'vee-validate';
import { useAreasStore } from '@/stores/app/areas';
import { useDateFormat } from '@/composables/dateFormat';

// i18n translation
const { t } = useI18n();

// Composables
const { dateFormat } = useDateFormat();

// Stores
const statesStore = useStatesStore();
const municipalitiesStore = useMunicipalitiesStore();
const dependenciesStore = useDependenciesStore();
const areasStore = useAreasStore();

// Form for searching areas
const { handleSubmit: handleSearchSubmit } = useForm({ validationSchema: areaSearchSchema(t) });
const searchStateSelected = useField('searchStateSelected');
const searchMunicipalitySelected = useField('searchMunicipalitySelected');
const searchDependencySelected = useField('searchDependencySelected');

// Form for storing areas
const { handleSubmit: handleStoreOrUpdateSubmit, resetForm } = useForm({
  validationSchema: areaStoreOrUpdateSchema(t),
  initialValues: {
    isActive: true,
  },
});
const id = useField('id');
const dependencyId = useField('dependencyId');
const name = useField('name');
const acronym = useField('acronym');
const description = useField('description');
const isActive = useField('isActive');

// Header for the table
const headers = ref([
    { title: t('ITEM_IMAGE_HEADER'), key: 'ITEM_IMAGE_HEADER' },
    { title: t('DEPENDENCY_HEADER') + ' ID', key: 'dependencyId' },
    { title: t('ACRONYM_HEADER'), key: 'acronym' },
    { title: t('NAME_HEADER'), key: 'name' },
    { title: t('DESCRIPTION_HEADER'), key: 'description' },
    { title: t('STATUS_HEADER'), key: 'isActive' },
    { title: t('CREATED_AT_HEADER'), key: 'createdAt' },
    { title: t('ACTIONS_HEADER'), key: 'actions', sortable: false }
]);

// Data
const dependencies: Ref<any[]> = ref([]);
const isAreaStore = ref(true);
const states: Ref<any[]> = ref([]);
const municipalities: Ref<any[]> = ref([]);
const areas: Ref<any[]> = ref([]);
const loading: Ref<boolean> = ref(false);
const search = ref();
const area: Ref<object> = ref({});
const dialog = ref(false);
const dialogDelete = ref(false);

// Arrow functions
const formTitle = computed(() => {
    return isAreaStore.value ? t('ADD_NEW_ITEM_FIELD') : t('UPDATE_ITEM_FIELD');
});

const storeArea = () => {
  resetForm();
  isAreaStore.value = true;
}

const editArea = (item: any) => {
    isAreaStore.value = false;
    id.value.value = item.id;
    dependencyId.value.value = item.dependencyId;
    name.value.value = item.name;
    acronym.value.value = item.acronym;
    description.value.value = item.description;
    dialog.value = true;
};

const deleteArea = (item: object) => {
  dialogDelete.value = true;
  area.value = item;
}

const close = () => {
    dialog.value = false;
    dialogDelete.value = false;
    isAreaStore.value = true;
    resetForm();
};

const itemGenericProps = (item: any) => {
  return {
    title: item.name,
    subtitle: item.abbreviation,
  };
};

// Watchers, lifecycle hooks, and async functions
const handleSearchAreas = handleSearchSubmit(async (values: Record<string, any>) => {
  await indexAreas(values.searchDependencySelected.id);
});

const indexAreas = async (id:number) => {
  areas.value = await areasStore.areasByDependency(id, loading, t);
};

const handleStoreOrUpdateArea = handleStoreOrUpdateSubmit(async (values: Record<string, any>) => {
  await areasStore.storeOrUpdateArea(values, loading, t, isAreaStore.value);
  await indexAreas(values.dependencyId);
  close();
});

const handleDeleteArea = async () => {
  await areasStore.deleteArea(area.value.id, loading, t);
  await indexAreas(area.value.dependencyId);
  area.value = {};
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
</script>

<template>
    <div data-aos="fade-left" data-aos-duration="1500">
      <BaseBreadcrumb title="AREAS"></BaseBreadcrumb>
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
          <v-btn @click="handleSearchAreas" :loading="loading" :disabled="loading" class="!tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white !tw-mb-6" variant="flat" size="large" dark>{{ $t('SEARCH_FIELD') + ' ' + $t('AREAS') }}</v-btn>
      </div>

    <v-row>
        <v-col cols="12">
            <v-card elevation="10">
                <v-data-table
                    class=" rounded-md datatabels productlist"
                    :headers="headers"
                    :items="areas"
                    v-model:search="search"
                    items-per-page="5"
                    item-value="name"
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
                                <h6 class="text-h6">{{ item.name }}</h6>
                                <p class="textSecondary">{{ item.acronym }}</p>
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
                                        <v-btn color="success" variant="flat" size="large" dark v-bind="props" @click="storeArea" >{{ $t('ADD_NEW_ITEM_FIELD') }}</v-btn>
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
                                        <v-text-field clearable v-model="acronym.value.value" :label="$t('ACRONYM_FIELD')" :error-messages="acronym.errorMessage.value"></v-text-field>
                                        <v-text-field clearable v-model="name.value.value" :label="$t('NAME_FIELD')" :error-messages="name.errorMessage.value" class="!tw-w-full !tw-col-span-2"></v-text-field>
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
                                        <v-btn color="success" :loading="loading" :disabled="loading" variant="flat" dark @click="handleStoreOrUpdateArea"> {{ $t('SAVE_FIELD') }} </v-btn>
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
                                        <v-btn color="success" variant="flat" dark @click="handleDeleteArea">{{ $t('CONFIRM_FIELD') }}</v-btn>
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
                                @click="editArea(item)"
                            />
                            <Icon
                                icon="solar:trash-bin-minimalistic-linear"
                                height="20"
                                class="text-error cursor-pointer"
                                size="small"
                                @click="deleteArea(item)"
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
