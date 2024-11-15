import { Injectable } from '@angular/core';
import { GameService } from '../generated-api-client';
import { createStore } from '@ngneat/elf';
import {
  addEntities,
  deleteAllEntities,
  selectAllEntities, setEntities,
  withActiveId,
  withEntities
} from '@ngneat/elf-entities';
import { map } from 'rxjs';
import { GameResultDto } from '../generated-api-client/model/gameResultDto';

const gameResultStore = createStore(
  { name: 'gameResults' },
  withEntities<GameResultDto>()
);

@Injectable({
  providedIn: 'root',
})
export class GameResultsStore {
  public all$ = gameResultStore.pipe(selectAllEntities(),
  map((entities) => entities.sort((a, b) => b.id - a.id)));

  playerId: number | undefined;
  constructor(private api: GameService) {

  }
  public deleteAll = () =>
    gameResultStore.update(deleteAllEntities());


  public fetchAll = () =>
  new Promise((resolve) => {
    this.api.apiGameAllGamesGet().subscribe((items: any) => {
      gameResultStore.update(setEntities(items));
      resolve(this.all$);
    });
  });

  public fetchAllForPlayer = (playerId: number) =>
    new Promise((resolve) => {
      this.api.apiGameAllPlayerGamesGet(playerId).subscribe((items) => {
        gameResultStore.update(setEntities(items));
        resolve(this.all$);
      });
    });
  
  public create(gameResultDto: GameResultDto | any) {
    gameResultStore.update(addEntities(gameResultDto));
  }
  
}
