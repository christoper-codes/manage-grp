import { useI18n } from 'vue-i18n';

export function useDateFormat() {
  const { locale } = useI18n();
  const preferredLanguage: string = locale.value === 'es' ? 'es-ES' : 'en-US';

  const dateFormat = (dateString: string) => {
    const date: Date = new Date(dateString);
    const formattedDate: string = new Intl.DateTimeFormat(preferredLanguage, {
      year: 'numeric',
      month: 'long',
      day: 'numeric',
      hour: '2-digit',
      minute: '2-digit',
      second: '2-digit'
    }).format(date);

    return formattedDate;
  };

  return {
    dateFormat
  };
}
