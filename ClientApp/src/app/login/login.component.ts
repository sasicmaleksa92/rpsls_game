import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { LoginRequestDTO, LoginResponseDTO } from '../generated-api-client';
import { inject } from '@angular/core';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButton } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { AuthService } from '../services/auth.service';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { AccountsService } from '../generated-api-client/api/accounts.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule, MatFormFieldModule, MatInputModule, MatLabel, MatButton, MatCardModule, MatDialogModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {
  accountService = inject(AccountsService);
  authService = inject(AuthService);
  protected loginForm = new FormGroup({
    userName: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });
  errorMessage?: string = undefined;
  dialogRef = inject(MatDialogRef<LoginComponent>);

  onSubmit() {
    if (this.loginForm.valid) {
      console.log(this.loginForm.value);
      this.accountService.apiAccountsLoginPost(this.loginForm.value as LoginRequestDTO)
        .subscribe({
          next: (res: LoginResponseDTO) => {
            this.authService.setAccessToken(res.accessToken!);
            this.authService.setUser(res.user!)
            this.dialogRef.close();
          },
          error: (errorResult) => {
            this.errorMessage = errorResult.error.message
          },
        });
    }
  }

}
