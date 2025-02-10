import mock from './mockAdapter';

import './apps/ecommerce';
import './apps/userprofile/posts';
import './apps/userprofile/followers';
import './apps/userprofile/friends';
import './apps/userprofile/gallery';
import './apps/userprofile/photos';
import './apps/blog/index';
import './headerData';
import './apps/tickets';
import './apps/invoice';
import './apps/contact';
import './headerData';
import './apps/kanban';

mock.onAny().passThrough();
