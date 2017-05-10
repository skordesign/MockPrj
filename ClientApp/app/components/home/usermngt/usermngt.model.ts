export class UserModel {
    public firstname: string;
    public lastname: string;
    public email: string;
    public passwordHashed:string;
    public isBlock: boolean = false;
    public adddate: Date;
    public editdate: Date;
    public roleId: number;
    constructor(fn: string, ln: string, pwd: string, em: string, rI: number) {
        this.firstname = fn;
        this.lastname = ln;
        this.passwordHashed = pwd;
        this.email = em;
        this.roleId = rI;
    }
}