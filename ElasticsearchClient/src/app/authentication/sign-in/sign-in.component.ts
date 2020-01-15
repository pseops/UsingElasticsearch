import { Component, OnInit } from '@angular/core';
import { RequestGetAuthenticationView } from 'src/app/shared/models';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthHelper } from 'src/app/shared/helpers/auth-helper';
import { ManagmentHelper } from 'src/app/shared/helpers/managment-helper';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  signInView: RequestGetAuthenticationView;
  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    public authHelper: AuthHelper,
    private managementHelper: ManagmentHelper
  ) {
    this.signInView = new RequestGetAuthenticationView();

    this.buildForm();
    this.setScreen();
  }

  ngOnInit() {
  }

  private setScreen(): void {
    this.managementHelper.setScreenType(null);
  }

  private buildForm(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(5)]]
    });
  }
  onSubmit(): void {

    if (this.loginForm.invalid) {
      return;
    }

    // this.accountService.signIn(this.loginModel);
    this.authHelper.signIn(this.signInView);
  }
}
