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
    const isAuthenticated = localStorage.getItem('jwtTokens');

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
