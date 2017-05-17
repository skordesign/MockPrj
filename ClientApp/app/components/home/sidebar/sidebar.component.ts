import { Component, AfterViewInit, AfterViewChecked, OnInit } from '@angular/core';
import { SignInService } from '../../../services/signin.service';
import * as $ from 'jquery';
import { UserModel } from "../usermngt/usermngt.model";
import { AccountService } from "../../../services/account.service";
import { ToasterService } from "angular2-toaster/angular2-toaster";
import { AuthService } from "../../../services/auth.service";

@Component({
    selector: 'sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.css']
})


export class SidebarComponent implements OnInit {

    items: any[]
    user: any
    breadcrumb: string = " -- Welcome to SIMS -- ";
    constructor(private signInService: SignInService,
        private _account: AccountService,
        private _toaster: ToasterService,
        private _auth: AuthService) { }
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
            this.getItems();
        }
    }

    logout() {
        this.signInService.signOut();
    }
    getItems() {
        this.items = [
            { path: '/dashboard', title: 'Dashboard', icon: "fa fa-area-chart", child: [] },
            {
                path: '/inventory', title: "Inventory", icon: "fa fa-industry", child: [
                    { path: "categories", title: "Categories", child: [] },
                    { path: "receipts", title: "Receipts Note", child: [] },
                    { path: "deliveries", title: "Deliveries Note", child: [] }
                ]
            },
            {
                path: "/sale", title: "Sale Management", icon: "fa fa-bars", child: [
                    { path: "bills", title: "Bills", child: [] }
                ]
            },
            { path: "/usermngt", title: "User Management", icon: "fa fa-user", child: [] },
            { path: "/reports", title: "Reports", icon: "fa fa-wpforms", child: [] }
        ];
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
    linkC(item: string, children: string) {
        this.breadcrumb = " > " + item.toString() + " > " + children.toString();
    }

    linkP(item: string) {
        this.breadcrumb = " > " + item.toString()
    }
}



