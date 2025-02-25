<script setup lang="ts">
import { onMounted, watch } from 'vue';
import L from 'leaflet';
import { ref } from 'vue';
import axios from 'axios';
import { useI18n } from 'vue-i18n';
import { error } from "@/utils/toast/Error";
import { info } from "@/utils/toast/Info";

// emtis and props
const emits = defineEmits(['update-form-by-map-emit']);

// i18n translation
const { t } = useI18n();

// data
const addressInfo = ref<string | null>(null);
const stylePreference = ref('streets-v12');
let map: L.Map | null = null;
const tileLayer = ref<L.TileLayer | null>(null);
const token = import.meta.env.VITE_MAPBOX_API_TOKEN;
const updateMapStyle = (style: string) => {
  stylePreference.value = style;
};

// Lifecycle hooks
onMounted(() => {
  map = L.map('leaflet-map').setView([19.4326, -99.1332], 10);

  tileLayer.value  = L.tileLayer(`https://api.mapbox.com/styles/v1/mapbox/${stylePreference.value}/tiles/{z}/{x}/{y}?access_token=${token}`, {
    tileSize: 512,
    zoomOffset: -1,
  }).addTo(map);

  let marker: L.Marker | null = null;

  map.on('click', async (e: L.LeafletMouseEvent) => {
    if (marker) {
      map.removeLayer(marker);
    }
    marker = L.marker([e.latlng.lat, e.latlng.lng]).addTo(map);
    console.log(`Latitud: ${e.latlng.lat}, Longitud: ${e.latlng.lng}`);
    try {
      const response = await axios.get('https://nominatim.openstreetmap.org/reverse', {
        params: {
          format: 'json',
          lat: e.latlng.lat,
          lon: e.latlng.lng,
          addressdetails: 1
        }
      });
      const data = response.data;
      const neighborhood = data.address.neighbourhood || data.address.hamlet || data.address.county || data.address.city;
      const street = data.address.road || data.address.hamlet || data.address.county || data.address.city;
      const postalCode = data.address.postcode;
      // covert to string
      const latitude = e.latlng.lat.toString();
      const longitude = e.latlng.lng.toString();
      const reference = data.display_name;
      info(t('SUCCESS_MESSAGE'));
      emits('update-form-by-map-emit', neighborhood, street, postalCode, latitude, longitude, reference);
    } catch (ex) {
      //error(t('ERROR_MESSAGE'));
    }
  });
});

// Watchers
watch(stylePreference, (newStyle) => {
  if (tileLayer.value) {
    map.removeLayer(tileLayer.value);
  }
  tileLayer.value = L.tileLayer(`https://api.mapbox.com/styles/v1/mapbox/${newStyle}/tiles/{z}/{x}/{y}?access_token=${token}`, {
    tileSize: 512,
    zoomOffset: -1,
  }).addTo(map);
});

</script>

<template>
  <div id="leaflet-map" class="tw-h-[500px] tw-rounded-xl"></div>
  <div class="tw-flex tw-items-center tw-justify-end tw-gap-3 tw-mt-3">
    <v-btn @click="updateMapStyle('satellite-streets-v12')" color="primary"  variant="flat" size="large" dark>{{ $t('SATELLITE') }}</v-btn>
    <v-btn @click="updateMapStyle('streets-v12')" color="secondary"  variant="flat" size="large" dark>{{ $t('STREET') }}</v-btn>
  </div>
</template>
