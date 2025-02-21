type TranslateFunction = (key: string, values?: Record<string, any>) => string

export const dependencyStoreOrUpdateSchema = (t: TranslateFunction) => ({
  id(value: string) {
      return true;
  },
  municipalityId(value: string) {
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
  acronym(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  rfc(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      const rfcPattern = /^([A-ZÑ&]{3,4}) ?(?:- ?)?(\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])) ?(?:- ?)?([A-Z\d]{2})([A\d])$/;
      if (!rfcPattern.test(value)) {
        return t('INVALID_RFC');
      }

      return true;
  },
  isActive(value: boolean) {
    return true;
  }
});

