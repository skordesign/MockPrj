import { BillDetails } from "./billdetails/billdetails.model";

export class Bill {
    id: number
    description:string
    total:number
    isDealt:boolean
    billDetailses: BillDetails[]=[]
    accountId:number;
    constructor(description:string=null, bdetails: BillDetails[] = null) {
        this.billDetailses = bdetails || [new BillDetails()];
        this.description = description || "";
        this.total = 0;
        this.isDealt = false;
    }
    addBillDetails(bdetail: BillDetails) {
        this.billDetailses.push(bdetail);
    }
}