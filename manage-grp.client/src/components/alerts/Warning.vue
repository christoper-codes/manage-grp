<script setup lang="ts">
  defineProps({
    alert: {
      type: String,
      required: true,
    },
  });
</script>
<template>
<div class="tw-p-5 tw-bg-light tw-border-l-[10px] tw-font-bold tw-rounded tw-border-l-warning">
  <p>{{ $t(alert) }}</p>
</div>
</template>
