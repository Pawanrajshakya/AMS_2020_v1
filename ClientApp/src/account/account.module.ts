import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { MaterialModule } from "src/app/material.module";
import { FlexLayoutModule } from "@angular/flex-layout";
import { AddAccountComponent } from './components/add-account/add-account.component';
import { ListAccountComponent } from './components/list-account/list-account.component';

@NgModule({
  declarations: [
    ListAccountComponent,
    AddAccountComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,
    MaterialModule,
    FlexLayoutModule,
  ],
  entryComponents: [],
  exports: [
    ListAccountComponent,
    AddAccountComponent
  ],
})
export class AccountModule {}
