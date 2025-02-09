import { createRouter, createWebHistory } from 'vue-router';
import MainRoutes from './MainRoutes';
import AuthRoutes from './AuthRoutes';

export const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/:pathMatch(.*)*',
            component: () => import('@/views/authentication/Error.vue')
        },
        MainRoutes,
        AuthRoutes
    ]
});

router.beforeEach(async (to, from, next) => {
    const requiresAuth = to.matched.some(record => record.meta.requiresAuth);
    const isAuthenticated = localStorage.getItem('token');

    if(requiresAuth && !isAuthenticated){
        next({ name: 'login' });
    } else if(requiresAuth && isAuthenticated){
        // check if route is restricted by role
        next();
    } else if((to.name === 'login' || to.name === 'register') && isAuthenticated){
        next({ name: 'dashboard' });
    } else {
        next();
    }

});
/* router.beforeEach(async (to, from, next) => {
    // redirect to login page if not logged in and trying to access a restricted page
    const publicPages = ['/auth/login2'];
    const authRequired = !publicPages.includes(to.path);
    const auth: any = useAuthStore();

    if (to.matched.some((record) => record.meta.requiresAuth)) {
        if (authRequired && !auth.user) {
            auth.returnUrl = to.fullPath;
            return next('/auth/login2');
        } else next();
    } else {
        next();
    }
}); */
