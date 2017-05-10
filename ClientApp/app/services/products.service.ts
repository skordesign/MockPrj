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
export class ProductService {
    baseUrl: string = "/api/products";
    constructor(private http: Http, private toaster: ToasterService) {
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
    getByCategory(cateId: number): Observable<any[]> {
        return this.http.get(this.baseUrl + "/" + cateId + "/by-cate", { headers: AuthService.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."));
    }
    getProduct(id: number): Observable<any> {
        return this.http.get(this.baseUrl + "/" + id, { headers: AuthService.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."));
    }
    addProduct(product: any) {
        return this.http.post(this.baseUrl, JSON.stringify(product), { headers: AuthService.credentialHeader() })
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
    editProduct(product: any) {
        return this.http.put(this.baseUrl + "/" + product.id, JSON.stringify(product), { headers: AuthService.credentialHeader() })
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
    removeProduct(product: any) {
        return this.http.delete(this.baseUrl + "/" + product.id, { headers: AuthService.credentialHeader() })
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
    addCateGetId(category: any) {
        return this.http.post(this.baseUrl + "/add-cate-id", JSON.stringify(category), { headers: AuthService.credentialHeader() })
            .map(response => {
                if (response.ok) {
                    this.toaster.popAsync("success", "Successful", "Added.")
                    return response.json();
                } else {
                    this.toaster.popAsync("error", "Error", "System has problem.")
                    return {};
                }
            })
            .catch(err =>
                this.toaster.popAsync("error", "Error", "System has problem."));
    }
    getNumberProductOfCategory(id: number): Observable<number> {
        return this.http.get(this.baseUrl + "/count/" + id, { headers: AuthService.credentialHeader() })
            .map(this.extractData)
            .catch(err => this.toaster.popAsync("error", "Error", "System has problem."));
    }
}