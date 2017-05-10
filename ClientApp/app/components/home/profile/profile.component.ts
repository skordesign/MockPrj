import { Component, Input, OnInit, AfterViewInit, OnDestroy, OnChanges } from '@angular/core';
import { AccountService } from "../../../services/account.service";

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
    styleUrls: ['./profile.component.css']
})


export class ProfileComponent implements OnInit, AfterViewInit, OnChanges, OnDestroy {
    ngOnChanges(changes: any): void {
    }
    ngOnDestroy(): void {

    }
    ngAfterViewInit(): void {
        this.getRole(this.user.roleId);
    }
    ngOnInit(): void {
        this.getRole(this.user.roleId);
    }
    role: any
    @Input() user: any

    constructor(private _account: AccountService) { }
    getRole(id) {
        this._account.getRole(id).subscribe(result => this.role = result.name);
    }
    saveChanges() {
        this._account.editInfo(this.user).subscribe(result => {
            if(result){
                
            }
        })
    }
}