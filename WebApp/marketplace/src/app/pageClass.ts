export class Page<T> {

  allItems: Array<T>;
  currentItems: Array<T>;
  pageSize: number;
  pageCount: number;
  pageIndex: number;
  nextPageIndex: number;
  previousPageIndex: number;

  constructor(items: Array<T>, pageIndex: number, pageCount: number, pageSize: number){
    this.allItems = items;
    this.pageIndex = pageIndex;
    this.pageSize = pageSize;
    this.pageCount = pageCount;
    this.previousPageIndex = this.pageIndex - 1 < 0 ? null : this.pageIndex - 1;
    this.nextPageIndex = this.pageIndex + 1 > this.pageCount ? null : this.pageIndex + 1;

    this.currentItems = this.allItems.slice(0, this.pageSize);
  }

  getNextPageIndexes(): Array<number>{
    return [this.pageIndex+2, this.pageIndex+1, this.pageIndex];
  }

  getPreviousPageIndexes(): Array<number>{
    return [this.pageIndex-2, this.pageIndex-1, this.pageIndex];
  }

  setPageIndex(pageIndex: number): void{
    this.pageIndex = pageIndex;
    this.previousPageIndex = this.pageIndex - 1 < 0 ? null : this.pageIndex - 1;
    this.nextPageIndex = this.pageIndex + 1 > this.pageCount ? null : this.pageIndex + 1;

    this.currentItems = this.allItems.slice(this.pageSize*this.previousPageIndex, this.pageSize*this.pageIndex);
  }
}