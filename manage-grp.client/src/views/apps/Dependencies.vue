<script setup lang="ts">
import { computed, nextTick, ref, watch } from 'vue';
import BaseBreadcrumb from '@/components/shared/BaseBreadcrumb.vue';
import brandAuthLogin from '@/assets/images/auth/brand-auth-login.jpeg';
import { Icon } from '@iconify/vue';
import { useI18n } from 'vue-i18n';

// i18n translation
const { t } = useI18n();
const search = ref();
const dialog = ref(false);
const dialogDelete = ref(false);
const headers = ref([
    { title: t('ITEM_IMAGE_HEADER'), key: 'ITEM_IMAGE_HEADER' },
    { title: 'Product', key: 'product' },
    { title: 'Date', key: 'date' },
    { title: 'Status', key: 'status' },
    { title: 'Price', key: 'price' },
    { title: 'Actions', key: 'actions', sortable: false }
]);
const productlist = ref([]);
const editedIndex = ref(-1);
const editedItem = ref({
    product: '',
    ITEM_IMAGE_HEADER: brandAuthLogin,
    category: '',
    date: '',
    status: '',
    price: ''
});
const defaultItem = ref({
    product: '',
    ITEM_IMAGE_HEADER: brandAuthLogin,
    category: '',
    date: '',
    status: '',
    price: ''
});
const formTitle = computed(() => {
    return editedIndex.value === -1 ? 'New Item' : 'Edit Item';
});
function initialize() {
    productlist.value = [
        {
            product: 'Curology Face wash',
            category: 'Beauty',
            ITEM_IMAGE_HEADER: brandAuthLogin,
            date: 'Thu, Jan 12 2023',
            status: 'Instock',
            price: '$275'
        },
        {
          product: 'Panel TV',
          category: 'Electronics',
          ITEM_IMAGE_HEADER: brandAuthLogin,
          date: 'Thu, Jan 12 2023',
          status: 'Out of Stock',
          price: '$275'
        },
        {
          product: 'Apple Watch',
          category: 'Electronics',
          ITEM_IMAGE_HEADER: brandAuthLogin,
          date: 'Thu, Jan 12 2023',
          status: 'Instock',
          price: '$375'
        }
    ];
}
function editItem(item) {
    editedIndex.value = productlist.value.indexOf(item);
    editedItem.value = Object.assign({}, item);
    dialog.value = true;
}
function deleteItem(item) {
    editedIndex.value = productlist.value.indexOf(item);
    editedItem.value = Object.assign({}, item);
    dialogDelete.value = true;
}
function deleteItemConfirm() {
    productlist.value.splice(editedIndex.value, 1);
    closeDelete();
}
function close() {
    dialog.value = false;
    nextTick(() => {
        editedItem.value = Object.assign({}, defaultItem.value);
        editedIndex.value = -1;
    });
}
function closeDelete() {
    dialogDelete.value = false;
    nextTick(() => {
        editedItem.value = Object.assign({}, defaultItem.value);
        editedIndex.value = -1;
    });
}
function save() {
    if (editedIndex.value > -1) {
        Object.assign(productlist.value[editedIndex.value], editedItem.value);
    } else {
        productlist.value.push(editedItem.value);
    }
    close();
}
watch(dialog, (val) => {
    val || close();
});
watch(dialogDelete, (val) => {
    val || closeDelete();
});
initialize();

</script>

