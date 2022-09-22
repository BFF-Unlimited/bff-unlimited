import { reactive } from 'vue';
import { useApi } from '~~/composables';

export const sidebarStore = reactive({
  isMinimal: false,
  navigation: ref([]),

  toggleIsMinimal() {
    this.isMinimal = !this.isMinimal;
  },
  setIsMinimal(value) {
    this.isMinimal = value;
  },
  async getUserPermissions() {
    const {
      public: { baseURL },
    } = useRuntimeConfig();

    try {
      console.log('baseURL: ', baseURL);
      const data = await useApi(baseURL + '/User/activeUser');
      console.log('response: ', data);

      this.navigation = this.fromPermissionToMenu(data?.permissions);
      console.log('navigation: ', this.navigation);
    } catch (err) {
      console.error(err);
    }
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
    return {
      link: '/',
      active: false,
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
interface Permission {
  categoryDescription: string;
  description: string;
  id: string;
}
