import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NagiosService } from '../../../../services/';
import { ContactGroup } from '../../../../models';

@Component({
  selector: 'app-add-host',
  templateUrl: './add-host.component.html',
  styleUrls: ['./add-host.component.scss']
})
export class AddHostComponent implements OnInit {

  addForm: FormGroup;
  hostGroups: string[] = [];
  selectedHostGroups: string[] = [];
  contactGroups: string[] = [];
  selectedContactGroups: string[] = [];
  constructor(private fb: FormBuilder, private nagios: NagiosService) { }
   
  ngOnInit() {
    this.addForm = this.fb.group({
      hostName: ['', Validators.required],
      alias: ['', Validators.required],
      ipAddress: ['', Validators.required],
      hostGroup: ['None', Validators.required]
    });

    this.getHostsGroups();
    this.getContactGroups();
  }

  getHostsGroups(): any {
    this.nagios.getHostGroups().subscribe((hostGoups: any) => { this.hostGroups = hostGoups.data.hostgrouplist; });
  }

  getContactGroups(): any {
    this.nagios.getContactList().subscribe((contactGroups: any) => this.processGroups(contactGroups.data.contactlist));
  }

  processGroups(contactGroups: any): void {
    console.log(contactGroups);
    this.contactGroups = contactGroups;
  }

}