<template>
    <div data-aos="fade-left" data-aos-duration="1500">
      <BaseBreadcrumb title="DEPENDENCIES"></BaseBreadcrumb>
    <v-row>
        <v-col cols="12">
            <v-card elevation="10">
                <v-data-table
                    class=" rounded-md datatabels productlist"
                    :headers="headers"
                    :items="productlist"
                    v-model:search="search"
                    items-per-page="5"
                    item-value="product"
                    color="primary"
                    show-select
                    :sort-by="[{ key: 'calories', order: 'asc' }]"
                >
                    <template v-slot:item.ITEM_IMAGE_HEADER="{ item }">
                        <div class="d-flex gap-3 align-center">
                            <div>
                                <v-img :src="`${item.ITEM_IMAGE_HEADER}`" height="55" width="55" class="rounded-circle" cover></v-img>
                            </div>
                            <div>
                                <h6 class="text-h6">{{ item.product }}</h6>
                                <p class="textSecondary">{{ item.category }}</p>
                            </div>
                        </div>
                    </template>
                    <template v-slot:item.status="{ item }">
                        <div class="d-flex gap-2 align-center">
                            <Icon icon="carbon:dot-mark" v-if="item.status == 'Instock'" class="text-success" />
                            <Icon icon="carbon:dot-mark" v-else class="text-error" />
                            {{ item.status }}
                        </div>
                    </template>
                    <template v-slot:item.price="{ item }">
                        <h6 class="text-h6">{{ item.price }}</h6>
                    </template>
                    <template v-slot:top>
                        <v-toolbar class="bg-surface" flat>
                            <v-dialog v-model="dialog" max-width="500px">
                                <template v-slot:activator="{ props }">
                                    <div class="d-md-flex block justify-space-between w-100 pa-6 align-center">
                                        <v-text-field
                                            v-model="search"
                                            append-inner-icon="mdi-magnify"
                                            :label="$t('SEARCH_FIELD')"
                                            single-line
                                            hide-details
                                            class="mb-md-0 mb-3"
                                        />
                                        <v-btn color="primary" variant="flat" dark v-bind="props">{{ $t('ADD_NEW_ITEM_FIELD') }}</v-btn>
                                    </div>
                                </template>
                                <v-card>
                                    <v-card-title class="pa-4 bg-primary">
                                        <span class="text-h5">{{ formTitle }}</span>
                                    </v-card-title>

                                    <v-card-text>
                                        <v-container class="px-0">
                                            <v-row>
                                                <v-col cols="12" sm="6" md="4">
                                                    <v-text-field v-model="editedItem.category" label="Category"></v-text-field>
                                                </v-col>
                                                <v-col cols="12" sm="6" md="4">
                                                    <v-text-field v-model="editedItem.product" label="Product name"></v-text-field>
                                                </v-col>
                                                <v-col cols="12" sm="6" md="4">
                                                    <v-text-field v-model="editedItem.date" label="Date"></v-text-field>
                                                </v-col>
                                                <v-col cols="12" sm="6" md="4">
                                                    <v-select
                                                        label="Select"
                                                        v-model="editedItem.status"
                                                        variant="outlined"
                                                        :items="['Instock', 'Out of Stock']"
                                                    ></v-select>
                                                </v-col>
                                                <v-col cols="12" sm="6" md="4">
                                                    <v-text-field v-model="editedItem.price" label="Price"></v-text-field>
                                                </v-col>
                                            </v-row>
                                        </v-container>
                                    </v-card-text>

                                    <v-card-actions>
                                        <v-spacer></v-spacer>
                                        <v-btn color="error" variant="flat" dark @click="close"> Cancel </v-btn>
                                        <v-btn color="primary" variant="flat" dark @click="save"> Save </v-btn>
                                    </v-card-actions>
                                </v-card>
                            </v-dialog>
                            <v-dialog v-model="dialogDelete" max-width="500px">
                                <v-card>
                                    <v-card-title class="text-h5 text-center py-6">Are you sure you want to delete this item?</v-card-title>
                                    <v-card-actions>
                                        <v-spacer></v-spacer>
                                        <v-btn color="error" variant="flat" dark @click="closeDelete">Cancel</v-btn>
                                        <v-btn color="primary" variant="flat" dark @click="deleteItemConfirm">OK</v-btn>
                                        <v-spacer></v-spacer>
                                    </v-card-actions>
                                </v-card>
                            </v-dialog>
                        </v-toolbar>
                    </template>
                    <template v-slot:item.actions="{ item }">
                        <div class="d-flex gap-3">
                            <Icon
                                icon="solar:pen-new-square-broken"
                                height="20"
                                class="text-primary cursor-pointer"
                                size="small"
                                @click="editItem(item)"
                            />
                            <Icon
                                icon="solar:trash-bin-minimalistic-linear"
                                height="20"
                                class="text-error cursor-pointer"
                                size="small"
                                @click="deleteItem(item)"
                            />
                        </div>
                    </template>
                    <template v-slot:no-data>
                        <v-btn color="primary" @click="initialize"> Reset </v-btn>
                    </template>
                </v-data-table>
            </v-card>
        </v-col>
    </v-row>
    </div>
</template>
