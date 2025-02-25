type TranslateFunction = (key: string, values?: Record<string, any>) => string

export const positionsSearchSchema = (t: TranslateFunction) => ({
  searchStateSelected(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  searchMunicipalitySelected(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  searchDependencySelected(value: string) {
    if (!value) {
      return t('REQUIRED');
    }

    return true;
  }
});

