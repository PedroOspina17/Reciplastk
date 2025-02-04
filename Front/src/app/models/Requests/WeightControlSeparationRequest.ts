import { WeightControlSeparationDetailRequest } from './WeightControlSeparationDetailRequest';

export class WeightControlSeparationRequest {
  Id?: number;
  EmployeeId: number = -1;
  WeightControlDetails: WeightControlSeparationDetailRequest[] = [];
}
