import { Component, inject } from '@angular/core';
import { GameChoiceDto, GameService } from '../generated-api-client';
import { RouterOutlet } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatButtonToggle, MatButtonToggleGroup } from '@angular/material/button-toggle';
import { MatDivider, MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { GameResultsStore } from '../stores/gameResults.store';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { DialogConfig } from '@angular/cdk/dialog';
import { GameResultEnum } from '../enums/gameResultEnum';
import { AuthService } from '../services/auth.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-game-form',
  standalone: true,
  imports: [FormsModule, RouterOutlet, MatTableModule, MatCardModule, MatButtonToggleGroup, MatButtonToggle, MatDivider, MatButtonModule, MatDividerModule, MatIconModule, CommonModule],
  templateUrl: './game-form.component.html',
  styleUrl: './game-form.component.scss'
})

export class GameFormComponent {
  authService = inject(AuthService);
  constructor(private gameService: GameService,
    private store: GameResultsStore,
    private snackBar: MatSnackBar,
    private dialog: MatDialog) {
      
      this.gameService.apiGameChoicesGet().subscribe(result => {
        this.gameChoices = result;
      })
  }

  playerChoiceValue: number = 0;
  numberOfWins: number = 0;
  numberOfLosts: number = 0;
  numberOfTies: number = 0;
  gameChoices: GameChoiceDto[] = [];

  get isLoggedIn() : boolean {
    var isLoggedIn =  this.authService.isLoggedIn();
    return isLoggedIn;
  }

  playDisabled() : boolean {
    return this.playerChoiceValue == 0;
  }

  private getDialogConfig() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true; // Prevents closing the dialog by clicking outside
    dialogConfig.autoFocus = false;   // Disable autofocus to manually control focus
    dialogConfig.width = '80%';       // Set the width of the dialog
    return dialogConfig;
  }

  submit() {
    this.gameService.apiGamePlayPost({ player: this.playerChoiceValue }).subscribe({
      next: (result) => {
        this.store.create(result);
      },
      error: (error) => {
        this.snackBar.open(error.error, 'Close');
      },
    })

  }
  openLoginDialog(): void {
    const dialogConfig = this.getDialogConfig();
    const loginDialog = this.dialog.open(LoginComponent, dialogConfig);

    loginDialog.afterClosed().subscribe(result => {
      this.playerChoiceValue = 0;
    });
  }

  openRegisterDialog(): void {
    const dialogConfig = this.getDialogConfig();
    const registerDialog = this.dialog.open(RegisterComponent, dialogConfig);
    registerDialog.afterClosed().subscribe(result => {
    });
  }

  logout(){
    this.authService.logout();
    this.playerChoiceValue = 0;
  }

  resetScore(){

  }
}
