import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Host, Service, ServiceCount, HostCount } from '../models';
import { Observable, BehaviorSubject } from 'rxjs';


export const SERVICE_COUNTS: ServiceCount = {
    critical: 0,
    ok: 0,
    pending: 0,
    unknown: 0,
    warning: 0
};

export const HOST_COUNTS: HostCount = {
  down: 0,
  pending: 0,
  unreachable: 0,
  up: 0
};

@Injectable({
  providedIn: 'root'
})

export class NagiosService {

  private serviceCountSubject = new BehaviorSubject<ServiceCount>(SERVICE_COUNTS);
  private hostCountSubject = new BehaviorSubject<HostCount>(HOST_COUNTS);

  $ServiceCounts: Observable<ServiceCount> = this.serviceCountSubject.asObservable();
  $HostCounts: Observable<HostCount> = this.hostCountSubject.asObservable();

  constructor(private http: HttpClient) {

    this.getServiceCount();
    this.getHostCount();
  }

  hostBase = 'https://monitor.cavitt.net';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization:
        'Basic bmFnaW9zYWRtaW46bmFnaW9zYWRtaW4='
    })
  };

  getHosts() {
    // return this.http.get<any>('/nagios/cgi-bin/statusjson.cgi?query=hostlist&details=true',
    // this.httpOptions).catch(this.handleError);
    return this.http.get<any>('/assets/hosts.json',
    this.httpOptions).catch(this.handleError);
  }

  getServices() {
    return this.http.get<any>('/assets/services.json',
    this.httpOptions).catch(this.handleError);
    // return this.http.get<any>('/nagios/cgi-bin/statusjson.cgi?query=servicelist&details=true',
    // this.httpOptions).catch(this.handleError);
  }


  getHost(host: string) {
    return this.http.get<any>('/nagios/cgi-bin/statusjson.cgi?query=host&hostname=' + host,
    this.httpOptions).catch(this.handleError);
  }

  getHostCount() {
    return this.http.get<any>('/assets/hostCount.json',
      this.httpOptions).subscribe((hostCounts: any) => this.hostCountSubject.next(hostCounts.data.count), err => this.handleError(err));
    // return this.http.get<any>('/nagios/cgi-bin/statusjson.cgi?query=hostcount',
    // this.httpOptions).catch(this.handleError);
  }

  getServiceCount() {
    return this.http.get<any>('/assets/serviceCount.json',
      this.httpOptions).subscribe((serviceCounts: any) => this.serviceCountSubject.next(serviceCounts.data.count), err => this.handleError(err));
    // return this.http.get<any>('/nagios/cgi-bin/statusjson.cgi?query=servicecount',
    // this.httpOptions).catch(this.handleError);
  }

  getPerformanceData() {
    return this.http.get<any>('/nagios/cgi-bin/statusjson.cgi?query=performancedata',
    this.httpOptions).catch(this.handleError);
  }

  getProgramStatus() {
    return this.http.get<any>('/nagios/cgi-bin/statusjson.cgi?query=programstatus',
    this.httpOptions).catch(this.handleError);
  }

  getDowntimeList() {
    return this.http.get<any>('/nagios/cgi-bin/statusjson.cgi?query=downtimelist&details=true',
    this.httpOptions).catch(this.handleError);
  }

  addHost(host: Host) {
    return this.http.get<any>('/nagios/cgi-bin/addHost1.py?host_name=' + host.hostName + '&ip_address=' + host.ipAddress,
    this.httpOptions).catch(this.handleError);
  }

  removeHost(host: Host) {
    return this.http.get<any>('/nagios/cgi-bin/deleteHost.py?host_name=' + host.hostName,
    this.httpOptions).catch(this.handleError);
  }

  getCommands() {
    return this.http.get<any>('/assets/commands.json',
      this.httpOptions).catch(this.handleError);
    //return this.http.get<any>('/nagios/cgi-bin/objectjson.cgi?query=commandlist',
    //  this.httpOptions).catch(this.handleError);
  }

  getHostGroups() {
    return this.http.get<any>('/assets/hostGroupList.json',
      this.httpOptions).catch(this.handleError);
    //return this.http.get<any>('/nagios/cgi-bin/objectjson.cgi?query=hostgrouplist',
    //  this.httpOptions).catch(this.handleError);
  }

  getContactList() {
    return this.http.get<any>('/assets/contactList.json',
      this.httpOptions).catch(this.handleError);
    //return this.http.get<any>('/nagios/cgi-bin/objectjson.cgi?query=contactlist',
    //  this.httpOptions).catch(this.handleError);
  }
  handleError(handleError: any): any {
    console.log(handleError);
  }
}
