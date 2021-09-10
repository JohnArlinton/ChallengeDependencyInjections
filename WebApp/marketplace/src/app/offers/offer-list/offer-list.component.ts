import { Component, OnInit } from '@angular/core';
import { Page } from 'src/app/PageClass';
import { MarketplaceApiService } from '../../core/marketplace-api/marketplace-api.service'

@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.scss']
})
export class OfferListComponent implements OnInit {

  arrayImages = ['apple2', 'carpooling', 'iphone', 'lantern', 'puff', 'sofa', 'summer-house', ];
  items = [];
  pageOfItems: Array<any>;
  
  pageSize: number = 4;

  buttonsByPage: Array<number>;

  getArrayItems(num: number): Array<any> {
    return new Array(num);
  }

  constructor(private marketplaceApiService: MarketplaceApiService) { }

  paging: Page<any>;

  ngOnInit(): void {
    console.log(this.marketplaceApiService);
    this.get();
    this.items = Array(150).fill(0).map((x, i) => ({ id: (i + 1), name: i + 1, image: this.arrayImages[Math.floor(Math.random() * this.arrayImages.length)]}));

    var pageCount = Math.ceil(this.items.length / this.pageSize);
    this.paging = new Page<any>(this.items, 1, pageCount, this.pageSize)
    console.log(this.paging);
    this.pageButtons();
  }

  async get(): Promise<void> {
    console.log(await this.marketplaceApiService.getOffers());
  }

  onChangePage(pageOfItems: Array<any>) {
    console.log(pageOfItems);
    this.pageOfItems = pageOfItems;
  }

  pageButtons(){
    if(this.paging.pageCount <= 7){
      this.buttonsByPage = new Array<number>(this.paging.pageCount).fill(0).map((x, i) => i+1);
    }else{
      this.buttonsByPage = new Array<number>(7).fill(0).map((x, i) => i+1);
    }
    console.log(this.buttonsByPage);
  }

  changeButtonsPage(button: number){
    if(this.buttonsByPage.length === 7){
      var difference = button - this.buttonsByPage[3];
      var checkValidation = false;
      this.buttonsByPage.forEach(el => {
        if(el + difference > this.paging.pageCount){
          checkValidation = true;
          this.buttonsByPage = new Array<number>(7).fill(0).map((x, i) => this.paging.pageCount-i).reverse();
        }else if(el + difference <= 0){
          checkValidation = true;
          this.buttonsByPage = new Array<number>(7).fill(0).map((x, i) => i+1);
        }
      });
      if(button+difference >= this.paging.pageCount){
        difference = this.paging.pageCount - button;
      } else if(button+difference < 1){
        difference = 1 - button;
      }
      this.buttonsByPage = !checkValidation ? this.buttonsByPage.map(el => el + difference) : this.buttonsByPage;
    }
    this.paging.setPageIndex(button);
  }
}
