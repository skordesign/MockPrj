import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Router } from "@angular/router";
import { ProductService } from "../../../../../services/products.service";
import { CategoryService } from "../../../../../services/category.service";
@Component({
    selector: 'category-card',
    templateUrl: './categorycard.component.html'
})
export class CategoryCardComponent {
    color = [
        'indigo accent-2', 'indigo', 'purple', 'red', 'green', 'yellow',
        'orange', 'cyan', 'purple darken-4', 'blue lighten-4',
        'deep-purple', 'blue', 'teal darken-2',
        'cyan accent-3'
    ]
    constructor(private _product: ProductService, private _categories: CategoryService) { }
    
    @Input() category: any
    @Output() public cateDetails = new EventEmitter<any>();
    @Output() public actionCate = new EventEmitter<any>();
    categoryDetail(category: any) {
        this.cateDetails.emit(category);
    }
    removeCate(category: any) {
        let action = {
            category: category,
            isRemove: true
        }
        this.actionCate.emit(action);
    }
    editCate(category: any) {
        let action = {
            category: category,
            isRemove: false
        }
        this.actionCate.emit(action);
    }
}