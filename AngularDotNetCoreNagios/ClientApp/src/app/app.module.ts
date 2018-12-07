import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NagiosService } from './services';
import { HostsComponent, ServiceComponent } from './components';
import { HttpClientModule } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { ServicesComponent, HostComponent, DashboardComponent, TacticalOverviewComponent, ChartsComponent  } from './components';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FooterComponent } from './shared/layout/footer/footer/footer.component';
import { HeaderComponent } from './shared/layout/header/header/header.component';
import { CustomMaterialModule } from './core';
import { AddHostComponent } from './components/forms/hosts/add-host/add-host.component';

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
    AddHostComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CustomMaterialModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [NagiosService],
  bootstrap: [AppComponent]
})
export class AppModule { }
