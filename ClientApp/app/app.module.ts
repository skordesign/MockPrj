import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { SignInUpComponent } from './components/signin-up/signin-up.component';
import { SignInUpService } from './services/signin-up.service';
import { FormsModule, NgForm } from '@angular/forms';
import { Logger } from 'log4ts';
import { HttpModule } from '@angular/http';
@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        SignInUpComponent
    ],
    imports: [
        HttpModule,
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'signin', component: SignInUpComponent },
            { path: 'signup', component: SignInUpComponent },
            { path: '**', redirectTo: 'signup' }
        ]),
        FormsModule
    ],
    providers:[ SignInUpService ]
})
export class AppModule {
}
