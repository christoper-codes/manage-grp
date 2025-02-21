import es from './es.json';
import en from './en.json';

import esAuth from './es/auth.json';
import esCommon from './es/common.json';
import esDashboard from './es/dashboard.json';
import esFields from './es/fields.json';
import esErrorsFieds from './es/errors-fields.json';
import esPrivacyPolicy from './es/privacy-policy.json';
import esToastify from './es/toastify.json';
import esHeaders from './es/headers.json';
import esNotice from './es/notice.json';

import enAuth from './en/auth.json';
import enCommon from './en/common.json';
import enDashboard from './en/dashboard.json';
import enFields from './en/fields.json';
import enErrorsFieds from './en/errors-fields.json';
import enPrivacyPolicy from './en/privacy-policy.json';
import enToastify from './en/toastify.json';
import enHeaders from './en/headers.json';
import enNotice from './en/notice.json';


const messages = {
    es: {
        ...es,
        ...esAuth,
        ...esCommon,
        ...esDashboard,
        ...esFields,
        ...esErrorsFieds,
        ...esPrivacyPolicy,
        ...esToastify,
        ...esHeaders,
        ...esNotice
    },
    en: {
      ...en,
      ...enAuth,
      ...enCommon,
      ...enDashboard,
      ...enFields,
      ...enErrorsFieds,
      ...enPrivacyPolicy,
      ...enToastify,
      ...enHeaders,
      ...enNotice
    }
};

export default messages;
