const ProfileRoutes = {
  path: "/profile",
  mata: { requiresAuth: true },
  component: () => import("@/layouts/full/FullLayout.vue"),
  children: [
    {
      name: 'user-profile',
      path: 'user/profile',
      component: () => import('@/views/profile/Profile.vue')
    },
    {
      name: 'Notes',
      path: '/apps/notes',
      component: () => import('@/views/profile/Notes.vue')
    },
    {
      name: 'Kanban',
      path: '/apps/kanban',
      component: () => import('@/views/profile/Kanban.vue')
    },
    {
      name: 'Account Setting',
      path: '/pages/account-settings',
      component: () => import('@/views/profile/AccountSettings.vue')
    },
  ]
};

export default ProfileRoutes;
