import { Permission } from './permission.model';
import { Groep } from './groep.model';
import { Vestiging } from './vestiging.model';

export interface ActiveUser {
    id: string;
    // TODO: Backend moet dit veranderen naar "username"
    userName: string;
    activeVestiging: Vestiging;
    activeGroep: Groep;
    vestigingen: Vestiging[]
    groepen: Groep[];
    permissions: Permission[];
}

export class ActiveUserModel {
    id: string;
    // TODO: Backend moet dit veranderen naar "username"
    userName: string;
    activeVestiging: Vestiging;
    activeGroep: Groep;
    vestigingen: Vestiging[]
    groepen: Groep[];
    permissions: Permission[];

    constructor(input: any) {
        this.id = input?.id ?? ''; 
        this.userName = input?.userName ?? ''; 
        this.activeVestiging = input?.activeVestiging ?? null; 
        this.activeGroep = input?.activeGroep ?? null; 
        this.vestigingen = input?.vestigingen ?? null; 
        this.groepen = input?.groepen ?? null; 
        this.permissions = input?.permissions ?? null; 
    }
}