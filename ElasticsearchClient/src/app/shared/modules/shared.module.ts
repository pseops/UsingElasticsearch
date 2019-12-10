import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material/material.module';
import { TableConstants, FilterConstants } from '../constants';



@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  providers: [
    TableConstants,
    FilterConstants
  ],
})
export class SharedModule { }
