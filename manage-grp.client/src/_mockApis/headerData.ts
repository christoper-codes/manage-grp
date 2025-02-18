// project imports
import mock from './mockAdapter';

import type { notificationType, profileType, languageType, appsLinkType,searchType } from '@/types/HeaderTypes'
//
// Notification
//
const notifications:notificationType[] = [
    {
        avatar: 'settings-line-duotone',
        color:'secondary',
        title: 'SETTINGS',
        subtitle: 'NOTIFICATION',
        time:'12:00 AM'
    },
];

//
// Profile
//
const profileDD: profileType[] = [
    {
        title: 'MY_PROFILE',
        href: 'user/profile',
        badge:false
    },
    {
        title: 'MY_NOTES',
        href: '/apps/notes',
        badge:true
    },
    {
        title: 'ACCOUNT_SETTINGS',
        href: '/pages/account-settings',
        badge:false
    },
    {
        title: 'SINGOUT_FIELD',
        href: '/auth/login2',
        badge:false
    },

];

//
// Language
//
import flag1 from '@/assets/images/flag/icon-flag-es.webp';
import flag2 from '@/assets/images/flag/icon-flag-en.webp';
const languageDD: languageType[] = [
    { title: 'Español', subtext: 'MX', value: 'es', avatar: flag1 },
    { title: 'English', subtext: 'UK', value: 'en', avatar: flag2 },
];

//
// AppsLink
//
const appsLink: appsLinkType[] = [
    {
        avatar: 'chat-line-bold-duotone',
        color:'primary',
        title: 'MEMBER',
        subtext: 'MEMBER_DESC',
        href: '/apps/chats'
    },
    {
        avatar: 'user-bold-duotone',
        color:'success',
        title: 'ADMIN',
        subtext: 'ADMIN_DESC',
        href: 'user/profile'
    },
    {
        avatar: 'bill-list-bold-duotone',
        color:'secondary',
        title: 'SUPER_ADMIN',
        subtext: 'SUPER_ADMIN_DESC',
        href: '/ecommerce/products'
    },
];


//
// Search Data
//
const searchSugg: searchType[] = [
    {
        title: 'Modern',
        href: '/dashboards/modern'
    },
    {
        title: 'eCommerce',
        href: '/dashboards/ecommerce'
    },
    {
        title: 'Contacts',
        href: '/apps/contacts'
    },
    {
        title: 'Shop',
        href: '/ecommerce/shop'
    },
    {
        title: 'Checkout',
        href: '/ecommerce/checkout'
    },
    {
        title: 'Chats',
        href: '/apps/chats'
    },
    {
        title: 'Notes',
        href: '/apps/notes'
    },
    {
        title: 'Pricing',
        href: '/pages/pricing'
    },
    {
        title: 'Account Setting',
        href: '/pages/account-settings'
    },
];

export { notifications, profileDD, languageDD, appsLink, searchSugg };

