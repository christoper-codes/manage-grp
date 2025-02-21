import type { ThemeTypes } from '@/types/ThemeType';

const BLUE_THEME: ThemeTypes = {
    name: 'BLUE_THEME',
    dark: false,
    variables: {
        'border-color': '#e0e6eb',
        'border-opacity': 1
    },
    colors: {
        primary: '#635BFF',
        secondary: '#16CDC7',
        info: '#46caeb',
        success: '#22c55e',
        warning: '#ffd648',
        error: '#dc2626',
        lightprimary: '#DDDBFF',
        lightsecondary: '#A6F7F5',
        lightsuccess: '#E1F7E9',
        lighterror: '#FFCCDB',
        lightinfo: '#DAF4FB',
        lightwarning: '#FFF9E5',
        textPrimary: '#29343D',
        textSecondary: '#98A4AE',
        borderColor: '#e0e6eb',
        containerBg: '#ffffff',
        background: '#F4F7FB',
        hoverColor: '#f6f9fc',
        surface: '#fff',
        grey100: '#F6F7F9',
        grey200: '#29343d',
        darkgray: '#0a2540',
        light: '#EFF4FA',
        muted:'#526b7a'
    }
};

export { BLUE_THEME };
