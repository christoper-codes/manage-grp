<script setup lang="ts">
import { addressStoreOrUpdateSchema } from '@/validation/address/storeOrUpdate';
import GetAddress from '@/components/maps/GetAddress.vue';
import { useField, useForm } from 'vee-validate';
import { useI18n } from 'vue-i18n';
import { defineEmits } from 'vue'


// emits
const emit = defineEmits(['storeOrUpdateDireccion'])



// props
const props = defineProps({
  dependencies: {
    type: Array,
    required: true,
  },
  loading : {
    type: Boolean,
    required: false
  },
  option : {
    type: Boolean,
    required: false
  },
  itemForEdit: {
    type: Object,
    requered: false
  }
});


// i18n translation
const { t } = useI18n();

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

if (props.itemForEdit) {
    console.log(props.itemForEdit)
    id.value.value = props.itemForEdit.id
    dependencyId.value.value = props.itemForEdit.dependencyId
    neighborhood.value.value = props.itemForEdit.neighborhood
    street.value.value = props.itemForEdit.street
    exteriorNumber.value.value = props.itemForEdit.exteriorNumber
    interiorNumber.value.value = props.itemForEdit.interiorNumber
    postalCode.value.value = props.itemForEdit.postalCode
    latitude.value.value = props.itemForEdit.latitude
    longitude.value.value = props.itemForEdit.longitude
    reference.value.value = props.itemForEdit.reference
    isActive.value.value = props.itemForEdit.isActive
}else{
    resetForm
}


// Watchers, lifecycle hooks, and async functions
const handleStoreOrUpdateAddress = handleStoreOrUpdateSubmit(async (values: Record<string, any>) => {
  emit('storeOrUpdateDireccion', 
  { dependencyId: dependencyId.value.value,
    neighborhood: neighborhood.value.value,
    street: street.value.value,
    exteriorNumber: exteriorNumber.value.value,
    interiorNumber: interiorNumber.value.value,
    postalCode: postalCode.value.value,
    latitude: latitude.value.value,
    longitude: longitude.value.value,
    reference: reference.value.value,
    isActive: isActive.value.value
  })
  resetForm();
});

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

defineExpose({ 
  handleStoreOrUpdateAddress
});

</script>


<template>

    <div class="tw-max-h-[80vh] tw-overflow-y-auto tw-p-5 tw-rounded-xl tw-bg-white">
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
              <v-switch
                :label="$t('STATUS_FIELD')"
                v-model="isActive.value.value"
                :error-messages="isActive.errorMessage.value"
                hide-details
                color="primary"
                inset
              ></v-switch>
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
          </div>
          <!--<div class="tw-flex tw-items-center tw-justify-end !tw-col-span-2">
              <v-btn @click="handleStoreOrUpdateAddress" color="success" variant="flat" size="large" :loading="loading" :disabled="loading" dark >{{ $t('ADD_NEW_ITEM_FIELD') }}</v-btn>
          </div>-->

          <h2>{{ $t('SELECT_ADDRESS_IN_THE_MAP') }}</h2>

          <div class="tw-mt-1">
            <GetAddress @update-form-by-map-emit="updateFormByMapEmit" />
          </div>
        </div>

</template>