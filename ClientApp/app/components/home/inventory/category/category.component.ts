import { Component, OnInit } from '@angular/core';
import { ProductService } from "../../../../services/products.service";
import { Router } from "@angular/router";
import { CategoryModel } from "./category.model";
import { CategoryService } from "../../../../services/category.service";
@Component({
    selector: 'category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.css']
})


export class CategoryComponent implements OnInit {
    category: CategoryModel
    categories: any[]
    cate: any;
    ngOnInit(): void {
        this.getCategories();
    }
    updateData() {
        this.getCategories();
    }
    constructor(private _products: ProductService,
        private _categories: CategoryService) { }
    getCategories() {
        this._categories.getCategories().subscribe(result => this.categories = result);
    }
    categoryDetail(cate: any) {
        this.cate = cate;
    }
    addCategoryModel() {
        this.category = new CategoryModel("", "");
    }
    saveChanges(category: any) {
        this._categories.addCategory(category).subscribe(result => {
            if (result) {
                this.getCategories();
            }
        })
    }
}

