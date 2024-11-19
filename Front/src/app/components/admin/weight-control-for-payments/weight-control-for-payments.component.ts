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
import { WeightControlReportParams } from '../../../models/WeightControlReportParams';
import { WeightControlReport } from '../../../models/WeightControlReport';
import { DatePipe } from '@angular/common';
import { PaymentReceipt } from '../../../models/PaymentReceipt';
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
    this.BillInfo = new PaymentReceipt();
  }

  FormPayments: FormGroup;
  EmployeeList: any[] = [];
  Filtered: (WeightControlReport & { selected: boolean })[] = [];
  isVisible: boolean = false;
  BillInfo: PaymentReceipt;
  ShowBill: boolean = false;

  ngOnInit(): void {
    this.GetEmployee();
  }

  GetEmployee() {
    this.weightControlService.GetEmployee().subscribe((r) => {
      if (r.wasSuccessful) {
        this.EmployeeList = r.data;
      } else {
        this.toastr.error('No se encontró ningún empleado');
      }
    });
  }

  Filter() {
    const selectedEmployee = this.FormPayments.value.Employee;
    const Model: WeightControlReportParams = {
      StartDate: this.FormPayments.value.StartDate,
      EndDate: this.FormPayments.value.EndDate,
      EmployeeId: selectedEmployee?.id,
      Ispaid: false,
    };
    this.BillInfo.employeeName = selectedEmployee.name;
    this.BillInfo.employeeId = selectedEmployee.employeeid;
    this.weightControlService.Filter(Model).subscribe((r) => {
      this.BillInfo.date = this.datePipe.transform(new Date(), 'MM/dd/yyyy') || '';
      if (r.wasSuccessful) {
        this.Filtered = r.data.map((item: WeightControlReport) => ({
          ...item,
          date: this.datePipe.transform(item.date, 'short') || '',
          selected: false,
        }));
        const selectedEmployee = this.EmployeeList.find(
          (employee) => employee.id === Model.EmployeeId
        );
        this.BillInfo.employeeName = selectedEmployee.name;
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
      this.BillInfo.products = this.Filtered.map((item) => ({
        weightcontroldetailid: item.weightcontroldetailid,
        name: item.productName,
        weight: item.weight,
        price: item.weight * 150, // To do: replace for a config value
      }));

      this.BillInfo.totalWeight = this.BillInfo.products.reduce(
        (sum, product) => sum + product.weight,
        0
      );
      this.BillInfo.totalToPay = this.BillInfo.totalWeight * 150; // To do: replace for a config value
    } else {
      this.BillInfo.products = [];
      this.BillInfo.totalWeight = 0;
      this.BillInfo.totalToPay = 0;
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
      this.BillInfo.products.push({
        weightcontroldetailid: weightcontroldetailid,
        name: productName,
        weight: weight,
        price: weight * 150, // To do: replace for a config value
      });
      this.BillInfo.totalWeight += weight;
    } else {
      this.BillInfo.products = this.BillInfo.products.filter(
        (product) => product.weightcontroldetailid !== weightcontroldetailid
      );
      this.BillInfo.totalWeight -= weight;
    }
    this.BillInfo.totalToPay = this.BillInfo.totalWeight * 150; // To do: replace for a config value
  }

  PayAndSave() {
    if (this.BillInfo.products.length > 0) {
      this.weightControlService.PayAndSave(this.BillInfo).subscribe((r) => {
        if (r.wasSuccessful) {
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
