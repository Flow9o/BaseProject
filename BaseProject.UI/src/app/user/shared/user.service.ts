import {inject, Injectable} from '@angular/core';
import {User, UserGeneratedService} from '@api/baseproject';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly userService = inject(UserGeneratedService)

  createUser(user : User) {
    return this.userService.createUser(user);
  }

  getAllUsers() {
    return this.userService.getAllUsers();
  }
}
