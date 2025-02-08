import es from './es.json';
import en from './en.json';

import esAuth from './es/auth.json';
import esCommon from './es/common.json';
import esDashboard from './es/dashboard.json';
import esFields from './es/fields.json';
import esErrorsFieds from './es/errors-fields.json';
import esToastify from './es/toastify.json';

import enAuth from './en/auth.json';
import enCommon from './en/common.json';
import enDashboard from './en/dashboard.json';
import enFields from './en/fields.json';
import enErrorsFieds from './en/errors-fields.json';
import enToastify from './en/toastify.json';


const messages = {
    es: {
        ...es,
        ...esAuth,
        ...esCommon,
        ...esDashboard,
        ...esFields,
        ...esErrorsFieds,
        ...esToastify
    },
    en: {
      ...en,
      ...enAuth,
      ...enCommon,
      ...enDashboard,
      ...enFields,
      ...enErrorsFieds,
      ...enToastify
    }
};

export default messages;
