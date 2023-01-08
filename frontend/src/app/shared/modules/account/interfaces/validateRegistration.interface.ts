import { UserCredential } from "firebase/auth";

export declare interface IValidateRegistration {
    
    /**
     * Verifica que el usuario haya completado su registro
     * @param pUser Objeto usuario
     */
    validateRegistration(pUser: UserCredential): void;
}