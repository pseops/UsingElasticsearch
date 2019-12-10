import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchFilterComponent } from './search-filter/search-filter.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../shared/modules/material/material.module';



@NgModule({
  declarations: [
    SearchFilterComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ]
})
export class MainScreenModule { }
