import { Component, OnInit } from '@angular/core';
import { NagiosService } from '../../services';
import { HostCount, ServiceCount } from '../../models';

@Component({
  selector: 'app-tactical-overview',
  templateUrl: './tactical-overview.component.html',
  styleUrls: ['./tactical-overview.component.scss']
})
export class TacticalOverviewComponent implements OnInit {

  constructor(private nagios: NagiosService) { }

  serviceCounts: ServiceCount;
  hostCounts: HostCount;
  isLoading = false;
  isLoadingServices = false;
  isLoadingHosts = false;
  ngOnInit() {

    this.getServiceCounts();
    this.getHostCounts();

  }

  getServiceCounts(): any {
    this.isLoading = true;
    this.isLoadingServices = true;
    this.nagios.$ServiceCounts.subscribe((counts: any) => { this.serviceCounts = counts; this.isLoadingServices = false; });
  }

  checkLoad(): any {
    return !this.isLoadingHosts && !this.isLoadingServices;
    //if (this.isLoadingHosts && this.isLoadingServices) {
    //  this.isLoading = false;
    //}
  }

  getHostCounts(): any {
    this.isLoadingHosts = true;
    this.nagios.$HostCounts.subscribe((counts: any) => { this.hostCounts = counts; this.isLoadingHosts = false;});
  }
}
