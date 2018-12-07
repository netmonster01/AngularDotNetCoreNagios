import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import {
  MatButtonModule, MatInputModule, MatSelectModule, MatNativeDateModule, MatChipsModule, MatIconModule, MatSidenavModule, MatListModule, MatToolbarModule, MatProgressSpinnerModule,
} from '@angular/material';
@NgModule({
  imports: [CommonModule, MatButtonModule, MatToolbarModule, MatNativeDateModule, MatIconModule, MatSidenavModule, MatListModule, MatProgressSpinnerModule, MatInputModule, MatSelectModule, MatChipsModule],
  exports: [CommonModule, MatButtonModule, MatToolbarModule, MatNativeDateModule, MatIconModule, MatSidenavModule, MatListModule, MatProgressSpinnerModule, MatInputModule, MatSelectModule, MatChipsModule],
})
export class CustomMaterialModule { }
