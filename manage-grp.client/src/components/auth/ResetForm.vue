<script setup lang="ts">
import { ref } from 'vue';
const valid = ref(true);
const email = ref('');
const emailRules = ref([(v: string) => !!v || 'E-mail is required', (v: string) => /.+@.+\..+/.test(v) || 'E-mail must be valid']);
</script>
<template>
    <v-form ref="form" v-model="valid" lazy-validation action="/dashboards/analytical" class="mt-6">
        <v-label class="font-weight-semibold pb-2">{{ $t('EMAIL_FIELD') }}</v-label>
        <VTextField v-model="email" :rules="emailRules" required ></VTextField>
        <v-btn size="large" block type="submit"  class="!tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white">
            <Icon icon="mdi:email-outline" class="tw-text-xl !tw-w-1/2 tw-mr-1" /> {{ $t('RECOVER_PASSWORD_FIELD') }}
        </v-btn>
    </v-form>
</template>
