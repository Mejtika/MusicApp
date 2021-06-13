import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { UserForCreate } from '../../services/users/interfaces';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css'],
})
export class CreateUserComponent implements OnInit {
  createForm!: FormGroup;
  constructor(private fb: FormBuilder, public activeModal: NgbActiveModal) {}

  ngOnInit() {
    this.createForm = this.fb.group({
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  createUserSubmit(form: FormGroup) {
    let newUser: UserForCreate = {
      userName: form.value.userName,
      email: form.value.email,
      password: form.value.password,
    };
    this.activeModal.close(newUser);
  }
}
