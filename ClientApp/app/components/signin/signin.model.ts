export class SignInVM {
    email: string;
    password: string;
    constructor(email: string, password: string) {
        this.email = email;
        this.password = password;
    }
}

export class TokenProvider {
    access_token:string;
    expires_in:Date;
    uid: number;
    constructor(token: string, uid: number, expiresin:Date) {
        this.access_token = token;
        this.uid=uid;
        this.expires_in = expiresin;
    }
}