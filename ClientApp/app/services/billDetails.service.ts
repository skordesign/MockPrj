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
export class BillDetailsService {
    baseUrl: string = "/api/billDetails/"
    constructor(private http: Http, private toaster: ToasterService, private _auth: AuthService) {
    }
    addBillDetails(billDetails: any):Observable<boolean> {
        return this.http.post(this.baseUrl, JSON.stringify(billDetails), { headers: this._auth.credentialHeader() })
            .map(response=>{
                if(response.ok){
                    this.toaster.popAsync('success', "Success", "Added.")
                    return true;
                }
                return false;
            })
            .catch(err => this.toaster.popAsync('error', "Error", "System has problem."))
    }
    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
}