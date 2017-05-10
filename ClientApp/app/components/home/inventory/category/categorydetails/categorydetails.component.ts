import { Component, OnInit, OnDestroy, Input, OnChanges, EventEmitter, Output } from '@angular/core';
import { ProductService } from "../../../../../services/products.service";
import { ActivatedRoute } from "@angular/router";
import { ProductModel } from "./product.model";
@Component({
    selector: 'category-detail',
    templateUrl: './categorydetails.component.html'
})


export class CategoryDetailsComponent implements OnInit, OnDestroy, OnChanges {
    ngOnChanges(changes: any): void {
        this.getProductsByCate(this.cate.id);
    }
    @Input() cate: any;
    products: any[]
    productSelected: any
    isView: boolean;
    isAdd: boolean;
    productFocus: any;
    @Output() public updateEvent = new EventEmitter<any>();
    constructor(private route: ActivatedRoute, private _product: ProductService) { }

    ngOnInit() {
        this.getProductsByCate(this.cate.id);
    }
    ngOnDestroy() {

    }
    getProductsByCate(cateId: any) {
        this._product.getByCategory(cateId).subscribe(result => this.products = result);
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
        this.productSelected = new ProductModel("", "", this.cate.id);
        this.isView = false;
        this.isAdd = true;
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
        this.getProductsByCate(this.cate.id);
        this.updateEvent.emit();
    }
}

