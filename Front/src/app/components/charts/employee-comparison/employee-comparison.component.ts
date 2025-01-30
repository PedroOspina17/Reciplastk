import { Component, Input, input } from '@angular/core';
import Chart from 'chart.js/auto';
import { ChartsService } from '../../../services/charts.service';
import { ChartDataModel } from '../../../models/ChartDataModel';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee-comparison',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './employee-comparison.component.html',
  styleUrl: './employee-comparison.component.css'
})
export class EmployeeComparisonComponent {
  
@Input() isYearlyChart: boolean = false;
@Input() year: number = new Date().getFullYear();
@Input() month: number  = new Date().getMonth();

  constructor(private chartService: ChartsService, 
    private toastr: ToastrService,
    private fb: FormBuilder) {
  }
  chart: any = []

  ngOnChanges(){
    console.log(this.isYearlyChart,this.year,this.month);
    this.drawChart();
  }
  
  ngOnInit() {
    this.drawChart();
  }

  drawChart(){
    this.chartService.GetEmployeeComparisonInfo(this.isYearlyChart,this.year, this.month).subscribe(res => {
      if(res.WasSuccessful){
      console.log(res.Data.chartLabels);
      let labelsList = this.isYearlyChart ? ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', ' Septiembre','Octubre','Noviembre','Diciembre'] : Array.from(Array(30).keys()).map(x => x + 1);
      var chartExist = Chart.getChart("employee-comparison-canvas"); // <canvas> id
    if (chartExist != undefined)  
      chartExist.destroy(); 
      this.chart = new Chart('employee-comparison-canvas', {
        type: 'line',
        data: {
          // labels: ,
          labels: labelsList as string[],
          datasets: res.Data
        },
        options: {
          scales: {
            y: {
              beginAtZero: true,
            },
          },
        },
      });
    }else{
      this.toastr.error(res.StatusMessage);
    }
    });
  }
}

// Datasets: [
//   {
//     label: 'Gloria',
//     data: [12, 8, 14, 15, 12, 12],
//     borderWidth: 1,
//   },
//   {
//     label: 'Pedro',
//     data: [10, 15, 13, 9, 9, 10],
//     borderWidth: 1,
//   },
//   {
//     label: 'Maria',
//     data: [11, 19, 3, 5, 2, 3],
//     borderWidth: 1,
//   },
  
// ]
