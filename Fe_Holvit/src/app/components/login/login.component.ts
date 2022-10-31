import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  loading = false;
  hide = true;

  constructor(private fb: FormBuilder, private _snackBar: MatSnackBar, private router: Router, private api: ApiService ) {
    this.form = this.fb.group({
      user: ['', Validators.required],
      password: ['', Validators.required],
    })
   }

  ngOnInit(): void {
  }

  login() {
    this.api.getUser()
    .subscribe((res) => {
        const User = res.find((a:any) => {
          return a.user === this.form.value.user && a.password === this.form.value.password
        });
        if(User){
          this.fakeloading();
        } else {
          this.error();
          this.form.reset();
        }
    })
  }
  
  error() {
    this._snackBar.open('Usuario o contraseña son inválidos', '', {
      duration: 4000,
      horizontalPosition: 'center',
      verticalPosition: 'top',
    });
  }

  fakeloading() {
    this.loading = true;
    setTimeout(
      () => {
        this.router.navigate(['dashboard'])
      }, 1500);
  }

}
