import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/account/services/account.service';
import { AlertService } from 'src/_services/alert.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-account',
  templateUrl: './list-account.component.html',
  styleUrls: ['./list-account.component.css']
})
export class ListAccountComponent implements OnInit {

  constructor(
    private accountService: AccountService,
    private alertService: AlertService,
    private route: Router
  ) { }

  ngOnInit() {
  }

  onAddNew() {
    this.route.navigate(['/addAccount']);
  }

  onExport() {
    this.accountService.export().subscribe((data) => {
      saveAs(data.body, data.headers.get('Content-Disposition').split(';')[1].replace('filename="','').replace('"',''));
    });
  }
}
