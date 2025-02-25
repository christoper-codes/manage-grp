type TranslateFunction = (key: string, values?: Record<string, any>) => string

export const positionStoreOrUpdateSchema = (t: TranslateFunction) => ({
  id(value: string) {
      return true;
  },
  dependencyId(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  name(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  abbreviation(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  description(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  isActive(value: boolean) {
    return true;
  }
});

