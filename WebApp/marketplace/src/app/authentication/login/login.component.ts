import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl, FormBuilder, Validators} from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private formBuilder: FormBuilder) { }

  loginForm!: FormGroup;

  roles: any;

  roleSelected: any;

  users: any;

  async ngOnInit(): Promise<void>{

    this.loginForm = this.formBuilder.group({
      title: new FormControl('', [Validators.required]),
      pictureUrl: new FormControl('', [Validators.required]),
      description: new FormControl('', [Validators.required]),
      location: new FormControl('', [Validators.required]),
      categoryId: new FormControl(1, [Validators.required]),
      // roleId: new FormControl(0, [Validators.required]),
    });
  }

  submit(){
    if(this.loginForm.status === 'VALID'){
      console.log(this.loginForm.value);
    }
  }

  getErrorMessage(error: any) {
    if(error){
      return error.hasOwnProperty('required') ? 'You must enter a value' : error.hasOwnProperty('email') ? 'Not a valid email' : '';
    }
    return ''
  }
}
