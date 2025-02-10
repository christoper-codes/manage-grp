<script setup lang="ts">
import LogoIcon from '@/layouts/full/logo/LogoIcon.vue';
import LoginForm from '@/components/auth/LoginForm.vue';
import brandAuthForgotPassword from '@/assets/images/auth/brand-auth-forgot-password.jpeg';
import LanguageDD from '@/layouts/full/vertical-header/LanguageDD.vue';
import ResetPassword from '@/components/auth/ResetForm.vue';
</script>

<template>
  <div class="pa-3 h-100vh mh-100">
      <v-row class="h-100vh">
          <v-col cols="12" lg="5" xl="4" class="bg-surface auth">
              <div data-aos="fade-left" data-aos-duration="2000" class="d-flex justify-center align-center h-100">
                  <div class="mt-xl-0 mt-5 auth-card">
                      <div class="tw-flex tw-justify-between tw-items-center">
                        <LogoIcon class="tw-w-12"/>
                        <LanguageDD />
                      </div>
                      <h2 class="text-h3 my-3 heading">{{ $t('BRAND_NAME') }}</h2>
                      <div class="mb-6">{{ $t('RECOVER_PASSWORD_FIELD') }}</div>
                      <ResetPassword />
                      <v-btn size="large" color="lightprimary" :to="{name: 'login'}" block class="mt-5 text-primary" flat>{{ $t('SIGNIN_FIELD') }}</v-btn>
                      <p class="d-flex align-center justify-center textSecondary mt-6 font-weight-medium">
                          {{ $t('PRIVACY_POLICY') }}
                          <RouterLink
                              class="pl-0 text-primary opacity-1 pl-2 font-weight-medium text-decoration-none"
                              height="auto"
                              :to="{name: 'policy-privacy'}"
                              variant="plain"
                              >{{ $t('LEARN_MORE_FIELD') }}</RouterLink
                          >
                      </p>
                  </div>
              </div>
          </v-col>
          <v-col class="tw-relative tw-hidden !tw-p-14 xl:tw-flex tw-items-center tw-justify-center tw-w-full tw-min-h-60 tw-bg-center tw-bg-cover" :style="{ backgroundImage: `url(${brandAuthForgotPassword})` }">
            <div class="tw-absolute tw-inset-0 tw-bg-black tw-opacity-20"></div>
            <div data-aos="fade-left" data-aos-duration="2000" class="tw-mx-auto tw-w-full tw-h-full tw-p-16 tw-gap-7 tw-flex tw-justify-center tw-flex-col tw-text-white tw-z-10 tw-bg-black/10 tw-backdrop-blur-md tw-rounded-3xl">
              <div class="tw-flex tw-flex-col tw-gap-6">
                    <h2 class="tw-text-lg lg:tw-text-3xl">{{ $t('RECOVER_PASSWORD_FIELD') }}</h2>
                    <p class="tw-text-md">{{ $t('FORGOT_PASSWORD_DESC') }}</p>
                    <v-btn :to="{name: 'policy-privacy'}" class="!tw-bg-gradient-to-r !tw-from-primary !tw-to-secondary !tw-text-white tw-w-1/5">
                      {{ $t('LEARN_MORE_FIELD') }}
                    </v-btn>
              </div>
            </div>
        </v-col>

      </v-row>
  </div>
</template>

