/** @type {import('tailwindcss').Config} */
export default {
  prefix: 'tw-',
  content: [
    './index.html',
    './src/**/*.{vue,js,ts,jsx,tsx}',
  ],
  theme: {
    extend: {
      colors: {
        'primary': 'rgb(var(--v-theme-primary))',
        'secondary': 'rgb(var(--v-theme-secondary))',
        'third': 'rgb(var(--v-theme-third))',
        'info': 'rgb(var(--v-theme-info))',
        'success': 'rgb(var(--v-theme-success))',
        'warning': 'rgb(var(--v-theme-warning))',
        'error': 'rgb(var(--v-theme-error))',
        'lightprimary': 'rgb(var(--v-theme-lightprimary))',
        'lightsecondary': 'rgb(var(--v-theme-lightsecondary))',
        'lightsuccess': 'rgb(var(--v-theme-lightsuccess))',
        'lighterror': 'rgb(var(--v-theme-lighterror))',
        'lightinfo': 'rgb(var(--v-theme-lightinfo))',
        'lightwarning': 'rgb(var(--v-theme-lightwarning))',
        'text-primary': 'rgb(var(--v-theme-textPrimary))',
        'text-secondary': 'rgb(var(--v-theme-textSecondary))',
        'border-color': 'rgb(var(--v-theme-borderColor))',
        'container-bg': 'rgb(var(--v-theme-containerBg))',
        'background': 'rgb(var(--v-theme-background))',
        'hover-color': 'rgb(var(--v-theme-hoverColor))',
        'surface': 'rgb(var(--v-theme-surface))',
        'grey100': 'rgb(var(--v-theme-grey100))',
        'grey200': 'rgb(var(--v-theme-grey200))',
        'light': 'rgb(var(--v-theme-light))',
        'muted': 'rgb(var(--v-theme-muted))',
        'darkgray': 'rgb(var(--v-theme-darkgray))',
      }
    },
  },
  plugins: [],
}

