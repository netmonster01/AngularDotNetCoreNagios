import { Component, OnInit } from '@angular/core';
import { NagiosService, SERVICE_COUNTS, HOST_COUNTS } from '../../services';
import { HostCount, ServiceCount } from '../../models';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})

export class DashboardComponent implements OnInit {

  constructor(private nagios: NagiosService) { }

  isLoadingServices = false;
  isLoadingHosts = false;

  serviceCounts = SERVICE_COUNTS;
  hostCounts = HOST_COUNTS;

  ngOnInit() {
    this.getServiceCounts();
    this.getHostCounts();
  }

  getServiceCounts(): any {
    this.isLoadingServices = true;
    this.nagios.$ServiceCounts.subscribe((counts: any) => { this.serviceCounts = counts; this.isLoadingServices = false; });
  }

  getHostCounts(): any {
    this.isLoadingHosts = true;
    this.nagios.$HostCounts.subscribe((counts: any) => { this.hostCounts = counts; this.isLoadingHosts = false;  });
  }

}
