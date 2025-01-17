import { WeightControlDetailModel } from './WeightControlDetailModel';

export class WeightControlModel {
  weightcontrolid?: number;
  employeeid: number = -1;
  weightdetail: WeightControlDetailModel[] = [];
}
