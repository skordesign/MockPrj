import { Component, OnInit, AfterViewInit } from '@angular/core';
import { BillsService } from "../../../../services/bills.service";
import { UserMngtService } from "../../../../services/users.service";
import { Bill } from "./bill.model";
import { ToasterService } from "angular2-toaster/angular2-toaster";
import { BillDetails } from "./billdetails/billdetails.model";

@Component({
    selector: 'bill',
    templateUrl: './bill.component.html'
})

export class BillComponent implements OnInit, AfterViewInit {
    ngAfterViewInit(): void {
        if (typeof window !== "undefined") {
            var uid: number = + localStorage.getItem("uid");
            this.uid = + uid;
            if (uid != undefined) {
                this.getBills(uid);
            }
        }
    }
    bills: any[] = [];
    bill: any
    uid: number
    isView: boolean;
    isAdd: boolean;
    constructor(private _bills: BillsService, private _user: UserMngtService,
        private _toast: ToasterService) { }
    ngOnInit(): void {
    }
    getBills(uid: number) {
        this._user.getBills(uid).subscribe(result => this.bills = result);
    }
    addBillDialog() {
        this.isAdd = true;
        this.isView = false;
        this.bill = new Bill("New bill description", [new BillDetails()]);
    }
    info(bill: any) {
        this.isAdd = false;
        this.isView = true;
        this.bill = bill;
    }
    deal(bill: any) {
        bill.isDealt = true;
        this._bills.editBill(bill).subscribe(result => {
            if (result) {
                this._toast.popAsync("success", "Bill", "Updated.")
                this.getBills(this.uid);
            }
        })
    }
    edit(bill: any) {
        this.isAdd = false;
        this.isView = false;
        this.bill = bill as Bill;
    }
    updateData($event) {
        if (typeof window !== "undefined") {
            var uid: number = + localStorage.getItem("uid");
            this.uid = + uid;
            if (uid != undefined) {
                this.getBills(uid);
            }
        }
    }
}
