<script setup lang="ts">
import { computed, nextTick, onMounted, ref, type Ref, watch } from 'vue';
import BaseBreadcrumb from '@/components/shared/BaseBreadcrumb.vue';
import FormModal from '@/components/maps/FormModal.vue';
import DataAddressImg from '@/assets/images/data/data-address-img.png';
import { useI18n } from 'vue-i18n';
import { useStatesStore } from '@/stores/app/states';
import { useMunicipalitiesStore } from '@/stores/app/municipalities';
import { useDependenciesStore } from '@/stores/app/dependencies';
import { dependencySearchSchema } from '@/validation/dependencies/search';
import { useField, useForm } from 'vee-validate';
import Warning from '@/components/alerts/Warning.vue';

// i18n translation
const { t } = useI18n();

// Stores
const statesStore = useStatesStore();
const municipalitiesStore = useMunicipalitiesStore();
const dependenciesStore = useDependenciesStore();

// Form for searching dependencies
const { handleSubmit: handleSearchSubmit } = useForm({ validationSchema: dependencySearchSchema(t) });
const searchStateSelected = useField('searchStateSelected');
const searchMunicipalitySelected = useField('searchMunicipalitySelected');

// Data
const dependencies: Ref<any[] | null> = ref(null);
const states: Ref<any[]> = ref([]);
const municipalities: Ref<any[]> = ref([]);
const loading: Ref<boolean> = ref(false);

// Arrow functions
const itemGenericProps = (item: any) => {
  return {
    title: item.name,
    subtitle: item.abbreviation,
  };
};

// Watchers, lifecycle hooks, and async functions
const handleSearchDependencies = handleSearchSubmit(async (values: Record<string, any>) => {
  await indexDependencies(values.searchMunicipalitySelected.id);
});

const indexDependencies = async (id:number) => {
  dependencies.value = await dependenciesStore.dependenciesByMunicipality(id, loading, t);
};

onMounted(async () => {
  states.value = await statesStore.index(loading, t);
});

watch(searchStateSelected.value, async (val) => {
  if (val) {
    municipalities.value = await municipalitiesStore.index(val.id, loading, t);
  }
});
</script>

<template>
    <div data-aos="fade-left" data-aos-duration="1500">
      <BaseBreadcrumb title="ADDRESSES"></BaseBreadcrumb>

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
          <v-btn @click="handleSearchDependencies" :loading="loading" :disabled="loading" class="!tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white !tw-mb-6" variant="flat" size="large" dark>{{ $t('SEARCH_FIELD') + ' ' + $t('DEPENDENCIES') }}</v-btn>
      </div>

    <v-row>
        <v-col cols="12">
            <v-card elevation="10">
              <div class="tw-w-full tw-p-6">
                <Warning alert="DEPENDENCY_ADDRESS_ITEM_NOTICE" />
                <div class="tw-mt-10 tw-flex tw-items-center tw-justify-center tw-flex-col tw-gap-5">
                  <img class="tw-w-28 tw-h-auto" :src="DataAddressImg" alt="">
                  <Transition name="slide-fade">
                      <div v-if="dependencies && dependencies.length > 0">
                        <FormModal v-bind:dependencies="dependencies" />
                      </div>
                      <div v-else-if="dependencies && dependencies.length === 0">
                        <Warning alert="NO_DEPENDENCIES_FOUND_NOTICE" />
                      </div>
                  </Transition>
                </div>
              </div>
            </v-card>
        </v-col>
    </v-row>
    </div>
</template>

<style scoped>
.slide-fade-enter-active {
  transition: all 0.3s ease-out;
}

.slide-fade-leave-active {
  transition: all 0.8s cubic-bezier(1, 0.5, 0.8, 1);
}

.slide-fade-enter-from,
.slide-fade-leave-to {
  transform: translateX(20px);
  opacity: 0;
}
</style>
