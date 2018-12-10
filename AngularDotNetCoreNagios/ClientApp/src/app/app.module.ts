import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NagiosService, ANagiosService } from './services';
import { HostsComponent, ServiceComponent } from './components';
import { HttpClientModule } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ServicesComponent, HostComponent, DashboardComponent, TacticalOverviewComponent, ChartsComponent  } from './components';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FooterComponent, HeaderComponent } from './shared/layout';
import { CustomMaterialModule } from './core';
import { AddHostComponent } from './components/forms/hosts/add-host/add-host.component';
import { AngularDualListBoxModule } from 'angular-dual-listbox';
import { AddContactDialogComponent } from './components/dialogs';
import { ConfigurationComponent } from './components/configuration/configuration.component';
import { ContactsComponent, ContactGroupsComponent  } from './components/configuration';
import { HostsConfigurationComponent } from './components/Configuration/hosts-configuration/hosts-configuration.component';

@NgModule({
  declarations: [
    AppComponent,
    HostsComponent,
    ServicesComponent,
    HostComponent,
    ServiceComponent,
    ChartsComponent,
    FooterComponent,
    HeaderComponent,
    DashboardComponent,
    TacticalOverviewComponent,
    AddHostComponent,
    ContactGroupsComponent,
    AddContactDialogComponent,
    ConfigurationComponent,
    ContactsComponent,
    HostsConfigurationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CustomMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    AngularDualListBoxModule
  ],
  providers: [NagiosService, ANagiosService],
  bootstrap: [AppComponent],
  entryComponents: [AddContactDialogComponent]
})
export class AppModule { }
