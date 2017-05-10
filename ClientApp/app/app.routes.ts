import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './components/home/home.component';
import { DashboardComponent } from './components/home/dashboard/dashboard.component';
import { SignInComponent } from './components/signin/signin.component';
import { ForgetPwdComponent } from './components/forgetpwd/forgetpwd.component';
import { CategoryComponent } from './components/home/inventory/category/category.component';
import { ReporttComponent } from './components/home/inventory/report/report.component';
import { UserMngtComponent } from './components/home/usermngt/usermngt.component';
import { AuthenticateGuard } from './guard/authenticate.guard';
import { LoginGuard } from './guard/login.guard';
import { AdminGuard } from './guard/admin.guard';
import { CategoryDetailsComponent } from "./components/home/inventory/category/categorydetails/categorydetails.component";
import { SaleComponent } from "./components/home/sale/sale.component";
export const routes: Routes = [
    { path: "signin", component: SignInComponent, canActivate: [LoginGuard] },
    { path: "forgetpwd", component: ForgetPwdComponent, canActivate: [LoginGuard] },
    {
        path: "",
        component: HomeComponent,
        canActivate: [AuthenticateGuard],
        children: [
            { path: "", redirectTo: "dashboard", pathMatch: "full" },
            { path: "dashboard", component: DashboardComponent },
            {
                path: "inventory", children: [
                    { path: "", redirectTo: "categories", pathMatch: "full" },
                    { path: "categories", component: CategoryComponent },
                    { path: 'categorydetails/:id', component: CategoryDetailsComponent },
                    { path: "reports", component: ReporttComponent }
                ]
            },
            { path: "sale", component: SaleComponent, canActivate: [AuthenticateGuard], children: [] },
            { path: "usermngt", component: UserMngtComponent, canActivate: [AdminGuard, AuthenticateGuard], children: [] }
        ]
    },
]

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);