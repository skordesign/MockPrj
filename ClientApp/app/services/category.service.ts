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
export class CategoryService {
    baseUrl: string = "/api/categories"
    constructor(private http: Http, private toaster: ToasterService) {
    }
    getCategories(): Observable<any[]> {
        return this.http.get(this.baseUrl, { headers: AuthService.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."));
    }
    addCategory(category: any) {
        return this.http.post(this.baseUrl, JSON.stringify(category), { headers: AuthService.credentialHeader() })
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
    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
}