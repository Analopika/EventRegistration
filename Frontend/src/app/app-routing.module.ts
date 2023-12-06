import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventRegisterComponent } from './event-register/event-register.component';
import { AdmitComponent } from './admit/admit.component';

const routes: Routes = [
  {path: '', component:EventRegisterComponent},
  {path: 'admit', component:AdmitComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
