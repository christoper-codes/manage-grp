type TranslateFunction = (key: string, values?: Record<string, any>) => string

export const contactStoreOrUpdateSchema = (t: TranslateFunction) => ({
  id(value: string) {
      return true;
  },
  dependencyId(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  areaId(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  positionId(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  firstName(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  middleName(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  paternalLastName(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  maternalLastName(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
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
  phone(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      const regex = /^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$/;
      if (!regex.test(value)) {
        return t('INVALID_PHONE');
      }

      return true;
  },
  isActive(value: boolean) {
    return true;
  }
});

