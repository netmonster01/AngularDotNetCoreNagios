import { Component, OnInit } from '@angular/core';
import { ANagiosService } from '../../../services';
import { ContactGroupCfg } from '../../../models';

@Component({
  selector: 'app-contact-groups',
  templateUrl: './contact-groups.component.html',
  styleUrls: ['./contact-groups.component.scss']
})
export class ContactGroupsComponent implements OnInit {

  contactGroups: any;
  constructor(private aNagios: ANagiosService) { }
  
  ngOnInit() {

    this.getContactGroups();
  }

  getContactGroups(): any {
    this.aNagios.getContactGroups().subscribe((contactGroups: any) => this.processGroups(contactGroups));
  }

  processGroups(contactGroups: any): void {
    console.log(contactGroups);
    this.contactGroups = contactGroups;
  }
}
