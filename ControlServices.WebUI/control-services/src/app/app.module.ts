import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutNavBarComponent } from './shared/theme/layout-nav-bar/layout-nav-bar.component';
import { LayoutMenuComponent } from './shared/theme/layout-menu/layout-menu.component';
import { LayoutFooterComponent } from './shared/theme/layout-footer/layout-footer.component';
import { LayoutComponent } from './shared/theme/layout/layout.component';
import { LayoutAccountComponent } from './shared/theme/layout-account/layout-account.component';


@NgModule({
  declarations: [
    AppComponent,
    LayoutNavBarComponent,
    LayoutMenuComponent,
    LayoutFooterComponent,
    LayoutComponent,
    LayoutAccountComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
