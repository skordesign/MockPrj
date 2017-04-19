export class SignUpVM {
    email: string;
    firstName: string;
    lastName: string;
    password: string;
    constructor(firstname: string, lastname: string, email: string, password: string) {
        this.email = email;
        this.firstName = firstname;
        this.lastName = lastname;
        this.password = password;
    }
}

export class SignInVM {
    email: string;
    password: string;
    constructor(email: string, password: string) {
        this.email = email;
        this.password = password;
    }
}

export class TokenProvider {
    token: string;
    uid: number;
    constructor(token: string, uid: number) {
        this.token = token;
        this.uid=uid;
    }
}