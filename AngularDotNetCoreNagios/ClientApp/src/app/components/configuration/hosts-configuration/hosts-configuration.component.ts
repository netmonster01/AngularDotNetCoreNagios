import { Component, OnInit } from '@angular/core';
import { ANagiosService } from '../../../services';
import { MatDialog, MatDialogConfig } from "@angular/material";

@Component({
  selector: 'app-hosts-configuration',
  templateUrl: './hosts-configuration.component.html',
  styleUrls: ['./hosts-configuration.component.scss']
})
export class HostsConfigurationComponent implements OnInit {

  constructor(private aNagios: ANagiosService) { }

  hostList: any;
  selectedUserTab = 1;
  tabs = [
    {
      name: 'Title one',
      key: 1,
      active: true
    },
    {
      name: 'Title two',
      key: 2,
      active: false
    },
    {
      name: 'Title 3',
      key: 3,
      active: false
    },
    {
      name: 'Title Four',
      key: 4,
      active: false
    }
  ];

  tabChange(selectedTab) {
    console.log('### tab change');
    this.selectedUserTab = selectedTab.key;
    for (let tab of this.tabs) {
      if (tab.key === selectedTab.key) {
        tab.active = true;
      } else {
        tab.active = false;
      }
    }
  }
  ngOnInit() {

    this.getHosts();
  }

  getHosts(): any {
    this.aNagios.getHosts().subscribe((hosts: any) => this.processHosts(hosts));
  }

  processHosts(hosts: any): void {
    console.log(hosts);
    this.hostList = hosts;
  }

}
