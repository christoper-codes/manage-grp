<script setup lang="ts">
import GetAddress from '@/components/maps/GetAddress.vue';
import { ref } from 'vue';
import Warning from '@/components/alerts/Warning.vue';
import { useI18n } from 'vue-i18n';
import { addressStoreOrUpdateSchema } from '@/validation/address/storeOrUpdate';
import { useField, useForm } from 'vee-validate';
import { useAddressStore } from '@/stores/app/address';
// props
const props = defineProps({
  dependencies: {
    type: Array,
    required: true,
  },
});

// i18n translation
const { t } = useI18n();

// stores

const addressStore = useAddressStore();

// Form for storing address
const { handleSubmit: handleStoreOrUpdateSubmit, resetForm } = useForm({
  validationSchema: addressStoreOrUpdateSchema(t),
  initialValues: {
    isActive: true,
  },
});
const id = useField('id');
const dependencyId = useField('dependencyId');
const neighborhood = useField('neighborhood');
const street = useField('street');
const exteriorNumber = useField('exteriorNumber');
const interiorNumber = useField('interiorNumber');
const postalCode = useField('postalCode');
const latitude = useField('latitude');
const longitude = useField('longitude');
const reference = useField('reference');
const isActive = useField('isActive');

// data
const dialog = ref(false);
const loading = ref(false);
const isAddressStore = ref(true);

// Arrow functions
const itemGenericProps = (item: any) => {
  return {
    title: item.name,
    subtitle: item.abbreviation,
  };
};

const updateFormByMapEmit = (neighborhoodEmit: string, streetEmit: string, postalCodeEmit: string, latitudeEmit: number, longitudeEmit: number, referenceEmit: string) => {
  neighborhood.value.value = neighborhoodEmit;
  street.value.value = streetEmit;
  postalCode.value.value = postalCodeEmit;
  latitude.value.value = latitudeEmit;
  longitude.value.value = longitudeEmit;
  reference.value.value = referenceEmit;
};

// Watchers, lifecycle hooks, and async functions
const handleStoreOrUpdateAddress = handleStoreOrUpdateSubmit(async (values: Record<string, any>) => {
  await addressStore.storeOrUpdateAddress(values, loading, t, isAddressStore.value)
  resetForm();
  dialog.value = false;
});
</script>
<template>
  <div>
    <v-dialog
        v-model="dialog"
        transition="dialog-bottom-transition"
        fullscreen
    >
        <template v-slot:activator="{ props: activatorProps }">
            <v-btn v-bind="activatorProps" variant="elevated" color="third" size="large">{{ $t('ADD') + ' ' + $t('ADDRESS_FIELD') }}</v-btn>
        </template>

        <v-card>
        <v-toolbar class="!tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white">
            <v-btn class="!tw-text-white" icon="mdi-close" @click="dialog = false" ></v-btn>
            <v-toolbar-title>
                <div class="tw-font-bold tw-text-white tw-text-xs lg:tw-text-base">{{ $t('ADDRESSES') }}</div>
            </v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items>
            <v-btn color="white" :text="$t('ACCEPT_FIELD')" variant="tonal" @click="dialog = false"></v-btn>
            </v-toolbar-items>
        </v-toolbar>

        <div class="tw-w-full tw-max-w-[90%] tw-mx-auto tw-py-10">
          <div class="tw-mb-10">
            <Warning alert="ADDRESS_ITEM_NOTICE" />
          </div>
          <div class="tw-grid tw-grid-cols-3 tw-w-full tw-gap-5">
              <v-select
                color="primary"
                clearable
                :label="$t('ACTIVE_DEPENDENCIES')"
                v-model="dependencyId.value.value"
                :item-props="itemGenericProps"
                :item-value="'id'"
                :hint="$t('DEPENDENCY_FIELD_NOTICE')"
                persistent-hint
                :items="dependencies"
                :error-messages="dependencyId.errorMessage.value"
              ></v-select>
              <v-text-field clearable v-model="neighborhood.value.value" :label="$t('NEIGHBORHOOD_FIELD')" :error-messages="neighborhood.errorMessage.value"></v-text-field>
              <v-text-field clearable v-model="street.value.value" :label="$t('STREET_FIELD')" :error-messages="street.errorMessage.value"></v-text-field>
              <v-text-field clearable v-model="exteriorNumber.value.value" :label="$t('EXTERIOR_NUMBER_FIELD')" :error-messages="exteriorNumber.errorMessage.value"></v-text-field>
              <v-text-field clearable v-model="interiorNumber.value.value" :label="$t('INTERIOR_NUMBER_FIELD')" :error-messages="interiorNumber.errorMessage.value"></v-text-field>
              <v-text-field clearable v-model="postalCode.value.value" :label="$t('POSTAL_CODE_FIELD')" :error-messages="postalCode.errorMessage.value"></v-text-field>
              <v-text-field clearable v-model="latitude.value.value" :label="$t('LATITUDE_FIELD')" :error-messages="latitude.errorMessage.value"></v-text-field>
              <v-text-field clearable v-model="longitude.value.value" :label="$t('LONGITUDE_FIELD')" :error-messages="longitude.errorMessage.value"></v-text-field>
              <v-textarea
                  class="!tw-w-full !tw-col-span-3"
                  :label="$t('REFERENCE_FIELD')"
                  row-height="30"
                  v-model="reference.value.value"
                  :error-messages="reference.errorMessage.value"
                  color="primary"
                  clearable
                  rows="3"
                  auto-grow
              ></v-textarea>
              <v-switch
                :label="$t('STATUS_FIELD')"
                v-model="isActive.value.value"
                :error-messages="isActive.errorMessage.value"
                hide-details
                color="primary"
                inset
              ></v-switch>
              <div class="tw-flex tw-items-center tw-justify-end !tw-col-span-2">
                <v-btn @click="handleStoreOrUpdateAddress" color="success" variant="flat" size="large" :loading="loading" :disabled="loading" dark >{{ $t('ADD_NEW_ITEM_FIELD') }}</v-btn>
              </div>
          </div>

          <div class="tw-mt-10">
            <GetAddress @update-form-by-map-emit="updateFormByMapEmit" />
          </div>
        </div>
        </v-card>
    </v-dialog>
  </div>
</template>
