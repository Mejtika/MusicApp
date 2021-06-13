import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { User } from 'src/app/services/users/interfaces';
import { UserForUpdate } from '../../services/users/interfaces';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.css'],
})
export class UpdateUserComponent implements OnInit {
  updateForm!: FormGroup;
  @Input() user!: User;
  constructor(private fb: FormBuilder, public activeModal: NgbActiveModal) {}
  
  public noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { 'whitespace': true };
}
  ngOnInit() {
    this.updateForm = this.fb.group({
      userName: [this.user.userName, [Validators.required, this.noWhitespaceValidator]],
      email: [this.user.email, [Validators.required, Validators.email]],
      emailConfirmed: [this.user.emailConfirmed],
      password: [''],
    });
  }

  updateUserSubmit(form: FormGroup) {
    const userToUpdate: UserForUpdate = {
      id: this.user.id,
      userName: form.value.userName,
      email: form.value.email,
      emailConfirmed: form.value.emailConfirmed,
      password: form.value.password
    };
    this.activeModal.close(userToUpdate);
  }
}
