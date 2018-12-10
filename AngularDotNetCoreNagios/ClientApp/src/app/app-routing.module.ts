import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent, AddHostComponent, TacticalOverviewComponent, HostsComponent, ContactGroupsComponent, ConfigurationComponent } from './components';


const routes: Routes = [
  { path: 'home', component: DashboardComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'tac', component: TacticalOverviewComponent },
  { path: 'addHost', component: AddHostComponent },
  { path: 'contacts', component: ContactGroupsComponent },
  { path: 'config', component: ConfigurationComponent },
  { path: 'hosts', component: HostsComponent },];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
