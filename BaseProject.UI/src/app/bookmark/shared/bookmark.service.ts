import {inject, Injectable} from '@angular/core';
import {Bookmark, BookmarkGeneratedService} from '@api/baseproject';

@Injectable({
  providedIn: 'root',
})
export class BookmarkService {
  private readonly bookmarkService = inject(BookmarkGeneratedService)

  createBookmark(bookmark : Bookmark) {
    return this.bookmarkService.createBookmark(bookmark);
  }

  getAllBookmarks() {
    return this.bookmarkService.getAllBookmarks();
  }

  assignBookmarkToUser(bookmarkId : number, userId : number) {
    return this.bookmarkService.assignBookmarkToUser(bookmarkId, userId)
  }
}
