import { toast } from 'vue3-toastify'

export function error(message: string) {
    toast(message, {
        "theme": "auto",
        "type": "error",
        "dangerouslyHTMLString": true
    });
}
