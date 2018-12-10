import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import {
  MatButtonModule, MatInputModule, MatSelectModule, MatNativeDateModule, MatChipsModule, MatIconModule, MatSidenavModule, MatListModule, MatToolbarModule, MatProgressSpinnerModule, MatDialogModule, MatTabsModule 
} from '@angular/material';
@NgModule({
  imports: [CommonModule, MatButtonModule, MatToolbarModule, MatNativeDateModule, MatIconModule, MatSidenavModule, MatListModule, MatProgressSpinnerModule, MatInputModule, MatSelectModule, MatChipsModule, MatDialogModule, MatTabsModule ],
  exports: [CommonModule, MatButtonModule, MatToolbarModule, MatNativeDateModule, MatIconModule, MatSidenavModule, MatListModule, MatProgressSpinnerModule, MatInputModule, MatSelectModule, MatChipsModule, MatDialogModule, MatTabsModule ],
})
export class CustomMaterialModule { }
