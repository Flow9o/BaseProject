import {Component, inject, OnInit} from '@angular/core';
import {UserStore} from './user/user.store';
import {JsonPipe} from '@angular/common';
import {NavbarComponent} from './nav/navbar.component';
import {BookmarkStore} from './bookmark/bookmark.store';
import { User, Bookmark } from '@api/baseproject';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {WrappedFormControls} from './baseproject.types';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: true,
  imports: [
    JsonPipe,
    NavbarComponent,
    ReactiveFormsModule,
  ],
  providers: [UserStore, BookmarkStore]
})
export class AppComponent implements OnInit {
  private readonly userStore = inject(UserStore)
  private readonly bookmarkStore  = inject(BookmarkStore)

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

  async createUser() {
    const newUser: User = {
      firstName: 'Max',
      lastName: 'Mustermann',
      eMail: 'max.mustermann@example.com',
      password: 'Test1234!'
    };

    await this.userStore.createUser(newUser)
    await this.reloadAll()
  }

  async createBookmark() {
    const newBookmark: Bookmark = {
      name: 'ChatGPT',
      link: 'https://chat.openai.com',
      createdAt: new Date().toISOString(),
      createdBy: 'admin',
      modifiedAt: null,
      modifiedBy: null
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
