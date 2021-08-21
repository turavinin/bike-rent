export class RentDetail {
  id: number = 0;
  idRent: number = 0;
  idRate: number = 0;
  amountTerm: number = 0;
  totalRents: number = 0;

    constructor(idRate: number | 0) {
    this.idRate = idRate;
  }
}
