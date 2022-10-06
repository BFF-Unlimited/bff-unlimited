import { Permission } from './permission.model';
import { Groep } from './groep.model';
import { Vestiging } from './vestiging.model';

export interface ActiveUser {
  id: string;
  // TODO: Backend moet dit veranderen naar "username"
  userName: string;
  activeVestiging: Vestiging;
  activeGroep: Groep;
  vestigingen: Vestiging[];
  groepen: Groep[];
  permissions: Permission[];
}

function isIngelogd(input: ActiveUser | {} | null) : input is ActiveUser {
  return !!input && "id" in input;
}

export class ActiveUserModel {
  id: string;
  // TODO: Backend moet dit veranderen naar "username"
  userName: string;
  activeVestiging: Vestiging | null;
  activeGroep: Groep | null;
  vestigingen: Vestiging[];
  groepen: Groep[];
  permissions: Permission[];

  constructor(input: ActiveUser | {}) {
    if(!isIngelogd(input))
    {
      this.id = '';
      this.userName = '';
      this.activeVestiging = null;
      this.activeGroep = null;
      this.vestigingen = [];
      this.groepen = [];
      this.permissions = [];
      return;
    }
    Object.assign(this, input);
  }
}
