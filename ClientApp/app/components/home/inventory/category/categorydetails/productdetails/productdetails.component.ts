import { Component, OnInit, OnDestroy, Input, AfterViewInit, OnChanges, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { ProductService } from "../../../../../../services/products.service";
import { ToasterService } from "angular2-toaster/angular2-toaster";
import { CategoryService } from "../../../../../../services/category.service";
@Component({
    selector: 'product-detail',
    templateUrl: './productdetails.component.html'
})


export class ProductDetailsComponent implements OnInit, OnDestroy, AfterViewInit, OnChanges {
    ngOnChanges(changes: any): void {
        if (typeof window !== "undefined") {
            if (this.isAdd !== undefined && !this.isAdd) {
                $(document).ready(function () {
                    $('.mdb-select').material_select('destroy');
                    $('.mdb-select').material_select();
                });
            }
            else {
                if (this.statesCate != undefined && this.statesCate.length > 0) {
                    $('.mdb-autocomplete').mdb_autocomplete({
                        data: this.statesCate
                    });
                }
            }
        }
    }
    ngAfterViewInit(): void {

    }
    loadCate() {
        for (let item in this.optionsCate) {
            this.statesCate.push(this.optionsCate[item].name);
        }
        if (this.statesCate != undefined && this.statesCate.length > 0) {
            $('.mdb-autocomplete').mdb_autocomplete({
                data: this.statesCate
            });
        }
    }
    statesCate: string[] = [];
    @Input() product: any;
    @Input() isView: boolean;
    @Input() isAdd: boolean;
    @Input() cateName: string;
    @Output() public updateEvent = new EventEmitter<any>();

    optionsCate: any[]

    constructor(private _product: ProductService,
     private toaster: ToasterService,
     private _categories:CategoryService) { }

    ngOnInit() {
        this.getCategories();
    }
    ngOnDestroy() {
    }
    getCategories() {
        this._categories.getCategories().subscribe(result => {
            this.optionsCate = result;
            if (this.optionsCate.length > 0) {
                this.loadCate()
            }
        },
            error => this.toaster.popAsync("error", "Error", "System has problem."));
    }
    saveChanges() {
        if (this.isAdd) {
            if ($('#cateAutocomplete').val() != null) {
                var nameCate = $('#cateAutocomplete').val();
                var cate = this.optionsCate.filter(cat => cat.name === nameCate.trim());
                if (cate.length > 0) {
                    this.product.categoryId = cate[0].id;
                    this._product.addProduct(this.product).subscribe(result => {
                        if (result) {
                            this.updateEvent.emit();
                        }
                    });
                } else {
                    this._product.addCateGetId({ "name": nameCate, "description": "Not have description" })
                        .subscribe(result => {
                            this.product.categoryId = +result;
                            this._product.addProduct(this.product).subscribe(result => {
                                if (result) {
                                    this.updateEvent.emit();
                                }
                            });
                        })
                }
            }
        } else {
            if ($('#cateSelector').val() != null) {
                this.product.categoryId = $('#cateSelector').val();
            }
            this._product.editProduct(this.product).subscribe(result => {
                if (result) {
                    this.updateEvent.emit();
                }
            });
        }
    }
}

