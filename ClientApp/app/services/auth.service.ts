import { Injectable } from '@angular/core';
import { TokenProvider } from '../components/signin/signin.model';
import { Router } from '@angular/router';
import { Headers } from '@angular/http';

@Injectable()
export class AuthService {
    // baseUrl: string = "/api/usermngt"
    static credentialHeaderForLogin(): Headers {
        var headers = new Headers();
        var token = JSON.parse(localStorage.getItem("token"));
        if (token) {
            headers.append("Authorization", "Bearer " + token);
        }
        headers.append('Content-Type', 'application/x-www-form-urlencoded');
        return headers;
    }
    static credentialHeader(): Headers {
        var headers = new Headers();
        var token = JSON.parse(localStorage.getItem("token"));
        if (token) {
            headers.append("Authorization", "Bearer " + token);
        }
        headers.append('Content-Type', 'application/json');
        return headers;
    }
}