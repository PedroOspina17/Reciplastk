import { Component } from '@angular/core';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-company-performance',
  standalone: true,
  imports: [],
  templateUrl: './company-performance.component.html',
  styleUrl: './company-performance.component.css',
})
export class CompanyPerformanceComponent {
  chart: any = [];

  ngOnInit() {
    // get a list of metrics SIMILAR TO EMPLOYEES COMPARISONS. also 
    
    this.chart = new Chart('company-performance-canvas', {
      type: 'bar',
      data: {
        labels: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio'],
        datasets: [
          {
            label: 'Recibo de material',
            data: [1200, 800, 1444, 1005, 1200, 1290],
            borderWidth: 1,
          },
          {
            label: 'Despacho de material',
            data: [1000, 900, 1300, 900, 970, 1000],
            borderWidth: 1,
          },
          {
            type: "line",
            label: 'Meta mensual',
            data: [1000, 1000, 1000, 1000, 1000, 1000],
            borderWidth: 3
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
