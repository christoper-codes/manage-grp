import { createApp } from 'vue';
import { createPinia } from 'pinia';
import App from './App.vue';
import { router } from './router';
import vuetify from './plugins/vuetify';
import '@/scss/style.scss';
import PerfectScrollbar from 'vue3-perfect-scrollbar';
import VueApexCharts from 'vue3-apexcharts';
import VueTablerIcons from 'vue-tabler-icons';
import 'vue3-carousel/dist/carousel.css';
import { Icon } from '@iconify/vue';
//Mock Api data
import './_mockApis';


import Maska from 'maska';

//i18
import { createI18n } from 'vue-i18n';
import messages from '@/utils/locales/messages';

//ScrollTop
import VueScrollTo from 'vue-scrollto';

//LightBox
import VueEasyLightbox from 'vue-easy-lightbox';

// toast
import Toast from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

// set preferred language
const preferredLanguage = localStorage.getItem('preferredLanguage');
console.log(preferredLanguage);
const i18n = createI18n({
    legacy: false,
    locale: preferredLanguage || 'es',
    messages: messages,
    silentTranslationWarn: true,
    silentFallbackWarn: true
});

const app = createApp(App);
app.use(router);
app.use(PerfectScrollbar);
app.use(createPinia());

app.use(VueTablerIcons);
app.use(i18n);
app.use(Maska);
app.use(VueApexCharts);
app.use(vuetify).mount('#app');
//Lightbox
app.use(VueEasyLightbox);
//ScrollTop Use
app.use(VueScrollTo, {
    duration: 1000,
    easing: "ease",
})

app.component('Icon', Icon);
