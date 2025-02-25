type TranslateFunction = (key: string, values?: Record<string, any>) => string

export const budgetaryKeyDocumentTypeStoreOrUpdateSchema = (t: TranslateFunction) => ({
  id(value: string) {
      return true;
  },
  dependencyId(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  key(value: string) {
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
  },
  mandatory(value: boolean) {

    if (!value) {
      return t('REQUIRED');
    }

    return true;
  }
});

