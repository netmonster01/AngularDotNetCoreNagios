import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ContactCfg } from 'src/app/models';
import { ANagiosService } from '../../../services'

@Component({
  selector: 'app-add-contact-dialog',
  templateUrl: './add-contact-dialog.component.html',
  styleUrls: ['./add-contact-dialog.component.scss']
})
export class AddContactDialogComponent implements OnInit {

  constructor(private fb: FormBuilder, private aNagios: ANagiosService, private dialogRef: MatDialogRef<AddContactDialogComponent>,
  @Inject(MAT_DIALOG_DATA) data) { }

  addContactForm: FormGroup;
  errors: string;
  contact: ContactCfg = {
    alias: null,
    name: null,
    emailAddress: null
  };
  ngOnInit() {

    this.errors = 'some major error';
    this.addContactForm = this.fb.group({
      name: ['', Validators.required],
      alias: ['', Validators.required],
      emailAddress: ['', Validators.required],
    });
  }

  save() {
    this.contact.name = this.addContactForm.controls.name.value;
    this.contact.alias = this.addContactForm.controls.alias.value;
    this.contact.emailAddress = this.addContactForm.controls.emailAddress.value;
    this.postDate();
  }

  postDate() {
    this.aNagios.postContact(this.contact).subscribe((contact: ContactCfg) => { this.dialogRef.close(contact);});
  }

  close() {
    this.dialogRef.close();
  }
}
