<script setup lang="ts">
import { ref } from 'vue';
import BaseBreadcrumb from '@/components/shared/BaseBreadcrumb.vue';

// components
import ProfileBanner from '@/components/apps/user-profile/ProfileBanner.vue';
import IntroCard from '@/components/apps/user-profile/IntroCard.vue';
import PhotosCard from '@/components/apps/user-profile/PhotosCard.vue';
import PostListing from '@/components/apps/user-profile/PostListing.vue';
import AddPost from '@/components/apps/user-profile/posts/AddPost.vue';

const breadcrumbs = ref([
    {
        text: 'Dashboard',
        disabled: false,
        href: '/'
    },
    {
        text: 'User Profile',
        disabled: true,
        href: '#'
    }
]);
</script>

<template>
  <BaseBreadcrumb :title="$t('USER_PROFILE')" :breadcrumbs="breadcrumbs"></BaseBreadcrumb>
    <ProfileBanner />
    <v-row class="mt-4 !tw-mb-10">
      <AddPost />
    </v-row>
</template>
