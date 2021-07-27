import { Fdog } from './fdog';

export interface User {
    id: number;
    name: string;
    email: string;
    passwordHash: string;
    passwordSalt: string;
    fdogs: Fdog[];
}
