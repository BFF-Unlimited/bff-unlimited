import { reactive } from 'vue';
import { Permission } from '../models/permission.model';
import { useApi } from '../composables/useApi';
import { userStore } from './user';

export const sidebarStore = reactive({
  isMinimal: false,
  navigation: ref<LinkParentObject[]>([]),

  toggleIsMinimal() {
    this.isMinimal = !this.isMinimal;
  },
  setIsMinimal(value) {
    this.isMinimal = value;
  },
  async getUserPermissions() {
    if (!userStore.user.id || userStore.user.id === '') {
      await userStore.getActiveUser();
    }
    this.navigation = this.fromPermissionToMenu(userStore.user?.permissions);
  },
  fromPermissionToMenu(permissions: Permission[]): LinkParentObject[] {
        const perm = {};
    permissions.forEach((item) => {
      const [propName, child] = item.categoryDescription.split('.');
      const name = propName.toLowerCase();
      if (perm[name]) {
        perm[name]?.items.push(this.createMenuItem(item));
      } else {
        perm[name] = this.createMenuItem(item);
        perm[name].items = [];
        perm[name].name = propName;
      }
    });
    return Object.values(perm);
  },
  createMenuItem(value: Permission): LinkObject {
    const active = value.description === 'Groepsoverzicht';
    return {
      link: '/',
      active,
      id: value?.id,
      name: value?.description,
    };
  },
});

interface LinkObject {
  link: string;
  active: boolean;
  id: string;
  name: string;
}
interface LinkParentObject {
  link: string;
  active: boolean;
  id: string;
  name: string;
  items?: LinkObject[];
}
