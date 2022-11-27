import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  
  @Output() formDataMail: EventEmitter<{email: string;password: string;}> = new EventEmitter();
  @Output() Google: EventEmitter<any> = new EventEmitter();
  @Output() Facebook: EventEmitter<any> = new EventEmitter();
  @Output() Twitter: EventEmitter<any> = new EventEmitter();

  iForm: FormGroup;

  constructor(private iFormBuilder: FormBuilder) { }

  ngOnInit(): void {

    this.iForm = this.iFormBuilder.group({
      email:    ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  get email() {
    return this.iForm.get('email');
  }

  get password() {
    return this.iForm.get('password');
  }

  onEmail() {
    this.formDataMail.emit(this.iForm.value);
  }

  onGoogle() {    
    this.Google.emit();
  }

  onFacebook() {
    this.Facebook.emit();
  }

  onTwitter() {
    this.Twitter.emit();
  }
}
