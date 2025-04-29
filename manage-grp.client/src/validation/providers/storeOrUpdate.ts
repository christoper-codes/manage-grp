type TranslateFunction = (key: string, values?: Record<string, any>) => string

export const providersStoreOrUpdateSchema = (t: TranslateFunction) => ({

  socialReason(value: string) {
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
  corporatePurpose(value: string) {
      if (!value) {
        return t('REQUIRED');
      }

      return true;
  },
  rfc(value: string) {
    if (!value) {
        return t('REQUIRED');
      }

      return true;
  },

});

