import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { HomeComponent } from './components/home/home.component';
import { DashboardComponent } from './components/home/dashboard/dashboard.component';
import { SignInComponent } from './components/signin/signin.component';
import { ForgetPwdComponent } from './components/forgetpwd/forgetpwd.component';
import { CategoryComponent } from './components/home/inventory/category/category.component';
import { ReportComponent } from './components/home/report/report.component';
import { UserMngtComponent } from './components/home/usermngt/usermngt.component';
import { AuthenticateGuard } from './guard/authenticate.guard';
import { LoginGuard } from './guard/login.guard';
import { AdminGuard } from './guard/admin.guard';
import { CategoryDetailsComponent } from "./components/home/inventory/category/categorydetails/categorydetails.component";

import { BillComponent } from "./components/home/sale/bill/bill.component";
import { ReceiptComponent } from "./components/home/inventory/receipt/receipt.component";
import { DeliveryComponent } from "./components/home/inventory/delivery/delivery.component";
import { SalePersonGuard } from "./guard/saleperson.guard";
import { SaleMngrGuard } from "./guard/salemngr.guard";
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
                path: "inventory" , children: [
                    { path: "", redirectTo: "categories", pathMatch: "full" },
                    { path: "categories", component: CategoryComponent, canActivate:[AuthenticateGuard] },
                    { path: 'categorydetails/:id', component: CategoryDetailsComponent },
                    { path: "receipts", component: ReceiptComponent },
                    { path: "deliveries", component: DeliveryComponent },
                ]
            },
            { path: "reports", component: ReportComponent, canActivate: [AuthenticateGuard] },
            {
                path: "sale", canActivate: [AuthenticateGuard, SalePersonGuard], children: [
                    { path: "", redirectTo: "bill", pathMatch: "full" },
                    { path: "bills", component: BillComponent },
                ]
            },
            { path: "usermngt", component: UserMngtComponent, canActivate: [AuthenticateGuard, AdminGuard], children: [] }
        ]
    },
    { path: "**", redirectTo: "" }
]

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);