type TranslateFunction = (key: string, values?: Record<string, any>) => string

export const loginSchema = (t: TranslateFunction) => ({
  email(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      const regex = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
      if (!regex.test(value)) {
        return t('INVALID_EMAIL');
      }
      return true;
  },
  password(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      if (value.length < 8) {
        return t('FIELD_LESS_THAN', { count: 8 });
      }

      return true;
  },
  remember(value: boolean) {
      return true;
  }
});

