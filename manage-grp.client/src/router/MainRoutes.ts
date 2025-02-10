const MainRoutes = {
    path: '/main',
    meta: { requiresAuth: true },
    component: () => import('@/layouts/full/FullLayout.vue'),
    children: [
        {
            name: 'dashboard',
            path: 'dashboard',
            component: () => import('@/views/dashboards/index.vue')
        },
        {
            name: 'Product Listing',
            path: '/apps/tickets',
            component: () => import('@/views/apps/eCommerce/ProductList.vue')
        },
        {
            name: 'user-profile',
            path: 'user/profile',
            component: () => import('@/views/apps/user-profile/Profile.vue')
        },
        {
            name: 'Notes',
            path: '/apps/notes',
            component: () => import('@/views/apps/notes/Notes.vue')
        },
        {
            name: 'Kanban',
            path: '/apps/kanban',
            component: () => import('@/views/apps/kanban/Kanban.vue')
        },
        {
            name: 'Account Setting',
            path: '/pages/account-settings',
            component: () => import('@/views/pages/account-settings/AccountSettings.vue')
        },

    ]
};

export default MainRoutes;
