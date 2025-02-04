import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { KpiService } from '../../../services/kpi.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-kpis',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './kpis.component.html',
  styleUrl: './kpis.component.css'
})
export class KpisComponent {
  @Input() isYearly: boolean = false;
  @Input() year: number = new Date().getFullYear();
  @Input() month: number = new Date().getMonth();


  constructor(private toastr: ToastrService, private kpiService: KpiService) {

  }

  BillingGoal: number = 0;
  ShipmentGoal: number = 0;
  BillingSummary: number = 0;
  GrindingSummary: number = 0;
  SeparationSummary: number = 0;
  ShippingSummary: number = 0;
  ngOnChanges(){
    // console.log(this.isYearly,this.year,this.month);
    this.RefreshInformation();
  }
  ngOnInit() {
    this.RefreshInformation();
  }
  RefreshInformation(){
    this.kpiService.GetBillingGoal(this.isYearly, this.year, this.month).subscribe(result => {
      if (result.wasSuccessful) {
        this.BillingGoal = result.data;
      } else {
        this.toastr.error(result.statusMessage);
      }
    });
    this.kpiService.GetShipmentGoal(this.isYearly, this.year, this.month).subscribe(result => { 
      if (result.wasSuccessful) {
        this.ShipmentGoal = result.data;
      } else {
        this.toastr.error(result.statusMessage);
      }
    });
    this.kpiService.GetBillingSummary(this.isYearly, this.year, this.month).subscribe(result => {
      if (result.wasSuccessful) {
        this.BillingSummary = result.data;
      } else {
        this.toastr.error(result.statusMessage);
      }
     });
    this.kpiService.GetGrindingSummary(this.isYearly, this.year, this.month).subscribe(result => {
      if (result.wasSuccessful) {
        this.GrindingSummary = result.data;
      } else {
        this.toastr.error(result.statusMessage);
      }
     });
    this.kpiService.GetSeparationSummary(this.isYearly, this.year, this.month).subscribe(result => { 
      if (result.wasSuccessful) {
        this.SeparationSummary = result.data;
      } else {
        this.toastr.error(result.statusMessage);
      }
    });
    this.kpiService.GetShippingSummary(this.isYearly, this.year, this.month).subscribe(result => { 
      if (result.wasSuccessful) {
        this.ShippingSummary = result.data;
      } else {
        this.toastr.error(result.statusMessage);
      }
    });
  }
}
