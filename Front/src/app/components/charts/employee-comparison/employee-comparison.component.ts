import { Component } from '@angular/core';
import Chart from 'chart.js/auto';
import { ChartsService } from '../../../services/charts.service';

@Component({
  selector: 'app-employee-comparison',
  standalone: true,
  imports: [],
  templateUrl: './employee-comparison.component.html',
  styleUrl: './employee-comparison.component.css'
})

export class EmployeeComparisonComponent {
  constructor(private chartService: ChartsService) {}
  chart: any = []

  
  ngOnInit() {
    this.chart = new Chart('employee-comparison-canvas', {
      type: 'line',
      data: {
        labels: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio'],
        datasets: [
          {
            label: 'Gloria',
            data: [12, 8, 14, 15, 12, 12],
            borderWidth: 1,
          },
          {
            label: 'Pedro',
            data: [10, 15, 13, 9, 9, 10],
            borderWidth: 1,
          },
          {
            label: 'Maria',
            data: [11, 19, 3, 5, 2, 3],
            borderWidth: 1,
          },
          
        ],
      },
      options: {
        scales: {
          y: {
            beginAtZero: true,
          },
        },
      },
    });
  }
}
