export class BillDetails {
    billId: number
    productId: number
    quantity: number = 100;
    constructor(billId: number = null, productId: number = null, quantity: number = null) {
        this.billId = billId || null;
        this.productId = productId || null;
        this.quantity = quantity || 0;
    }
}