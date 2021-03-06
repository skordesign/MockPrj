import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { JwtHelper } from 'angular2-jwt';

@Injectable()
export class LoginGuard implements CanActivate {

    constructor(private router: Router) { }

    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (typeof window !== "undefined") {
            var jwt = new JwtHelper();
            var token = localStorage.getItem('token');
            if (token) {
                if (jwt.isTokenExpired(token)) {
                    return true;
                }
                this.router.navigate([""]);
                return false;
            }
            return true;
        }
    }
}