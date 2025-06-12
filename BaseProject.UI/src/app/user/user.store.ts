import {patchState, signalStore, withComputed, withHooks, withMethods, withState} from "@ngrx/signals";
import {computed, inject} from '@angular/core';
import {firstValueFrom} from 'rxjs';
import {UserService} from './shared/user.service';
import {User} from '@api/baseproject';

type UserState = {
  allUser : User[]
};

const initialState: UserState = {
  allUser: []
};

export const UserStore = signalStore(
  withState<UserState>(initialState),
  withMethods(store => {
    const userService = inject(UserService)

    const createUser = async (user: User) => {
      return await firstValueFrom(userService.createUser(user));
    }

    const getAllUsers = async () => {
      const res = await firstValueFrom(userService.getAllUsers());
      patchState(store, {allUser : res})
    }

    return {
      getAllUsers,
      createUser,
    };
  }),
);
