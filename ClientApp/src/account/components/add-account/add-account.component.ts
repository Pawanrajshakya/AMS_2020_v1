import { Component, OnInit } from "@angular/core";
import { FormGroup, FormControl, Validators } from "@angular/forms";

import { IClient } from "src/account/models/client-data";
import { IAccountType } from "src/account/models/accountType-data";
import { IAccount } from "src/account/models/account-data";
import { AccountService } from "src/account/services/account.service";
import { Router, ActivatedRoute } from "@angular/router";
import { AlertService } from "src/_services/alert.service";
import {
  debounceTime,
  switchMap,
  finalize,
  tap,
} from "rxjs/operators";
import { ClientService } from "src/account/services/client.service";
import { AccountTypeService } from "src/account/services/accountType.service";
import { getState, IState } from 'src/_models/us-state-data';
import { RelationshipService } from 'src/account/services/relationship.service';
import { IRelationship } from 'src/account/models/relationship-data';

@Component({
  selector: "app-add-account",
  templateUrl: "./add-account.component.html",
  styleUrls: ["./add-account.component.css"],
})
export class AddAccountComponent implements OnInit {
  accountForm: FormGroup;

  filteredClients: IClient[] = [];
  selectedClient: IClient;
  client: IClient = { id: 0,name: "Add New Client"};

  filteredClientIsLoadingLabel: string = "Choose a client ";

  relationships: IRelationship[];
  accountTypes: IAccountType[];
  states: IState[] = getState();
  account: IAccount;
  
  id: 0;

  constructor(
    private clientService: ClientService,
    private accountTypeService: AccountTypeService,
    private relationshipService: RelationshipService,
    private router: Router  ) {}

  ngOnInit() {
    this.accountForm = new FormGroup({
      id: new FormControl(0),
      //accountNo: new FormControl('', [Validators.required]),
      selectedClient: new FormControl("", [Validators.required]),
      selectedAccountType: new FormControl("", [Validators.required]),
      firstName: new FormControl("", [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(100),
      ]),
      middleName: new FormControl("", [
        Validators.minLength(4),
        Validators.maxLength(100),
      ]),
      lastName: new FormControl("", [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(100),
      ]),
      phone: new FormControl(""),
      email: new FormControl("", [Validators.email]),
      address1: new FormControl("", [Validators.maxLength(100)]),
      address2: new FormControl("", [Validators.maxLength(100)]),
      setectedState: new FormControl("", [
        Validators.maxLength(2),
        Validators.minLength(2),
      ]),
      zipCode: new FormControl("", [
        Validators.maxLength(5),
        Validators.minLength(5),
      ]),
      description: new FormControl("",[Validators.maxLength(400)]),
      note: new FormControl("",[Validators.maxLength(400)]),
      isMain: new FormControl(false),
      selectedRelationship: new FormControl(""),
      //relationshipId: new FormControl(''), //Relationship with main account
      //sortId: new FormControl(''),
      isActive: new FormControl(true),
    });

    this.accountForm
      .get("selectedClient")
      .valueChanges.pipe(
        debounceTime(300),
        tap(() => {
          this.filteredClients = [];
          this.filteredClientIsLoadingLabel = "Choose a client Loading ...";
        }),
        switchMap((value) =>
          this.clientService.search(value, 5).pipe(
            finalize(() => {
              this.filteredClientIsLoadingLabel = "Choose a client ";
            })
          )
        )
      )
      .subscribe((clients) => {
        this.filteredClients = clients;
        this.filteredClients.push(this.client);
      });

    this.accountTypeService.get().subscribe((data) => {
      this.accountTypes = data;
    });

    this.relationshipService.get().subscribe((data) => {
      this.relationships = data;
    });

    
  }

  displayFn(client: IClient) {
    if (client) {
      if (client.id === 0)
        return "";
      // Add New Client Dialog
      this.selectedClient = client;
      return client.name;
    }
    this.selectedClient = { id: 0 };
  }

  onSubmit() {}

  onCancel() {
    this.router.navigate(["/account"]);
  }
}
