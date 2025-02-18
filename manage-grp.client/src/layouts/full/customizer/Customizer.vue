<script setup lang="ts">
import { ref } from 'vue';
import { useCustomizerStore } from '@/stores/customizer';
import LanguageDD from '@/layouts/full/vertical-header/LanguageDD.vue';

const customizer = useCustomizerStore();
const themeColors = ref([
    {name: 'BLUE_THEME',bg: 'themeBlue'}
]);
const DarkthemeColors = ref([
    { name: 'DARK_BLUE_THEME', bg: 'themeDarkBlue' },
]);
</script>
<template>
        <div class="tw-p-6 tw-flex tw-items-center tw-justify-between">
            <h5 class="text-h5">{{ $t('SETTINGS') }}</h5>
            <LanguageDD />
        </div>
        <v-divider></v-divider>
        <perfect-scrollbar style="height: calc(100vh - 90px)">
            <div class="pa-6">
                <v-sheet v-if="customizer.setHorizontalLayout != true">
                  <h6 class="text-h6 mb-2">{{ $t('SIDEBAR_TYPE') }}</h6>
                  <v-btn-toggle v-model="customizer.mini_sidebar" color="primary" class="my-2 btn-group-custom gap-3" rounded="0" group>
                      <v-btn :value="false" variant="text" elevation="9" class="rounded-md">
                          <LayoutSidebarIcon stroke-width="1.5" size="21" class="mr-2 icon" />
                          Full
                      </v-btn>
                      <v-btn :value="true" variant="text" elevation="9" class="rounded-md">
                          <LayoutSidebarLeftCollapseIcon stroke-width="1.5" size="21" class="mr-2 icon" />
                          Collapse
                      </v-btn>
                  </v-btn-toggle>
                </v-sheet>

                <h6 class="text-h6 mt-8 mb-5">{{ $t('LIGHT_WEBSITE_THEME') }}</h6>
                <v-item-group mandatory v-model="customizer.actTheme" class="ml-n2 v-row">
                    <v-col cols="4" v-for="theme in themeColors" :key="theme.name" class="pa-2">
                        <v-item v-slot="{ isSelected, toggle }" :value="theme.name">
                            <v-sheet
                                rounded="md"
                                class="border cursor-pointer d-block text-center px-5 py-4 hover-btns"
                                elevation="9"
                                @click="toggle"
                            >
                                <v-avatar :class="theme.bg" size="25" variant="text">
                                    <CheckIcon color="white" size="18" v-if="isSelected" />
                                </v-avatar>
                            </v-sheet>
                        </v-item>
                    </v-col>
                </v-item-group>

                <h6 class="text-h6 mt-11 mb-5">{{ $t('DARK_WEBSITE_THEME') }}</h6>
                <v-item-group mandatory v-model="customizer.actTheme" class="ml-n2 v-row">
                    <v-col cols="4" v-for="theme in DarkthemeColors" :key="theme.name" class="pa-2">
                        <v-item v-slot="{ isSelected, toggle }" :value="theme.name">
                            <v-sheet
                                rounded="md"
                                class="border cursor-pointer d-block text-center px-5 py-4 hover-btns"
                                elevation="9"
                                @click="toggle"
                            >
                                <v-avatar :class="theme.bg" size="25">
                                    <CheckIcon color="white" size="18" v-if="isSelected" />
                                </v-avatar>
                            </v-sheet>
                        </v-item>
                    </v-col>
                </v-item-group>
            </div>
        </perfect-scrollbar>
</template>

<style lang="scss"></style>
