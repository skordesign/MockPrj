import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Router } from "@angular/router";
import { ProductService } from "../../../../../services/products.service";
@Component({
    selector: 'category-card',
    templateUrl: './categorycard.component.html'
})
export class CategoryCardComponent implements OnInit {
    color = [
        'indigo accent-2', 'indigo', 'purple', 'red', 'green', 'yellow',
        'orange', 'cyan', 'purple darken-4', 'blue lighten-4',
        'deep-purple', 'blue', 'teal darken-2',
        'cyan accent-3'
    ]
    constructor(private _product: ProductService) { }
    ngOnInit(): void {
        this.getNumberProOfCate(this.category.id);
    }
    @Input() category: any
    @Output() public cateDetails = new EventEmitter<any>();
    numberProduct: number
    getNumberProOfCate(id: any) {
        this._product.getNumberProductOfCategory(id).subscribe(result => this.numberProduct = + result || 0)
    }
    categoryDetail(category: any) {
        this.cateDetails.emit(category);
    }
    removeCate(category:any) {

    }
    editCate(category:any){

    }
}