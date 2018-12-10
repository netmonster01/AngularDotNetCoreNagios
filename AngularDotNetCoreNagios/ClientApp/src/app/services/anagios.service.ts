import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ContactCfg, ContactGroupCfg  } from '../models';

@Injectable({
  providedIn: 'root'
})

export class ANagiosService {

  constructor(private http: HttpClient) { }
  headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  options = {
    headers: this.headers
  };

  getContacts() {
    return this.http.get<any>('/api/Contacts').catch(this.handleError);
  }

  getContactGroups() {
    return this.http.get<any>('/api/ContactGroups').catch(this.handleError);
  }

  postContact(contact: ContactCfg) {

    return this.http.post<ContactCfg>('/api/Contacts', contact, this.options).catch(this.handleError);
  }

  getHosts() {
    return this.http.get<any>('/api/Hosts').catch(this.handleError);
  }

  handleError(error: any): any {
    console.log(error);
  }
}
