<script setup lang="ts">
import { onMounted, ref, type Ref } from 'vue';
import { Form, useField, useForm } from 'vee-validate';
import { signUpSchema } from '@/validation/auth/sign-up-schema';
import { useI18n } from 'vue-i18n';
import { useAuthStore } from '@/stores/auth/auth';
import { useStatesStore } from '@/stores/app/states';


// i18n translation
const { t } = useI18n();


//Stores
const statesStore = useStatesStore();

//DATA
let states = ref<any>([]);

// OnMounted
onMounted(async () => {
  states.value = await statesStore.index(loading, t);
  console.log(states.value)
});

// Form validation
const { handleSubmit } = useForm({
  validationSchema: signUpSchema(t),
})
const email = useField('email');
const userName = useField('userName');
const name = useField('name');
const lastName = useField('lastName');
const phoneNumber = useField('phoneNumber');
const password = useField('password');
const state  = useField<any>('state');
const confirmPassword = useField('confirmPassword');
const loading: Ref<boolean> = ref(false);
const show: Ref<boolean> = ref(false);
const confirmShow: Ref<boolean> = ref(false);
const authStore = useAuthStore();

const submit = handleSubmit((values: Record<string, any>) => {
    authStore.signUp(
    {
        "userName": values.userName,
        "firstName": splitIntoTwo(values.name).firstPart,
        "middleName": splitIntoTwo(values.name).secondPart,
        "paternalLastName": splitIntoTwo(values.lastName).firstPart,
        "maternalLastName": splitIntoTwo(values.lastName).secondPart,
        "email": values.email,
        "password": values.password,
        "phoneNumber": values.phoneNumber,
        "stateId": values.state
    },
    loading, 
    t);
});


const splitIntoTwo = (text: string): { firstPart: string; secondPart: string } => {
  const [first, ...rest] = text.trim().split(/\s+/); 
  return {
    firstPart: first || "",  
    secondPart: rest.join(" ") || "", 
  };
};


</script>

<template>
    <Form class="mt-5">
        <div>
        <v-row>
            <v-col >
                <v-label class="font-weight-semibold pb-0 ">{{ $t('USER_NAME_FIELD') }}</v-label>
                <VTextField
                    v-model="userName.value.value"
                    :error-messages="userName.errorMessage.value"
                    required
                    hide-details="auto"
                ></VTextField>
            </v-col>
        </v-row>
        <v-row>
            <v-col cols="6">
                <v-label class="font-weight-semibold pb-0 ">{{ $t('NAME_(S)_FIELD') }}</v-label>
                <VTextField
                    v-model="name.value.value"
                    :error-messages="name.errorMessage.value"
                    required
                    hide-details="auto"
                ></VTextField>
            </v-col>
            <v-col cols="6">
                <v-label class="font-weight-semibold pb-0 ">{{ $t('LAST_NAME_FIELD') }}</v-label>
                <VTextField
                    v-model="lastName.value.value"
                    :error-messages="lastName.errorMessage.value"
                    required
                    hide-details="auto"
                ></VTextField>
            </v-col>
        </v-row>
        <v-row>
            <v-col>
                <v-label class="font-weight-semibold pb-0 ">{{ $t('STATE_FIELD') }}</v-label>
                <v-select
                    v-model="state.value.value"
                    :error-messages="state.errorMessage.value"
                    item-title="name"
                    item-value="id"
                    required
                    hide-details="auto"
                    label="Selecciona"
                    :items="states"
                ></v-select>
            </v-col>
        </v-row>
        <v-row>
            <v-col cols="6">
                <v-label class="font-weight-semibold pb-0 ">{{ $t('EMAIL_FIELD') }}</v-label>
                <VTextField
                    v-model="email.value.value"
                    :error-messages="email.errorMessage.value"
                    required
                    hide-details="auto"
                ></VTextField>
            </v-col>
            <v-col cols="6">
                <v-label class="font-weight-semibold pb-0 ">{{ $t('PHONE_FIELD') }}</v-label>
                <VTextField
                    v-model="phoneNumber.value.value"
                    :error-messages="phoneNumber.errorMessage.value"
                    required
                    hide-details="auto"
                ></VTextField>
            </v-col>
        </v-row>
        <v-row>
            <v-col cols="6">
                <v-label class="font-weight-semibold pb-0">{{ $t('PASSWORD_FIELD') }}</v-label>
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
            </v-col>
            <v-col cols="6">
                <v-label class="font-weight-semibold tw-pb-0 ">{{ $t('CONFIRMATION_PASSWORD_FIELD') }}</v-label>
                <VTextField
                    v-model="confirmPassword.value.value"
                    :error-messages="confirmPassword.errorMessage.value"
                    :append-icon="confirmShow ? 'mdi-eye' : 'mdi-eye-off'"
                    :type="confirmShow ? 'text' : 'password'"
                    @click:append="confirmShow = !confirmShow"
                    counter
                    required
                    hide-details="auto"
                    class="pwdInput"
                ></VTextField>
            </v-col>
        </v-row>
        </div>
        
        <v-btn @click="submit" :loading="loading" :disabled="loading" size="large" block type="submit"  class="!tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white tw-my-5">
            <Icon icon="mdi:account" class="tw-text-xl !tw-w-1/2 tw-mr-1" /> {{ $t('CREATE_ACCOUNT') }}
        </v-btn>
        <div class="ml-sm-auto tw-text-center">
            <RouterLink :to="{name: 'login'}" class="text-primary text-decoration-none font-weight-medium">{{ $t('SIGNIN_FIELD') }}</RouterLink>
        </div>
    </Form>
</template>
