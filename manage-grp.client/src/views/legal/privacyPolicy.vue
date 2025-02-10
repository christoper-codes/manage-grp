<script setup lang="ts">
import { useI18n } from 'vue-i18n';
import LanguageDD from '@/layouts/full/vertical-header/LanguageDD.vue';
import Logoiconimg from '@/assets/images/logos/logo.svg';


const { locale } = useI18n();
const preferredLanguage: string = locale.value == 'es' ? 'es-ES' : 'en-US';
const date: Date = new Date();

const formattedDate: string = new Intl.DateTimeFormat(preferredLanguage, {
  year: 'numeric',
  month: 'long',
  day: 'numeric'
}).format(date);
</script>

<template>
  <main class="tw-min-h-screen tw-flex tw-items-center tw-justify-center tw-py-16 tw-relative">
    <div class="bg-blur tw-bottom-0 tw-right-0 tw-opacity-90 tw-absolute tw-bg-primary tw-rounded-full tw-w-[150px] tw-h-[150px] tw-z-10 tw-backdrop-blur-lg"></div>
    <div class="tw-max-w-3xl tw-mx-auto">
      <div class="tw-flex tw-items-center tw-justify-between">
        <div class="tw-flex tw-items-center tw-gap-3">
          <RouterLink :to="{ name: 'login' }">
            <div class="tw-h-[38px] tw-w-[38px] tw-bg-gradient-to-r tw-from-primary tw-to-secondary tw-text-white tw-rounded-full tw-flex tw-items-center tw-justify-center tw-text-center">
              <Icon icon="mdi:arrow-left-bold" class="tw-text-xl !tw-w-1/2" />
            </div>
          </RouterLink>
          <LanguageDD />
        </div>
        <img :src="Logoiconimg" alt="brand logo" class="tw-w-28" />
      </div>
      <div class="tw-flex tw-flex-col tw-items-center tw-w-full tw-mt-3">
        <h2 class="tw-text-center tw-shadow-lg tw-font-bold tw-text-4xl tw-bg-gray-100 tw-p-5 tw-rounded-xl tw-block tw-w-full">{{ $t('PRIVACY_POLICY') }}</h2>
        <h4 class="tw-text-center  tw-mt-7 tw-shadow tw-bg-gray-100 tw-p-5 tw-rounded-xl tw-inline-block tw-mx-auto">{{ formattedDate }}</h4>
      </div>
      <div class="tw-mt-7 tw-leading-7">
        <div class="tw-font-medium  tw-opacity-90" v-html="$t('PRIVACY_POLICY_DESC')"></div>
      </div>
      <div class="tw-mt-16 tw-flex tw-items-center tw-justify-center">
        <img :src="Logoiconimg" alt="brand logo" class="tw-w-28 tw-mx-auto" />
      </div>
    </div>
  </main>
</template>

<style scoped>
  .bg-blur{
    filter: blur(90px);
  }
</style>
