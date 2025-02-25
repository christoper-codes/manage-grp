import { toast } from 'vue3-toastify'

export function info(message: string) {
    toast(message, {
        "theme": "auto",
        "type": "info",
        "dangerouslyHTMLString": true
    });
}
