import { URLSearchParams, Http, Headers, RequestMethod } from '@angular/http';
import { Injectable } from '@angular/core';
import { TokenProvider } from '../components/signin/signin.model';
import { Router } from '@angular/router';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
import { ToasterService } from 'angular2-toaster';
import { AuthService } from './auth.service';
@Injectable()
export class SignInService {
    baseUrl: string = "/api/accounts"
    constructor(public http: Http, private router: Router, private toaster: ToasterService) {
    }
    signInService(model: any) {
        var body = new URLSearchParams();
        body.append("email", model.email);
        body.append("password", model.password);
        return this.http.post(this.baseUrl + "/token", body,
            { headers: AuthService.credentialHeaderForLogin() })
            .toPromise()
            .then(async response => {
                if (response.ok) {
                    var tokenAuth = (response.json() as TokenProvider);
                    localStorage.setItem('token', JSON.stringify(tokenAuth.access_token));
                    localStorage.setItem('uid', JSON.stringify(tokenAuth.uid));
                    this.toaster.popAsync("success", "Information", "Sign in successful");
                    return this.router.navigateByUrl("");
                }
            }).catch(err => {
                if (err.status == 400) {
                    this.toaster.popAsync("warning", "Warning", "Are you sure about email and password?");
                }
                if (err.status == 306) {
                    this.toaster.popAsync("warning", "Warning", "Your account has blocked by Administrator");
                }
            });
    }
    forgetPassword(model: any) {
        return this.http.post(this.baseUrl + "/forgetpassword", JSON.stringify(model.email), { headers: AuthService.credentialHeader() })
            .toPromise()
            .then(response => {
                if (response.ok) {
                    this.toaster.popAsync("success", "Information", "Check mail");
                    this.router.navigate(["/signin"]);
                }
                else {
                    this.toaster.popAsync("warning", "Warning", "Are you sure about email?");
                    return;
                }
            }).catch(err => this.toaster.popAsync("warning", "Warning", "Are you sure about email?"));
    }
    signOut() {
        return this.http.delete(this.baseUrl + "/logout", { headers: AuthService.credentialHeader() })
            .toPromise()
            .then(response => {
                if (response) {
                    localStorage.clear();
                    this.toaster.popAsync("success", "Information", "Signed out");
                    this.router.navigate(["/signin"]);
                }
            }).catch(err => this.toaster.popAsync("error", "Error", "System has problem."));
    }
}