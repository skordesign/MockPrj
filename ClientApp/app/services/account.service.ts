import { Injectable } from '@angular/core';
import { TokenProvider } from '../components/signin/signin.model';
import { Router } from '@angular/router';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { ToasterService } from 'angular2-toaster';
import { URLSearchParams, Response, Http, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { AuthService } from './auth.service';

@Injectable()
export class AccountService {
    baseUrl: string = "/api/accounts"
    constructor(private http: Http, private toaster: ToasterService, private _auth:AuthService) {
    }
    getInfo(uid: any): Observable<any> {
        return this.http.get(this.baseUrl + '/getInfo/' + uid, { headers: this._auth.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync('error', "Get Info", "Failed!"));
    }

    editInfo(user: any): Observable<boolean> {
        return this.http.put(this.baseUrl + '/edit/' + user.id, JSON.stringify(user),
         { headers: this._auth.credentialHeader() })
            .map(response => {
                if (response.ok) {
                    this.toaster.pop("success", "Information", "Updated");
                    return true;
                } else {
                    this.toaster.popAsync('error', "Get Info", "Failed!")
                    return false;
                }
            })
            .catch(err => this.toaster.popAsync('error', "Get Info", "Failed!"));
    }
    changPwd(user: any): Observable<boolean> {
        return this.http.put(this.baseUrl + '/ChangePwd/' + user.id, JSON.stringify(user),
         { headers: this._auth.credentialHeader() })
            .map(response => {
                if (response.ok) {
                    this.toaster.pop("success", "Information", "Updated");
                    return true;
                } else {
                    this.toaster.popAsync('error', "Get Info", "Failed!")
                    return false;
                }
            })
            .catch(err => this.toaster.popAsync('error', "Get Info", "Failed!"));
    }
    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
    getRole(roleId: number): Observable<any> {
        return this.http.get(this.baseUrl + "/getRole/" + roleId, { headers: this._auth.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."))
    }
}