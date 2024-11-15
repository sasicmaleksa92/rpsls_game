import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RouterModule } from '@angular/router';
import { RegisterRequestDTO } from '../generated-api-client';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { AccountsService } from '../generated-api-client/api/accounts.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, RouterModule, MatFormFieldModule, MatInputModule, MatLabel, MatButton, MatCardModule, MatDialogModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  accountService = inject(AccountsService);
  dialogRef = inject(MatDialogRef<RegisterComponent>);
  errorMessage?: string = undefined;
  protected registerForm = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });


  onSubmit(){
    if(this.registerForm.valid){
      console.log(this.registerForm.value);
      this.accountService.apiAccountsRegisterPost(this.registerForm.value as RegisterRequestDTO)
      .subscribe({
        next: (result: any) => {
          this.dialogRef.close();
        },
        error: (errorResult) => {
          this.errorMessage = errorResult.error.errors[0].errorMessage
        },
      });
    }
  }
}
