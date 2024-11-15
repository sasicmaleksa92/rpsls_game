export * from './account.service';
import { AccountService } from './account.service';
export * from './game.service';
import { GameService } from './game.service';
export const APIS = [AccountService, GameService];
