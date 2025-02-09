<script setup lang="ts">
import { RouterView } from "vue-router";
import Aos from 'aos';
import 'aos/dist/aos.css';
import { onMounted } from "vue";

onMounted(() => {
  Aos.init();
});
</script>

<template>
  <RouterView></RouterView>
</template>
