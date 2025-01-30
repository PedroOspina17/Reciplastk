import { WeightControlDetailModel } from '../WeightControlDetailModel';

export class WeightControlSeparationRequest {
  Id?: number;
  EmployeeId: number = -1;
  WeightDetail: WeightControlDetailModel[] = [];
}
