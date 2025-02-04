import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { LoaderComponent } from '../../shared/loader/loader.component';
import { ToastrService } from 'ngx-toastr';
import { WeightControlService } from '../../../services/weight-control-service';
import { RemainigsViewModel } from '../../../models/ViewModel/RemainigsViewModel';

@Component({
  selector: 'app-remainig',
  standalone: true,
  imports: [
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
  remaining: RemainigsViewModel[] = [];
  ngOnInit(): void {
    this.GetRemaining(false);
  }
  GetRemaining(viewAll: boolean) {
    this.weightControlService.Remainings(viewAll).subscribe((r) => {
      if (r.WasSuccessful == true) {
        this.remaining = r.Data;
      } else {
        this.toastr.error('No se encontraron los materiales restantes');
      }
    });
  }
  onCheckChange(value: any) {
    const selected = value.target.checked;
    this.GetRemaining(selected);
  }
}
