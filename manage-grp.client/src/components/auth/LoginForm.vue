<script setup lang="ts">
import { ref } from 'vue';
import { useAuthStore } from '@/stores/auth';
import { Form } from 'vee-validate';
import { useI18n } from 'vue-i18n';
import { toast } from 'vue3-toastify'

const { t } = useI18n();
/*Social icons*/
import google from '@/assets/images/svgs/google-icon.svg';
import facebook from '@/assets/images/svgs/facebook-icon.svg';
const show = ref(false);

const checkbox = ref(false);
const valid = ref(false);
const show1 = ref(false);
const password = ref('admin123');
const username = ref('info@wrappixel.com');
const passwordRules = ref([
    (v: string) => !!v || t('REQUIRED'),
    (v: string) => (v && v.length >= 8) || t('FIELD_LESS_THAN', { count: 8 })
]);
const emailRules = ref([(v: string) => !!v || t('REQUIRED'), (v: string) => /.+@.+\..+/.test(v) || t('INVALID_EMAIL')]);

function validate(values: any) {
    const authStore = useAuthStore();
    return authStore.login(username.value, password.value).catch((error) => {
      toast(t(error), {
          "theme": "auto",
          "type": "error",
          "dangerouslyHTMLString": true
      });
    });
}
</script>

<template>
    <div class="d-flex align-center text-center mb-6">
        <div class="text-h6 w-100 px-5 font-weight-regular auth-divider position-relative">
            <span class="bg-surface px-3 py-3 position-relative">
              <span class="tw-inline-block tw-h-5 tw-w-5 tw-border-2 tw-rounded-full tw-bg-white"></span>
            </span>
        </div>
    </div>
    <Form @submit="validate" v-slot="{ errors, isSubmitting }" class="mt-5">
        <v-label class="font-weight-semibold pb-2 ">{{ $t('USER_NAME_FIELD') }}</v-label>
        <VTextField
            v-model="username"
            :rules="emailRules"
            class="mb-8"
            required
            hide-details="auto"
        ></VTextField>
        <v-label class="font-weight-semibold pb-2 ">{{ $t('PASSWORD_FIELD') }}</v-label>
        <VTextField
            v-model="password"
            :rules="passwordRules"
            :append-icon="show ? 'mdi-eye' : 'mdi-eye-off'"
            :type="show ? 'text' : 'password'"
            @click:append="show = !show"
            counter
            required
            hide-details="auto"
            class="pwdInput"
        ></VTextField>
        <div class="d-flex flex-wrap align-center my-3 ml-n2">
            <v-checkbox class="pe-2" v-model="checkbox" hide-details color="primary">
                <template v-slot:label class="font-weight-medium">{{ $t('REMEMBER_ME_FIELD') }}</template>
            </v-checkbox>
            <div class="ml-sm-auto">
                <RouterLink to="" class="text-primary text-decoration-none font-weight-medium"
                    >{{ $t('FORGOT_PASSWORD') }}</RouterLink
                >
            </div>
        </div>
        <v-btn size="large" :loading="isSubmitting" class="!tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white" :disabled="valid" block type="submit" flat>{{ $t('SIGNIN_FIELD') }}</v-btn>
    </Form>
</template>
