import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainScreenComponent } from './main-screen/main-screen.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../shared/modules/material/material.module';
import { AdminScreenComponent } from './admin-screen/admin-screen.component';
import { ManagmentRoutes } from './managment.routing';

@NgModule({
  declarations: [
    MainScreenComponent,
    AdminScreenComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    ManagmentRoutes,
    MaterialModule
  ]
})
export class ManagmentModule { }
