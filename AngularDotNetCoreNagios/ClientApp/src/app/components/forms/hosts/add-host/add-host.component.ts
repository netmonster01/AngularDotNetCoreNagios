import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-add-host',
  templateUrl: './add-host.component.html',
  styleUrls: ['./add-host.component.scss']
})
export class AddHostComponent implements OnInit {

  addForm: FormGroup;

  constructor(private fb: FormBuilder) { }
   
  ngOnInit() {
    this.addForm = this.fb.group({
      hostName: ['', Validators.required],
      alias: ['', Validators.required],
      ipAddress: ['', Validators.required],
      serverGroup: [''],
    });
  }

}
