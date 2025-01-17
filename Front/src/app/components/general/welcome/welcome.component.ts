import { Component } from '@angular/core';
import { LinesChartComponent } from "../../charts/lines-chart/lines-chart.component";
import { EmployeeComparisonComponent } from "../../charts/employee-comparison/employee-comparison.component";
import { CompanyPerformanceComponent } from "../../charts/company-performance/company-performance.component";
import { KpisComponent } from '../../dashboard/kpis/kpis.component';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-welcome',
  standalone: true,
  imports: [LinesChartComponent, EmployeeComparisonComponent, CompanyPerformanceComponent, KpisComponent, ReactiveFormsModule, CommonModule],
  templateUrl: './welcome.component.html',
  styleUrl: './welcome.component.css'
})
export class WelcomeComponent {
  chartFiltersForm: FormGroup;
  
  constructor(private fb: FormBuilder) {
    this.chartFiltersForm = this.fb.group({
      isYearlyChart: [false],
      year: [2025],
      month: [1]
    });
  }
  
}
