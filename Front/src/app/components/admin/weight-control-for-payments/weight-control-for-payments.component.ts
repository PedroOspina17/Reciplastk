import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';
import { WeightControlService } from '../../../services/weight-control-service';
import { WeightControlReportRequest } from '../../../models/Requests/WeightControlReportRequest';
import { WeightControlReport } from '../../../models/WeightControlReport';
import { DatePipe } from '@angular/common';
import { PaymentReceiptRequest } from '../../../models/Requests/PaymentReceiptRequest';
import { PaymentReceiptComponent } from '../payment-receipt/payment-receipt.component';

@Component({
  selector: 'app-weight-control-for-payments',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    PaymentReceiptComponent,
  ],
  providers: [DatePipe],
  templateUrl: './weight-control-for-payments.component.html',
  styleUrls: ['./weight-control-for-payments.component.css'],
})
export class WeightControlForPaymentsComponent {
  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private weightControlService: WeightControlService,
    private datePipe: DatePipe,
  ) {
    this.FormPayments = this.fb.group({
      StartDate: [],
      EndDate: [],
      Employee: [-1, [Validators.required, Validators.min(0)]],
    });
    this.BillInfo = new PaymentReceiptRequest();
  }

  FormPayments: FormGroup;
  EmployeeList: any[] = [];
  Filtered: (WeightControlReport & { selected: boolean })[] = [];
  isVisible: boolean = false;
  BillInfo: PaymentReceiptRequest;
  ShowBill: boolean = false;

  ngOnInit(): void {
    this.GetEmployee();
  }

  GetEmployee() {
    this.weightControlService.GetEmployee().subscribe((r) => {
      if (r.WasSuccessful) {
        this.EmployeeList = r.Data;
      } else {
        this.toastr.error('No se encontró ningún empleado');
      }
    });
  }

  Filter() {
    const selectedEmployee = this.FormPayments.value.Employee;
    const Model: WeightControlReportRequest = {
      StartDate: this.FormPayments.value.StartDate,
      EndDate: this.FormPayments.value.EndDate,
      EmployeeId: selectedEmployee?.id,
      IsPaid: false,
    };
    this.BillInfo.EmployeeName = selectedEmployee.name;
    this.BillInfo.EmployeeId = selectedEmployee.employeeid;
    this.weightControlService.Filter(Model).subscribe((r) => {
      this.BillInfo.Date = this.datePipe.transform(new Date(), 'MM/dd/yyyy') || '';
      if (r.WasSuccessful) {
        this.Filtered = r.Data.map((item: WeightControlReport) => ({
          ...item,
          date: this.datePipe.transform(item.date, 'short') || '',
          selected: false,
        }));
        const selectedEmployee = this.EmployeeList.find(
          (employee) => employee.id === Model.EmployeeId
        );
        this.BillInfo.EmployeeName = selectedEmployee.name;
      } else {
        this.toastr.error(
          'No se encontraron los detalles con los filtros aplicados'
        );
      }
    });
    this.isVisible = true;
  }

  CheckAll(event: Event): void {
    const isChecked = (event.target as HTMLInputElement).checked;
    this.Filtered.forEach((item) => {
      item.selected = isChecked;
    });

    if (isChecked) {
      this.BillInfo.Products = this.Filtered.map((item) => ({
        WeightControlDetailId: item.weightcontroldetailid,
        Name: item.productName,
        Weight: item.weight,
        Price: item.weight * 150, // To do: replace for a config value
      }));

      this.BillInfo.TotalWeight = this.BillInfo.Products.reduce(
        (sum, product) => sum + product.Weight,
        0
      );
      this.BillInfo.TotalToPay = this.BillInfo.TotalWeight * 150; // To do: replace for a config value
    } else {
      this.BillInfo.Products = [];
      this.BillInfo.TotalWeight = 0;
      this.BillInfo.TotalToPay = 0;
    }
  }

  onCheckboxChange(
    event: Event,
    weightcontroldetailid: number,
    productName: string,
    weight: number
  ) {
    const checkbox = event.target as HTMLInputElement;
    if (checkbox.checked) {
      this.BillInfo.Products.push({
        WeightControlDetailId: weightcontroldetailid,
        Name: productName,
        Weight: weight,
        Price: weight * 150, // To do: replace for a config value
      });
      this.BillInfo.TotalWeight += weight;
    } else {
      this.BillInfo.Products = this.BillInfo.Products.filter(
        (product) => product.WeightControlDetailId !== weightcontroldetailid
      );
      this.BillInfo.TotalWeight -= weight;
    }
    this.BillInfo.TotalToPay = this.BillInfo.TotalWeight * 150; // To do: replace for a config value
  }

  PayAndSave() {
    if (this.BillInfo.Products.length > 0) {
      this.weightControlService.PayAndSave(this.BillInfo).subscribe((r) => {
        if (r.WasSuccessful) {
          this.toastr.success('Se modificaron los pagos correctamente');
          this.Filter();
          this.ShowBill = true;
        } else {
          this.toastr.error('No se pudieron modificar los pagos correctamente');
        }
      });
    } else {
      this.toastr.error('No hay productos seleccionados.');
    }
  }
}
