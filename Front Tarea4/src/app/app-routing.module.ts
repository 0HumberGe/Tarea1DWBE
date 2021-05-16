import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './modules/employees/employees.component';
import { ProductsComponent } from './modules/products/products.component';
import { StartComponent } from './modules/start/start.component';


const routes: Routes = [
  { path: '', component: StartComponent},
  { path: 'productos', component: ProductsComponent},
  { path: 'empleados', component: EmployeesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
