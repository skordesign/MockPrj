import { Component, OnInit, OnDestroy, Input, OnChanges, EventEmitter, Output } from '@angular/core';
import { ProductService } from "../../../../../services/products.service";
import { ActivatedRoute } from "@angular/router";
import { ProductModel } from "./product.model";
import { CategoryService } from "../../../../../services/category.service";
import { JwtHelper } from "angular2-jwt/angular2-jwt";
@Component({
    selector: 'category-detail',
    templateUrl: './categorydetails.component.html'
})


export class CategoryDetailsComponent implements OnInit, OnDestroy, OnChanges {
    ngOnChanges(changes: any): void {
        if (this.cate != undefined) {
            this.getProductsByCate(this.cate.id);
        } else {
            this.getAllProducts();
        }
    }
    @Input() cate: any;
    products: any[]
    productSelected: any
    isView: boolean;
    isAdd: boolean;
    productFocus: any;
    role:string;
    @Output() public updateEvent = new EventEmitter<any>();
    constructor(private route: ActivatedRoute, private _product: ProductService, private _categories: CategoryService) { }

    ngOnInit() {
        if (this.cate != undefined) {
            this.getProductsByCate(this.cate.id);
        } else {
            this.getAllProducts();
        }
        if(typeof window !== "undefined"){
            var jwt = new JwtHelper();
            var token = jwt.decodeToken(localStorage.getItem('token'))
            this.role = token.roleSIMS;
        }
    }
    ngOnDestroy() {

    }
    getProductsByCate(cateId: any) {
        this._categories.getProducts(cateId).subscribe(result => this.products = result);
    }
    getAllProducts() {
        this._product.getAll().subscribe(result => this.products = result);
    }
    viewProduct(product: any) {
        this.productSelected = product;
        this.isView = true;
        this.isAdd = false;
    }
    editProduct(product: any) {
        this.productSelected = product;
        this.isView = false;
        this.isAdd = false;
    }
    addProduct() {
        if (this.cate) {
            this.productSelected = new ProductModel("", "", this.cate.id);
            this.isView = false;
            this.isAdd = true;
        } else {
            this.productSelected = new ProductModel("", "", null);
            this.isView = false;
            this.isAdd = true;
        }
    }
    removeProduct(product: any) {
        this._product.removeProduct(product).subscribe(result => {
            if (result) {
                this.getProductsByCate(this.cate.id);
            }
        })
    }
    removeProductDialog(product: any) {
        this.productFocus = product;
    }
    updateData() {
        if(this.cate){
            this.getProductsByCate(this.cate.id);
        }
        else{
             this.getAllProducts();
        }
        this.updateEvent.emit();
    }
}

