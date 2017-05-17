import { Component, OnInit, EventEmitter, ViewChild } from '@angular/core';
import { ProductService } from "../../../../services/products.service";
import { Router } from "@angular/router";
import { CategoryModel } from "./category.model";
import { CategoryService } from "../../../../services/category.service";
import { ToasterService } from "angular2-toaster/angular2-toaster";
import { CategoryDetailsComponent } from "./categorydetails/categorydetails.component";
@Component({
    selector: 'category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.css']
})


export class CategoryComponent implements OnInit {
    category: CategoryModel
    categories: any[]
    cate: any;
    cateFocus: any;
    isRemove: boolean;
    updateProduct = new EventEmitter<any>();
    @ViewChild(CategoryDetailsComponent) child: CategoryDetailsComponent
    ngOnInit(): void {
        this.getCategories();
    }
    updateData() {
        this.getCategories();
    }
    constructor(private _products: ProductService,
        private _categories: CategoryService,
        private _toast: ToasterService) { }
    getCategories() {
        this._categories.getCategories().subscribe(result => this.categories = result);
    }
    categoryDetail(cate: any) {
        this.cate = cate;
    }
    addCategoryModel() {
        this.category = new CategoryModel("", "");
        this.isRemove = true;
    }
    saveChanges(category: any) {
        if (this.isRemove) {
            console.log(category);
            this._categories.addCategory(category).subscribe(result => {
                if (result) {
                    this.getCategories();
                }
            })
        } else {
            this._categories.editCategory(category).subscribe(result => {
                if (result) {
                    this.getCategories();
                }
            })
        }
    }
    actionCate(action: any) {
        this.isRemove = action.isRemove;
        if (action.isRemove) {
            this.cateFocus = action.category;
            $('#centralModalWarning').modal('show');
        } else {
            this.category = action.category;
            $('#addCategoryModal').modal('show');
        }
    }
    removeCategory(cate: any) {
        this._categories.removeCategory(cate.id).subscribe(result => {
            if (result) {
                this.getCategories();
                this.child.getAllProducts();
            }
            return;
        })
    }
}

