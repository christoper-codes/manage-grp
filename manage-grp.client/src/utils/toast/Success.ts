import { toast } from 'vue3-toastify'

export function success(message: string) {
    toast(message, {
        "theme": "auto",
        "type": "success",
        "dangerouslyHTMLString": true
    });
}
