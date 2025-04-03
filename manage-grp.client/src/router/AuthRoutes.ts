const AuthRoutes = {
    path: '/',
    component: () => import('@/layouts/blank/BlankLayout.vue'),
    meta: { requiresAuth: false },
    children: [
        {
            name: 'login',
            path: '',
            component: () => import('@/views/authentication/Login.vue')
        }
        ,{
            name: 'forgot-password',
            path: 'forgot-password',
            component: () => import('@/views/authentication/ForgotPassword.vue')
        },
        {
            name: 'error',
            path: '404',
            component: () => import('@/views/authentication/Error.vue')
        },
        {
            name: 'maintenance',
            path: 'maintenance',
            component: () => import('@/views/authentication/Maintenance.vue')
        },
        {
          name: 'policy-privacy',
          path: 'policy-privacy',
          component: () => import('@/views/legal/privacyPolicy.vue')
        },
        {
            name: 'sign-up',
            path: 'sign-up',
            component: () => import('@/views/authentication/SignUp.vue')
        },
    ]
};

export default AuthRoutes;
