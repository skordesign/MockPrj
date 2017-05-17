import { Injectable } from '@angular/core';
import { TokenProvider } from '../components/signin/signin.model';
import { Router } from '@angular/router';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { ToasterService } from 'angular2-toaster';
import { URLSearchParams, Response, Http, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { AuthService } from "./auth.service";

@Injectable()
export class BillsService {
    baseUrl: string = "/api/bills/"
    constructor(private http: Http, private toaster: ToasterService, private _auth: AuthService) {
    }
    getAll() {
        return this.http.get(this.baseUrl + "news", { headers: this._auth.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."));
    }
    addBill(bill: any) {
        return this.http.post(this.baseUrl, JSON.stringify(bill), { headers: this._auth.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."))
    }
    getBill(id:number){
        return this.http.get(this.baseUrl + id, { headers: this._auth.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."));
    }
    editBill(bill: any):Observable<boolean> {
        return this.http.put(this.baseUrl + bill.id, JSON.stringify(bill), { headers: this._auth.credentialHeader() })
            .map(response => {
                if(response.ok){
                    return true;
                }
                return false;
            })
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."))
    }
    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
}