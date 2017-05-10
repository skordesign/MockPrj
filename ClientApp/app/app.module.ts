import { NgModule, ModuleWithProviders } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { HomeComponent } from './components/home/home.component';
import { SignInComponent } from './components/signin/signin.component';
import { DashboardComponent } from './components/home/dashboard/dashboard.component';
import { ForgetPwdComponent } from './components/forgetpwd/forgetpwd.component';
import { CategoryComponent } from './components/home/inventory/category/category.component';
import { SignInService } from './services/signin.service';
import { FormsModule, NgForm, ReactiveFormsModule } from '@angular/forms';
import { Logger } from 'log4ts';
import { HttpModule } from '@angular/http';
import { ProfileComponent } from './components/home/profile/profile.component';
import { SidebarComponent } from './components/home/sidebar/sidebar.component';
import { ReporttComponent } from './components/home/inventory/report/report.component';
import { ToasterModule, ToasterService } from 'angular2-toaster';
import { routing } from './app.routes';
import { UserMngtComponent } from './components/home/usermngt/usermngt.component';
import { AuthenticateGuard } from './guard/authenticate.guard';
import { LoginGuard } from './guard/login.guard';
import { AuthModule } from './auth.module';
import { AdminGuard } from './guard/admin.guard';
import { UserMngtService } from './services/usermngt.service';
import { UserDetailComponent } from './components/home/usermngt/userdetail/userdetail.component';
import { ProductService } from "./services/products.service";
import { CategoryDetailsComponent } from "./components/home/inventory/category/categorydetails/categorydetails.component";
import { ProductDetailsComponent } from "./components/home/inventory/category/categorydetails/productdetails/productdetails.component";
import { AccountService } from "./services/account.service";
import { CategoryCardComponent } from "./components/home/inventory/category/categorycard/categorycard.component";
import { SaleComponent } from "./components/home/sale/sale.component";
import { CategoryService } from "./services/category.service";

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        HomeComponent,
        ReporttComponent,
        CategoryComponent,
        UserMngtComponent,
        SignInComponent,
        ForgetPwdComponent,
        DashboardComponent,
        SidebarComponent,
        ProfileComponent,
        UserDetailComponent,
        CategoryDetailsComponent,
        ProductDetailsComponent,
        CategoryCardComponent,
        SaleComponent
    ],
    imports: [
        HttpModule,
        ToasterModule,
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        routing,
        FormsModule,
        AuthModule,
        ReactiveFormsModule 
    ],
    providers: [
        SignInService,
        ToasterService,
        AuthenticateGuard,
        LoginGuard,
        AccountService,
        AdminGuard,
        ProductService,
        CategoryService,
        UserMngtService],
})

export class AppModule {
}
