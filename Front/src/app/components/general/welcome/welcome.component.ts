import { Component } from '@angular/core';
import { LinesChartComponent } from "../../charts/lines-chart/lines-chart.component";
import { EmployeeComparisonComponent } from "../../charts/employee-comparison/employee-comparison.component";
import { CompanyPerformanceComponent } from "../../charts/company-performance/company-performance.component";

@Component({
  selector: 'app-welcome',
  standalone: true,
  imports: [LinesChartComponent, EmployeeComparisonComponent, CompanyPerformanceComponent],
  templateUrl: './welcome.component.html',
  styleUrl: './welcome.component.css'
})
export class WelcomeComponent {

}
