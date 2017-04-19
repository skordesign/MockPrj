import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SignInVM, SignUpVM } from './signin-up.model';
import { SignInUpService } from '../../services/signin-up.service';
@Component({
    selector: 'signin-up',
    templateUrl: './signin-up.component.html',
    styleUrls: ['./signin-up.component.css']
})
    
export class SignInUpComponent {
    signInDisplayed: boolean = true;
    signInShow :string;
    signInHide: string;
    constructor(private service : SignInUpService) {
        this.signInDisplayed = true;
        this.signInShow = "tab active";
        this.signInHide = "tab";
    }
    signInView() {
        this.signInDisplayed = true;
        this.signInShow = "tab active";
        this.signInHide = "tab";
    }
    signUpView() {
        this.signInDisplayed = false;
        this.signInShow = "tab";
        this.signInHide = "tab active";
    }
    signIn(form: NgForm) {
        if (form.valid) {
            let model: SignInVM = form.value as SignInVM;
            this.service.signInService(model);
        }
    }
    signUp(form: NgForm) {
        if (form.valid) {
            let model: SignUpVM = form.value;
            console.log("Sign Up");
            this.service.signUpService(model);
        }
    }
}

