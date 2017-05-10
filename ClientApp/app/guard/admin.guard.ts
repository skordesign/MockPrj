import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { JwtHelper } from 'angular2-jwt';
import { ToasterService } from 'angular2-toaster';
@Injectable()
export class AdminGuard implements CanActivate {

    constructor(private router: Router, private toaster:ToasterService) { }

    public canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (typeof window !== "undefined") {
            var jwt = new JwtHelper();
            var token = localStorage.getItem('token');
            if (token) {
                if (jwt.isTokenExpired(token)) {
                    this.router.navigate(["/signin"]);
                    return false;
                }
                var roleJson = jwt.decodeToken(token);
                var role = roleJson.roleSIMS;
                if (role === "Administrator") {
                      this.toaster.popAsync("success", "Information", "Access accepted.");
                    return true;
                }
                this.toaster.popAsync("warning", "Warning!!", "Access denied!");
                this.router.navigate([""]);
                return false;
            }
            this.router.navigate(["/signin"]);
            return false;
        }
    }
}