import { DewormingPuppy } from "./dewormingPuppy";
import { VaccinationPuppy } from "./vaccinationPuppy";


export interface Puppy {
        id: number;
        imie: string;
        plec: string;
        rasa: string;
        masc: string;
        wiek: number;
        dlugoscSiersci: string;
        rodowod: boolean;
        dataUrodzenia: string;
        ostatniaAktualizacja: string;
        matkaId: number;
        vaccinationPuppy: VaccinationPuppy[];
        dewormingDog: DewormingPuppy[]
}
