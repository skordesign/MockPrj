import { Component, Input, OnInit, OnDestroy, OnChanges, EventEmitter, Output } from '@angular/core';
import { Bill } from "../bill.model";
import { BillsService } from "../../../../../services/bills.service";
import { Subscription } from "rxjs/Subscription";
import { BillDetails } from "./billdetails.model";
import { ProductService } from "../../../../../services/products.service";
import { BillDetailsService } from "../../../../../services/billDetails.service";

@Component({
    selector: 'bill-details',
    templateUrl: './billdetails.component.html'
})

export class BillDetailsComponent implements OnInit {
    ngOnInit(): void {
        this.getBill(this.bill.id);
    }
    constructor(private _bills: BillsService, private _products: ProductService,
        private _billDetails: BillDetailsService) { }
    @Input() bill: Bill
    @Input() isView: boolean;
    @Input() isAdd: boolean;
    @Output() updateData = new EventEmitter<any>()
    getBill(id: number) {
        if (id) {
            this._bills.getBill(this.bill.id).subscribe(result => {
                this.bill.billDetailses = result.billDetailses;
            });
        }
    }
    addItem() {
        this.bill.addBillDetails(new BillDetails());
    }
    saveChanges() {
        if (this.isAdd) {
            this.isAdd = false;
            this.isView = false;
            var billDt = this.bill;
            var billDt2 = this.bill.billDetailses;
            billDt.billDetailses = null;
            billDt.accountId = + localStorage.getItem('uid');
            this._bills.addBill(billDt).subscribe(result => {
                if (result) {
                    billDt2.forEach(one => {
                        one.billId = result;
                    });
                }
            }, err => err, () => {
                billDt2.forEach(one => {
                    one.productId = + one.productId;
                    this._billDetails.addBillDetails(one).subscribe(result => {
                        if (result) {
                            this.updateData.emit();
                        }
                    })
                })
            });
        } else {
            console.log(this.bill);
        }
    }
    billDetailsUpdate($event) {
        this.bill.total = 0;
        this.bill.billDetailses.forEach(one => {
            if (one.productId) {
                this._products.getProduct(one.productId).subscribe(result => {
                    this.bill.total = this.bill.total + (result.price * one.quantity);
                })
            }
        });
    }
}
