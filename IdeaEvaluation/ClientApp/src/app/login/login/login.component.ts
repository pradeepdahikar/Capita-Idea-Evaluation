import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormsModule } from '@angular/forms'
import { HttpClientModule, HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../../Classes/User'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  _form: FormGroup;
  _inValidForm: boolean = false;

  constructor(
    private _httpClinet: HttpClient,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.createForm();
  }

  ngOnInit(): void {
  }

  createForm() {
    this._form = this.fb.group({
      UserName: ['', Validators.required],
      Password: ['', [Validators.required]]
    });
  }

  login() {
    debugger;
    if (this._form.invalid) {
      this._inValidForm = true
      return;
    }
    this._inValidForm = false;
    const user = new User();
    user.Id = 0;
    user.UserName = this._form.controls['UserName'].value;
    user.Password = this._form.controls['Password'].value

    const _headers = new HttpHeaders().set('content-type', 'application/json');
    let options = {
      headers: _headers
    };
    this._httpClinet.post("https://localhost:44346/api/Login", user, options)
      .subscribe(
        data => {
          debugger;
          if (data > 0) {
            debugger;
            console.log('login Successfull');
            this.router.navigate(['/IdeaEvaluation', data]);
          }
          else if (data == false) {
            alert("Invalid User Name or Password.");
          }
        },
        error => {
          alert("Invalid User Name or Password.");
        }
      );
  }

}
