import { Component } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})

export class HomeComponent {

}

export const routes: any = [
    { path: '/dashboard', title: 'Dashboard',icon:"fa fa-area-chart", child: [] },
    {
        path: '/inventory', title: "Inventory",icon:"fa fa-industry", child: [
            { path: "/categories", title: "Categories", child: [] },
            { path: "/reports", title: "Reports", child: [] }
        ]
    },
    { path: "/sale", title: "Sale Management",icon:"fa fa-bars", child: [] },
    { path: "/usermngt", title: "User Management",icon:"fa fa-user", child: [] },
    { path: "/profile", title: "Profiles",icon:"fa fa-info-circle", child: [] }
]


