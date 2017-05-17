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
    pwdModel: any
    isChange: boolean = false
    constructor(private _account: AccountService) { }
    getRole(id) {
        this._account.getRole(id).subscribe(result => this.role = result.name);
    }
    saveChanges() {
        this._account.editInfo(this.user).subscribe(result => { });
    }
    cancel(){
        this.isChange = false;
        this.pwdModel = null;
    }
    changePwd() {
        this.pwdModel = {
            pwd: "",
            pwdRt: ""
        }
        this.isChange = true;
    }
    saveChangePwd(pwdModel: any) {
        if (pwdModel.pwd !== pwdModel.pwdRt) {
            return;
        } else {
            this.user.passwordHashed = pwdModel.pwd;
            this._account.changPwd(this.user).subscribe(result => {
                if(result){
                    this.isChange = false;
                }
            });
        }
    }
}