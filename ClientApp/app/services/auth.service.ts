import { Injectable } from '@angular/core';
import { TokenProvider } from '../components/signin/signin.model';
import { Router } from '@angular/router';
import { Headers } from '@angular/http';
import { JwtHelper } from "angular2-jwt/angular2-jwt";
import { ToasterService } from "angular2-toaster/src/toaster.service";

@Injectable()
export class AuthService {
    constructor(private router: Router, private toaster: ToasterService) {
    }
    credentialHeaderForLogin(): Headers {
        var headers = new Headers();
        var jwt = new JwtHelper();
        var token = JSON.parse(localStorage.getItem("token"));
        if (token) {
            if (jwt.isTokenExpired(token)) {
                this.router.navigate(["/signin"]);
            }
            else {
                headers.append("Authorization", "Bearer " + token);
            }
        }
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return headers;
    }
    credentialHeader(): Headers {
        var headers = new Headers();
        var jwt = new JwtHelper();
        var token = JSON.parse(localStorage.getItem("token"));
        if (token) {
            if (jwt.isTokenExpired(token)) {
                this.router.navigate(["/signin"]);
            }
            else {
                headers.append("Authorization", "Bearer " + token);
            }
        }
        headers.append('Content-Type', 'application/json');
        return headers;
    }
    getRole() {
        var jwt = new JwtHelper();
        var token = localStorage.getItem('token');
        if (token) {
            var roleJson = jwt.decodeToken(token);
            var role = roleJson.roleSIMS;
            return role;
        }
        return null;
    }
}