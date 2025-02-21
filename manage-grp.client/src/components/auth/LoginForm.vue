<script setup lang="ts">
import { ref, type Ref } from 'vue';
import { Form, useField, useForm } from 'vee-validate';
import { loginSchema } from '@/validation/auth/login-schema';
import { useI18n } from 'vue-i18n';
import { useAuthStore } from '@/stores/auth/auth';

// i18n translation
const { t } = useI18n();

// Form validation
const { handleSubmit } = useForm({
  validationSchema: loginSchema(t),
  initialValues: {
    rememberMe: false,
  },
})
const userNameOrEmail = useField('userNameOrEmail');
const password = useField('password');
const rememberMe = useField('rememberMe');
const loading: Ref<boolean> = ref(false);
const show: Ref<boolean> = ref(false);
const authStore = useAuthStore();

const submit = handleSubmit((values: Record<string, any>) => {
    authStore.login(values, loading, t);
});
</script>

<template>
    <div class="d-flex align-center text-center mb-6">
        <div class="text-h6 w-100 px-5 font-weight-regular auth-divider position-relative">
            <span class="bg-surface px-3 py-3 position-relative">
              <span class="tw-inline-block tw-h-5 tw-w-5 tw-border-2 tw-rounded-full tw-bg-white"></span>
            </span>
        </div>
    </div>
    <Form class="mt-5">
        <v-label class="font-weight-semibold pb-2 ">{{ $t('EMAIL_FIELD') }}</v-label>
        <VTextField
            v-model="userNameOrEmail.value.value"
            :error-messages="userNameOrEmail.errorMessage.value"
            class="mb-8"
            required
            hide-details="auto"
        ></VTextField>
        <v-label class="font-weight-semibold pb-2 ">{{ $t('PASSWORD_FIELD') }}</v-label>
        <VTextField
            v-model="password.value.value"
            :error-messages="password.errorMessage.value"
            :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
            :type="show ? 'text' : 'password'"
            @click:append="show = !show"
            counter
            required
            hide-details="auto"
            class="pwdInput"
        ></VTextField>
        <div class="d-flex flex-wrap align-center my-3 ml-n2">
            <v-checkbox class="pe-2" v-model="rememberMe.value.value" hide-details color="primary">
                <template v-slot:label>{{ $t('REMEMBER_ME_FIELD') }}</template>
            </v-checkbox>
            <div class="ml-sm-auto">
                <RouterLink :to="{name: 'forgot-password'}" class="text-primary text-decoration-none font-weight-medium">{{ $t('FORGOT_PASSWORD') }}</RouterLink>
            </div>
        </div>
        <v-btn @click="submit" :loading="loading" :disabled="loading" size="large" block type="submit"  class="!tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white">
            <Icon icon="mdi:account" class="tw-text-xl !tw-w-1/2 tw-mr-1" /> {{ $t('SIGNIN_FIELD') }}
        </v-btn>
    </Form>
</template>
