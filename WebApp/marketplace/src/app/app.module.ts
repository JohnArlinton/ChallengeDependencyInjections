import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { OfferListComponent } from './offers/offer-list/offer-list.component'
import { OfferCreationComponent } from './offers/offer-creation/offer-creation.component'
import { OfferItemComponent } from './offers/offer-item/offer-item.component'
import { LoginComponent } from './authentication/login/login.component'
import { JwPaginationModule } from 'jw-angular-pagination';

import { MarketplaceApiService } from './core/marketplace-api/marketplace-api.service'

@NgModule({
  declarations: [
    AppComponent,
    OfferCreationComponent,
    OfferListComponent,
    OfferItemComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatCardModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
    FormsModule,
    JwPaginationModule
  ],
  providers: [MarketplaceApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
