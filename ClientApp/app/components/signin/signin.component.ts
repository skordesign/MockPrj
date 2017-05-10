import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SignInVM } from './signin.model';
import { SignInService } from '../../services/signin.service';
import { Router } from '@angular/router';
import * as $ from 'jquery';
@Component({
    selector: 'signin',
    templateUrl: './signin.component.html',
    styleUrls: ['./signin.component.css']
})

export class SignInComponent {

    constructor(private service: SignInService, private router: Router) {
    }
    signIn(form: NgForm) {
        if (form.valid) {
            let model: SignInVM = form.value as SignInVM;
            this.service.signInService(model);
        }
    }
}
// if (typeof window !== "undefined") {
//     window.onload = () => {
//         $(document).ready(() => {
//             $(".login-help").click(() => {
//                 alert('Test Jquery in TS');
//             });
//         });
//     }
// }

