
import { DewormingDog } from './dewormingDog';
import { Puppy } from './pup';
import { VaccinationDog } from './vaccinationDog';


export interface Fdog {
    id: number;
    imie: string;
    puppies: Puppy[];
    vaccinationPuppy: VaccinationDog[];
    dewormingDog: DewormingDog[]
    plec: string;
    rasa: string;
    masc: string;
    wiek: number;
    dlugoscSiersci: string;
    rodowod: boolean;
    dataUrodzenia: string;
    ostatniaAktualizacja: string;
    userId: number;    
}
