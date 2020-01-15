import { Component, OnInit } from '@angular/core';
import { AuthHelper } from '../../helpers/auth-helper';

@Component({
  selector: 'app-navagation',
  templateUrl: './navagation.component.html',
  styleUrls: ['./navagation.component.css']
})
export class NavagationComponent implements OnInit {

  constructor(
    private authHelper: AuthHelper
  ) { }

  ngOnInit() {
  }
  logout(): void {
    this.authHelper.logout();
  }

}
