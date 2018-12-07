import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent, AddHostComponent } from './components';
import { TacticalOverviewComponent, HostsComponent } from './components';

const routes: Routes = [
  { path: 'home', component: DashboardComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'tac', component: TacticalOverviewComponent },
  { path: 'addHost', component: AddHostComponent },
  { path: 'hosts', component: HostsComponent },];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
