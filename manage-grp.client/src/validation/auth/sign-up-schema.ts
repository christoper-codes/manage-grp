type TranslateFunction = (key: string, values?: Record<string, any>) => string;

export const signUpSchema = (t: TranslateFunction) => {
  let savedPassword = ''; // Variable para almacenar la contraseña

  return {
    userName(value: string) {
      if (!value) return t('REQUIRED');
      return true;
    },
    name(value: string) {
      if (!value) return t('REQUIRED');
      return true;
    },
    lastName(value: string) {
      if (!value) return t('REQUIRED');
      return true;
    },
    email(value: string) {
      if (!value) return t('REQUIRED');

      const regex = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
      if (!regex.test(value)) return t('INVALID_EMAIL');

      return true;
    },
    phoneNumber(value: string) {
      if (!value) return t('REQUIRED');

      if (value.length !== 10) {
        return t('FIELD_LESS_THAN', { count: 10 });
      }

      return true;
    },
    password(value: string) {
      if (!value) return t('REQUIRED');

      if (value.length < 8) {
        return t('FIELD_LESS_THAN', { count: 8 });
      }

      savedPassword = value; // Guardamos la contraseña
      return true;
    },
    confirmPassword(value: string) {
      if (!value) return t('REQUIRED');

      if (value !== savedPassword) {
        return t('PASSWORDS_DO_NOT_MATCH');
      }

      return true;
    },
    state(value: string) {
      if (!value) return t('REQUIRED');
      return true;
    },
  };
};
