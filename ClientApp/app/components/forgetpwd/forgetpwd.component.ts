import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SignInService } from '../../services/signin.service';
import { Router } from '@angular/router';

@Component({
    selector: 'forgetpwd',
    templateUrl: './forgetpwd.component.html',
    styleUrls: ['./forgetpwd.component.css']
})
export class ForgetPwdComponent {
    constructor(private service: SignInService, private router: Router) {
    }
    signIn(form: NgForm) {
        if (form.valid) {
            let model: string = form.value as string;
            this.service.forgetPassword(model);
        }
    }
}