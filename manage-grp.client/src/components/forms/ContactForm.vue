<script setup lang="ts">
import { useField, useForm } from 'vee-validate';
import { contactStoreOrUpdateSchema } from '@/validation/contacts/storeOrUpdate';
import { useI18n } from 'vue-i18n';
import { computed, onMounted, ref, type Ref, watch } from 'vue';
import { useAreasStore } from '@/stores/app/areas';
import { usePositionsStore } from '@/stores/app/positions';


// emits
const emit = defineEmits(['storeOrUpdateContact'])


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

//DATA
const areas: Ref<any[]> = ref([]);
const positions: Ref<any[]> = ref([]);

// Form for storing dependencies
const { handleSubmit: handleStoreOrUpdateSubmit, resetForm } = useForm({
  validationSchema: contactStoreOrUpdateSchema(t),
  initialValues: {
    isActive: true,
  },
});
const id = useField('id');
const dependencyId = useField('dependencyId');
const areaId = useField('areaId');
const positionId = useField('positionId');
const firstName = useField('firstName');
const middleName = useField('middleName');
const paternalLastName = useField('paternalLastName');
const maternalLastName = useField('maternalLastName');
const email = useField('email');
const phone = useField('phone');
const isActive = useField('isActive');
//stores
const areasStore = useAreasStore();
const positionsStore = usePositionsStore();

const getAreasAndPositionsEdit = async (id: any) => {
    areas.value = await areasStore.areasByDependency(id, props.loading.valueOf, t),
    positions.value = await positionsStore.positionsByDependency(id, props.loading.valueOf, t)
}

if (props.itemForEdit) {
    console.log(props.itemForEdit)
    id.value.value = props.itemForEdit.id
    dependencyId.value.value = props.itemForEdit.dependencyId
    getAreasAndPositionsEdit(dependencyId.value.value);
    areaId.value.value = props.itemForEdit.areaId
    positionId.value.value =  props.itemForEdit.positionId
    firstName.value.value = props.itemForEdit.firstName
    middleName.value.value = props.itemForEdit.middleName
    paternalLastName.value.value = props.itemForEdit.paternalLastName
    maternalLastName.value.value = props.itemForEdit.maternalLastName
    email.value.value = props.itemForEdit.email
    phone.value.value = props.itemForEdit.phone
    isActive.value.value = props.itemForEdit.isActive
}else{
    resetForm
}





//Arrow functions
const itemGenericProps = (item: any) => {
  return {
    title: item.name,
    subtitle: item.abbreviation,
  };
};





// Watchers, lifecycle hooks, and async functions
watch(dependencyId.value, async (val) => {
  if (val) {
    const [areasData, positionsData] = await Promise.all([
        areasStore.areasByDependency(val, props.loading.valueOf, t),
        positionsStore.positionsByDependency(val, props.loading.valueOf, t)
    ]);
    areas.value = areasData;
    positions.value = positionsData;
  }
});

//



const handleStoreOrUpdateContact = handleStoreOrUpdateSubmit(() => {

    emit('storeOrUpdateContact', {
        id: id.value.value,
        dependencyId: dependencyId.value.value,
        areaId: areaId.value.value,
        positionId: positionId.value.value,
        firstName: firstName.value.value,
        middleName: middleName.value.value,
        paternalLastName: paternalLastName.value.value,
        maternalLastName: maternalLastName.value.value,
        email: email.value.value,
        phone: phone.value.value,
        isActive: isActive.value.value
    })

    resetForm

})

defineExpose({ 
  handleStoreOrUpdateContact
});


</script>
<template>
    <div class="tw-grid tw-grid-cols-2 tw-w-full  tw-gap-5 tw-px-10">
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

        <v-select 
            color="primary" 
            clearable:label="$t('ACTIVE_AREAS_FIELD')" 
            v-model="areaId.value.value"
            :items="areas" 
            :item-props="itemGenericProps" 
            :item-value="'id'" 
            :error-messages="areaId.errorMessage.value" 
            persistent-hint >
        </v-select>

        <v-select
            color="primary"
            clearable
            :label="$t('ACTIVE_POSITIONS_FIELD')"
            v-model="positionId.value.value"
            :items="positions"
            :item-props="itemGenericProps"
            :item-value="'id'"
            :error-messages="positionId.errorMessage.value"
            persistent-hint
        ></v-select>

        <v-text-field clearable v-model="firstName.value.value" :label="$t('FIRST_NAME_FIELD')" :error-messages="firstName.errorMessage.value"></v-text-field>
        <v-text-field clearable v-model="middleName.value.value" :label="$t('MIDDLE_NAME_FIELD')" :error-messages="middleName.errorMessage.value"></v-text-field>
        <v-text-field clearable v-model="paternalLastName.value.value" :label="$t('PATERNAL_LAST_NAME_FIELD')" :error-messages="paternalLastName.errorMessage.value"></v-text-field>
        <v-text-field clearable v-model="maternalLastName.value.value" :label="$t('MATERNAL_LAST_NAME_FIELD')" :error-messages="maternalLastName.errorMessage.value"></v-text-field>
        <v-text-field clearable v-model="email.value.value" :label="$t('EMAIL_FIELD')" :error-messages="email.errorMessage.value"></v-text-field>
        <v-text-field clearable v-model="phone.value.value" :label="$t('PHONE_FIELD')" :error-messages="phone.errorMessage.value"></v-text-field>

        <v-switch
            v-model="isActive.value.value" 
            :label="$t('STATUS_FIELD')" 
            hide-details 
            :error-messages="isActive.errorMessage.value"   
            color="primary" 
            inset >
        </v-switch>
    </div>
</template>