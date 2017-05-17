import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../../services/products.service";

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})


export class DashboardComponent implements OnInit{
    ngOnInit(): void {
        this.getNewProducts();
    }
    topFiveProducts: any[]
    constructor(private _products: ProductService) { }
    getNewProducts() {
        this._products.getNews().subscribe(result => this.topFiveProducts = result);
    }
}