import { URLSearchParams, Http, Headers, RequestMethod } from '@angular/http';
import { Injectable } from '@angular/core';
import { TokenProvider } from '../components/signin-up/signin-up.model';
import { Router } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class SignInUpService {
    baseUrl:string = "/account"
    constructor(private http: Http, private router:Router) {
    }
    signInService(model:any):Promise<TokenProvider> {
        return this.http.post(this.baseUrl + "/token", model)
            .toPromise()
            .then(response => response.json().data as TokenProvider)
            .catch(err => console.log(err))
    }
    signUpService(model: any) {
        var body = new URLSearchParams();
        body.set("firstname", model.firstName);
        body.set("lastname", model.lastName);
        body.set("email", model.email);
        body.set("passwordhashed", model.password);
        var headers = new Headers();
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return this.http.post(this.baseUrl + "/register", body, {headers:headers})
            .toPromise()
            .then(response => {
                if (response.ok) {
                    this.router.navigate(["./signin"]);
                }
                else {
                    return;
                }
            }).catch(err => console.log(err));
    }
}