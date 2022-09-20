import { reactive } from 'vue'

export const sidebar = reactive({
    isMinimal: false,
    toggleIsMinimal() {
        this.isMinimal = !this.isMinimal
    },
    setIsMinimal(value) {
        this.isMinimal = value;
    }
})