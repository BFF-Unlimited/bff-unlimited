import { reactive } from 'vue';
import { Permission } from '../models/permission.model';
import { userStore } from './user';

export const sidebarStore = reactive({
  isMinimal: false,
  navigation: ref<LinkParentObject[]>([]),

  toggleIsMinimal() {
    this.isMinimal = !this.isMinimal;
  },
  setIsMinimal(value: boolean) {
    this.isMinimal = value;
  },
  async getUserPermissions() {
    if (!userStore.user?.id || userStore.user?.id === '') {
      await userStore.getActiveUser();
    }
    this.navigation = this.fromPermissionToMenu(userStore.user?.permissions);
  },
  fromPermissionToMenu(permissions: Permission[]): LinkParentObject[] {
    const permission = {};
    permissions.forEach((item) => {
      const [propName] = item.categoryDescription.split('.');
      const name = propName.toLowerCase();
      if (permission[name]) {
        permission[name]?.items.push(this.createMenuItem(item));
      } else {
        permission[name] = this.createMenuItem(item);
        permission[name].items = [];
        permission[name].name = propName;
      }
    });
    return Object.values(permission);
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
