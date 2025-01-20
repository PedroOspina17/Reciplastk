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

  /*
  From service get a list of weight control products and its sums based on the parameters. List<CharDataModel>
  [
    {label: PET, value: 12},
    {label: PP-Alta, value: 24},
    {label: PP-Baja, value: 14},
    {label: Pasta, value: 50},
  ]
  */
  ngOnInit() {
    this.chart = new Chart('line-canvas', {
      type: 'pie',
      data: {
        labels: ['PET', 'PP-Alta', 'PP-Baja', 'Pasta'],
        datasets: [
          {
            label: 'Pedro',
            data: [12, 24, 14, 50],
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
