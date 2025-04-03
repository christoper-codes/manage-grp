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
            name: 'dependencies',
            path: '/apps/tickets',
            component: () => import('@/views/apps/Dependencies.vue')
        },
        {
          name: 'areas',
          path: '/apps/areas',
          component: () => import('@/views/apps/Areas.vue')
        },
        {
          name: 'positions',
          path: '/apps/positions',
          component: () => import('@/views/apps/Positions.vue')
        },
        {
          name: 'contacts',
          path: '/apps/contacts',
          component: () => import('@/views/apps/Contacts.vue')
        },
        {
          name: 'addresses',
          path: '/apps/addresses',
          component: () => import('@/views/apps/Addresses.vue')
        },
        {
          name: 'budgetary-key-document-types',
          path: '/apps/budgetary-key-document-types',
          component: () => import('@/views/apps/BudgetaryKeyDocumentTypes.vue')
        },
        {
          name: 'resource-distribution-document-types',
          path: '/apps/resource-distribution-document-types',
          component: () => import('@/views/apps/ResourceDistributionDocumentTypes.vue')
        },
        {
          name: 'tender-document-types',
          path: '/apps/tender-document-types',
          component: () => import('@/views/apps/TenderDocumentTypes.vue')
        }
    ]
};

export default MainRoutes;
