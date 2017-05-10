import { Component, AfterViewInit, AfterViewChecked, OnInit } from '@angular/core';
import { routes } from '../home.component';
import { SignInService } from '../../../services/signin.service';
import * as $ from 'jquery';
import { UserModel } from "../usermngt/usermngt.model";
import { AccountService } from "../../../services/account.service";
import { ToasterService } from "angular2-toaster/angular2-toaster";

@Component({
    selector: 'sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.css']
})


export class SidebarComponent implements OnInit {
    items: any = routes;
    user: any

    constructor(private signInService: SignInService, private _account: AccountService,
        private _toaster: ToasterService) { }
    ngOnInit() {
        if (typeof window !== "undefined") {
            $(document).ready(() => {
                $.getScript('./js/Site.js');
            })
            var uid: number = + localStorage.getItem("uid");
            if (uid !== undefined) {
                this.getUserInfo(uid);
            }
            else {
                this._toaster.popAsync("error", "Error", "Something was wrong");
            }
        }
    }
    logout() {
        this.signInService.signOut();
    }
    settings() {
        if (typeof window !== "undefined") {
            if (localStorage.getItem("uid")) {
                this.getUserInfo(localStorage.getItem("uid"));
            }
            else {
                this._toaster.popAsync("error", "Error", "Something was wrong");
            }
        }
    }
    getUserInfo(uid: any) {
        this._account.getInfo(uid).subscribe(result => this.user = result);
    }
}



