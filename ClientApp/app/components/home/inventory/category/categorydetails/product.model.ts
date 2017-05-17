export class ProductModel {
    id: number;
    name: string;
    description: string;
    status: boolean = true;
    categoryId: number = 1;
    quantity: number = 0;
    addTime: Date;
    modifiedTime: Date;
    constructor(name: string, des: string, cateId: number) {
        this.name = name;
        this.description = des;
        this.categoryId = cateId;
    }
}