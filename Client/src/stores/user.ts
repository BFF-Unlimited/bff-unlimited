import { reactive } from 'vue';
import { ActiveUser, ActiveUserModel } from '../models/user.model';
import { useApi } from '../composables/useApi';

export const userStore = reactive({
  user: ref<ActiveUser>(),

  async getActiveUser(): Promise<void> {
    const {
      public: { baseURL },
    } = useRuntimeConfig();

    try {
      const data = await useApi(baseURL + '/User/activeUser');
      this.user = new ActiveUserModel(data);
    } catch (err) {
      console.error(err);
    }
  },
});
