import { Component, Input, OnInit, OnChanges, Output, EventEmitter } from '@angular/core';
import { ProductService } from "../../../../../services/products.service";
import { BillDetails } from "../billdetails/billdetails.model";

@Component({
    selector: 'li[bill-card]',
    templateUrl: './billcard.component.html',
    styleUrls: ['./billcard.component.css']
})

export class BillCardComponent implements OnInit {
    constructor(private _products: ProductService) { }
    ngOnInit(): void {
        if (!this.isView) {
            this.getProducts();
        }
    }
    getProducts() {
        this._products.getAll().subscribe(result => this.products = result);
    }
    @Output() billDetailsUpdate = new EventEmitter<any>();
    products: any[]
    @Input() billDetails: BillDetails
    @Input() billDetailsView: any
    @Input() isView: boolean ;
    @Input() index: number
    @Input() isAdd: boolean;

    updateBillDetails($event) {
        this.billDetailsUpdate.emit();
    }
}
