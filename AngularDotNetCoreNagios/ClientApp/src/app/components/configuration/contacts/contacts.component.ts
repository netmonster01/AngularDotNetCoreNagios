import { Component, OnInit } from '@angular/core';
import { ANagiosService } from '../../../services';
import { MatDialog, MatDialogConfig } from "@angular/material";
import { AddContactDialogComponent } from '../../dialogs';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.scss']
})
export class ContactsComponent implements OnInit {

  constructor(private aNagios: ANagiosService, private dialog: MatDialog) { }
  showContacts = true;
  contacts: any;

  ngOnInit() {

    this.getContact();
  }

  getContact(): any {
    this.aNagios.getContacts().subscribe((contacts: any) => this.processGroups(contacts));
  }

  processGroups(contacts: any): void {
    console.log(contacts);
    this.contacts = contacts;
  }

  viewContacts() {
    this.showContacts = !this.showContacts;
  }

  openDialog() {

    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    dialogConfig.data = {
      id: 1,
      hasBackdrop: false,
      width: '500px'
    };

    const dialogRef = this.dialog.open(AddContactDialogComponent, { width: '300px', hasBackdrop: false });

    dialogRef.afterClosed().subscribe(
      data => console.log('Dialog output:', data)
    );
  }
}
