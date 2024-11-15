import { Component, inject, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatButtonToggle, MatButtonToggleGroup } from '@angular/material/button-toggle';
import { MatDivider, MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { GameResultsStore } from '../stores/gameResults.store';
import {MatSort, MatSortModule} from '@angular/material/sort';
import { GameResultDto, GameService } from '../generated-api-client';
import { GameResultEnum } from '../enums/gameResultEnum';
import { MatBadgeModule } from '@angular/material/badge';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-games-list',
  standalone: true,
  imports: [RouterOutlet, MatTableModule, MatCardModule, MatButtonToggleGroup, MatButtonToggle, MatDivider, MatButtonModule, MatDividerModule, MatIconModule, MatSortModule, MatBadgeModule],
  templateUrl: './games-list.component.html',
  styleUrl: './games-list.component.scss'
})
export class GamesListComponent {
  numberOfWins: number = 0;
  numberOfLosts: number = 0;
  numberOfTies: number = 0;
  userName: string = "Guest";
  userId: number | null = null;
  authService = inject(AuthService);
  gameService = inject(GameService);
  constructor(public store: GameResultsStore) {
    this.authService.currentUser.subscribe(currentUser=> {
      this.store.deleteAll();
      if (currentUser){
        this.store.fetchAllForPlayer(currentUser.id!)
        this.userName = currentUser.userName!;
        this.userId = currentUser.id!;
      }else{
        this.userName = "Guest"
      }
      
      this.store.all$.subscribe(gameResults => {
        this.numberOfWins = gameResults.filter(x => x.results == "Win").length;
        this.numberOfLosts = gameResults.filter(x => x.results == "Lose").length;
        this.numberOfTies = gameResults.filter(x => x.results == "Tie").length;
      })
    })

  }

  displayedColumns: string[] = ['playerChoiceName','computerChoiceName','results', 'time'];


  resetScoreborad(){
    if(this.userId){
      this.gameService.apiGameUpdateGameResultPatch({
        playerId : this.userId!,
        includeInScore: false
      }).subscribe(res => 
        this.store.deleteAll()
      )
    }else{
      this.store.deleteAll();
    }

  }

}
