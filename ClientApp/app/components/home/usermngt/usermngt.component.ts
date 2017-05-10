import { Component, OnInit, Directive, ViewContainerRef, ComponentFactoryResolver, AfterViewInit } from '@angular/core';
import { UserMngtService } from '../../../services/usermngt.service';
import { ToasterService } from 'angular2-toaster';
import { UserModel } from './usermngt.model';
import { } from '@angular/compiler';
@Component({
    selector: 'user-mngt',
    templateUrl: './usermngt.component.html',
    styleUrls: ['./usermngt.component.css'],
})

export class UserMngtComponent implements OnInit {

    users: any[];
    userSelected: any;
    isView: boolean = true;
    userFocus: any;
    isAdd: boolean = false;
    isRemove: boolean = false;


    constructor(private usermngt: UserMngtService, private toaster: ToasterService) {
    }
    ngOnInit() {
        this.getAllAccount();
    }
    getAllAccount() {
        this.usermngt.getAll()
            .subscribe(
            result => this.users = result,
            error => this.toaster.popAsync("error", "Error", "System has problem."));
    }
    edit(user: any) {
        this.userSelected = user;
        this.isView = false;
        this.isAdd = false;
    }
    info(user: any) {
        this.userSelected = user;
        this.isView = true;
        this.isAdd = false;
    }
    active(user: any) {
        user.isBlocked = !user.isBlocked;
        this.usermngt.edit(user).subscribe(result => result);
    }
    block(userFocus: any) {
        userFocus.isBlocked = !userFocus.isBlocked;
        this.usermngt.edit(userFocus).subscribe(result => result);
    }
    showModalBlock(user: any, isRemove: boolean) {
        this.isRemove = isRemove;
        this.userFocus = user;
    }
    adduserDialog() {
        this.isView = false;
        this.isAdd = true;
        this.userSelected = new UserModel("", "", "", "", 1);
    }
    remove(userFocus: any) {
        this.usermngt.remove(userFocus).subscribe(result => {
            if (result) {
                this.getAllAccount();
            }
        });
    }
    updateDate() {
        this.getAllAccount();
    }
}
