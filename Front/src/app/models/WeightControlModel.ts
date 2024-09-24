import { WeightControlDetailModel } from './WeightControlDetailModel';

export class WeightControlModel {
  Weightcontrolid?: number;
  Employeeid: number = -1;
  WeightControlTypeId: number = -1;
  weightdetail: WeightControlDetailModel[] = [];
}
