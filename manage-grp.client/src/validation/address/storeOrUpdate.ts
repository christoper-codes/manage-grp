type TranslateFunction = (key: string, values?: Record<string, any>) => string

export const addressStoreOrUpdateSchema = (t: TranslateFunction) => ({
  id(value: string) {
      return true;
  },
  dependencyId(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  neighborhood(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  street(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  exteriorNumber(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  interiorNumber(value: string) {
      return true;
  },
  postalCode(value: string) {
    if (!value) {
      return t('REQUIRED');
    }

    return true;
  },
  latitude(value: string) {
    if (!value) {
      return t('REQUIRED');
    }

    return true;
  },
  longitude(value: string) {
    if (!value) {
      return t('REQUIRED');
    }

    return true;
  },
  reference(value: string) {
    return true;
  },
  isActive(value: boolean) {
    return true;
  }
});

