import { reactive } from 'vue'

export const sidebar = reactive({
    isMinimal: false,
    toggleIsMinimal() {
        this.isMinimal = !this.isMinimal
        console.log('toggle: ', this.isMinimal)
        return this.isMinimal;
    },
    setIsMinimal(value) {
        this.isMinimal = value
        return this.isMinimal;
    }
})