import { Component } from '@angular/core';
import Chart from 'chart.js/auto';

@Component({
  selector: 'app-lines-chart',
  standalone: true,
  imports: [],
  templateUrl: './lines-chart.component.html',
  styleUrl: './lines-chart.component.css'
})
export class LinesChartComponent {
  chart: any = []

  
  ngOnInit() {
    this.chart = new Chart('line-canvas', {
      type: 'pie',
      data: {
        labels: ['PET', 'PP-Alta', 'PP-Baja', 'Pasta'],
        datasets: [
          {
            label: 'Pedro',
            data: [12, 8, 14, 15, 12, 12],
            borderWidth: 1,
          }
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
