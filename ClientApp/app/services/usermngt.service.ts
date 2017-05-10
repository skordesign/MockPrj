import { Injectable } from '@angular/core';
import { TokenProvider } from '../components/signin/signin.model';
import { Router } from '@angular/router';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { ToasterService } from 'angular2-toaster';
import { URLSearchParams, Response, Headers, Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { AuthService } from './auth.service';

@Injectable()
export class UserMngtService {
    baseUrl: string = "/api/users";
    constructor(private http: Http, private toaster: ToasterService, private router: Router) {
    }
    getAll(): Observable<any[]> {
        return this.http.get(this.baseUrl, { headers: AuthService.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."));
    }
    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
    getRoles(): Observable<any[]> {
        return this.http.get(this.baseUrl + "/role", { headers: AuthService.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."))
    }

    getRole(roleId: number): Observable<any> {
        return this.http.get(this.baseUrl + "/role/" + roleId, { headers: AuthService.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."))
    }
    edit(user: any): Observable<boolean> {
        return this.http.put(this.baseUrl + "/" + user.id, JSON.stringify(user), { headers: AuthService.credentialHeader() })
            .map(response => {
                if (response.ok) {
                    this.toaster.popAsync("success", "Successful", "Updated.")
                    return true;
                } else {
                    this.toaster.popAsync("error", "Error", "System has problem.")
                    return false;
                }
            })
            .catch(err =>
                this.toaster.popAsync("error", "Error", "System has problem."));
    }
    add(user: any): Observable<boolean> {
        return this.http.post(this.baseUrl, JSON.stringify(user), { headers: AuthService.credentialHeader() })
            .map(response => {
                if (response.ok) {
                    this.toaster.popAsync("success", "Successful", "Added.")
                    return true;
                } else {
                    this.toaster.popAsync("error", "Error", "System has problem.")
                    return false;
                }
            })
            .catch(err =>
                this.toaster.popAsync("error", "Error", "System has problem."));
    }
    remove(user: any): Observable<boolean> {
        return this.http.delete(this.baseUrl + "/" + user.id, { headers: AuthService.credentialHeader() })
            .map(response => {
                if (response.ok) {
                    this.toaster.popAsync("success", "Successful", "Removed.")
                    return true;
                } else {
                    this.toaster.popAsync("error", "Error", "System has problem.")
                    return false;
                }
            })
            .catch(err =>
                this.toaster.popAsync("error", "Error", "System has problem."));
    }

}