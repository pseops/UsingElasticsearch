import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SearchFilterComponent } from './main-screen/search-filter/search-filter.component';


const routes: Routes = [
  {path: '', component: SearchFilterComponent},
  {path: 'filter', component: SearchFilterComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
