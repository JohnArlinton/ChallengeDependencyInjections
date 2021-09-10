import {Injectable} from '@angular/core';
import {Observable, of} from 'rxjs';
import {OfferModel} from './models/offer.model';
import Api from './Api'

@Injectable()
export class MarketplaceApiService {

  private readonly marketplaceApUrl = '';

  constructor() { }

  async getOffers(): Promise<OfferModel[]> {
    // TODO: implement the logic to retrieve paginated offers from the service
    return await Api().get('/Offers/') as OfferModel[];
  }

  async postOffer(params: any): Promise<OfferModel[]> {
    // TODO: implement the logic to post a new offer, also validate whatever you consider before posting
    return await Api().get('/Offers/') as OfferModel[];
  }

  getCategories(): Observable<string[]> {
    // TODO: implement the logic to retrieve the categories from the service
    return of([]);
  }
}
