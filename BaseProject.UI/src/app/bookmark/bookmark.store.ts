import {patchState, signalStore, withMethods, withState} from '@ngrx/signals';
import {BookmarkService} from './shared/bookmark.service';
import {inject} from '@angular/core';
import {firstValueFrom} from 'rxjs';
import {Bookmark} from '@api/baseproject';

type BookmarkState = {
  allBookmarks: Bookmark[]
};

const initialState: BookmarkState = {
  allBookmarks: []
};

export const BookmarkStore = signalStore(
  withState<BookmarkState>(initialState),
  withMethods(store => {
    const bookmarkService = inject(BookmarkService)

    const createBookmark = async (user: Bookmark) => {
      return await firstValueFrom(bookmarkService.createBookmark(user));
    }

    const getAllBookmarks = async () => {
      const res =  await firstValueFrom(bookmarkService.getAllBookmarks());
      patchState(store, {allBookmarks : res})
    }

    const assignBookmarkToUser = async (bookmarkId: number, userId: number) => {
      return await firstValueFrom(bookmarkService.assignBookmarkToUser(bookmarkId, userId));
    }

    return {
      getAllBookmarks,
      createBookmark,
      assignBookmarkToUser
    };
  }),
);
