<script setup lang="ts">
import { ref } from 'vue';
import Warning from '@/components/alerts/Warning.vue';
import AddressForm from '../forms/AddressForm.vue';
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


// data
const dialog = ref(false);
const loading = ref(false);
const isAddressStore = ref(true);




// Watchers, lifecycle hooks, and async functions
const addAddress = async (address: any) => {
  console.log(address);
  await addressStore.storeOrUpdateAddress(address, loading, t, isAddressStore.value)
  dialog.value = false;
};

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
          <AddressForm :dependencies="dependencies" :loading="loading" @storeOrUpdateDireccion="addAddress"/>
        </div>
        </v-card>
    </v-dialog>
  </div>
</template>
