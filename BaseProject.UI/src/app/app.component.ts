import {Component, inject, OnInit} from '@angular/core';
import {UserStore} from './user/user.store';
import {JsonPipe} from '@angular/common';
import {NavbarComponent} from './nav/navbar.component';
import {BookmarkStore} from './bookmark/bookmark.store';
import {User, Bookmark, Car} from '@api/baseproject';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {WrappedFormControls} from './baseproject.types';
import {CarService} from './car/car.service';
import {firstValueFrom} from 'rxjs';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: true,
  imports: [
    JsonPipe,
    NavbarComponent,
    ReactiveFormsModule,
  ],
  providers: [UserStore, BookmarkStore, CarService],
})
export class AppComponent implements OnInit {
  private readonly userStore = inject(UserStore)
  private readonly bookmarkStore  = inject(BookmarkStore)
  private readonly carService = inject(CarService)

  allUsers = this.userStore.allUser
  allBookmarks = this.bookmarkStore.allBookmarks

  assignBookmarkToUserForm = new FormGroup<WrappedFormControls<{ bookmarkId : number | null, userId : number | null }>>({
    bookmarkId : new FormControl<number | null>(null, Validators.required),
    userId : new FormControl<number | null>(null, Validators.required)
  })

  constructor() {
    const x= this.userStore.allUser;
  }

  async ngOnInit() {
   await this.reloadAll()
  }

  async reloadAll() {
    await this.userStore.getAllUsers()
    await this.bookmarkStore.getAllBookmarks()

  }

  async createCar(){
    const newCar: Car ={
      id:0,
      brandName: 'Audi',
      modelName: 'RS6',
      power: 600,
      vmax: 305
    };

    await firstValueFrom(this.carService.createCar(newCar));
    // const myCar = await firstValueFrom(this.carService.GetCar(id));



  }
  async createUser() {
    const newUser: User = {
      id: 0,
      firstName: 'Max',
      lastName: 'Mustermann',
      eMail: 'max.mustermann@example.com',
      password: 'Test1234!',
      bookmarks: []
    };

    await this.userStore.createUser(newUser)
    await this.reloadAll()
  }

  async createBookmark() {
    const newBookmark: Bookmark = {
      id: 0,
      name: 'ChatGPT',
      link: 'https://chat.openai.com',
      createdAt: new Date().toISOString(),
      createdBy: 'admin',
      modifiedAt: null,
      modifiedBy: null,
      users : null
    };

    await this.bookmarkStore.createBookmark(newBookmark)
    await this.reloadAll()
  }

  async assignBookmarkToUser() {
    const form = this.assignBookmarkToUserForm.getRawValue()

    if(form.userId == null || form.bookmarkId == null) return;

    await this.bookmarkStore.assignBookmarkToUser(form.bookmarkId, form.userId)

    await this.reloadAll()
  }
}
