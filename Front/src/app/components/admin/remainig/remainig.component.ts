import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { ToastrService } from 'ngx-toastr';
import { WeightControlService } from '../../../services/weight-control-service';
import { RemainingModel } from '../../../models/RemainigModel';

@Component({
  selector: 'app-remainig',
  standalone: true,
  imports: [
    RouterLink,
    LoaderComponent,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  templateUrl: './remainig.component.html',
  styleUrl: './remainig.component.css',
})
export class RemainigComponent {
  constructor(
    private weightControlService: WeightControlService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) {}
  remaining: RemainingModel[] = [];
  ngOnInit(): void {
    this.GetRemaining(false);
  }
  GetRemaining(viewAll: boolean) {
    this.weightControlService.Remainings(viewAll).subscribe((r) => {
      if (r.wasSuccessful == true) {
        this.remaining = r.data;
        console.log(r.data);
      } else {
        this.toastr.error('No se encontraron los materiales restantes');
      }
    });
  }
  onCheckChange(value: any) {
    const selected = value.target.checked;
    console.log(selected);
    this.GetRemaining(selected);
  }
}
