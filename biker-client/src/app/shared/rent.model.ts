import { RentDetail } from "./rent-detail.model";

export class Rent {
  id: number = 0;
  clientName: string = "";
  partialCost: any = 0;
  discount: any = 0;
  finalCost: any = 0;
  rentDetails: RentDetail[] = [];
}
