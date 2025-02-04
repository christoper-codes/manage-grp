<script setup lang="ts">

import ClientReviews from '@/components/frontpages/Homepage/ClientReviews.vue';
import ContactBar from '@/components/frontpages/Homepage/ContactBar.vue';
import FAQ from '@/components/frontpages/Homepage/FAQ.vue';
import FeatureTabs from '@/components/frontpages/Homepage/FeatureTabs.vue';
import MainBanner from '@/components/landingpage/section/mainBanner.vue';
import OurClients from '@/components/frontpages/Homepage/OurClients.vue';
import DefaultLayout from '@/views/pages/front-pages/Layout.vue';
import BuyNow from '@/components/landingpage/section/buyNow.vue';
</script>

<template>
    <DefaultLayout>
        <MainBanner />
        <OurClients />
        <ContactBar/>
        <FeatureTabs />
        <ClientReviews/>
        <BuyNow />
        <FAQ/>
    </DefaultLayout>
</template>
