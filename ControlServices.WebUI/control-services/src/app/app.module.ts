import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutNavBarComponent } from './shared/layout-nav-bar/layout-nav-bar.component';
import { LayoutMenuComponent } from './shared/layout-menu/layout-menu.component';
import { LayoutFooterComponent } from './shared/layout-footer/layout-footer.component';

@NgModule({
  declarations: [
    AppComponent,
    LayoutNavBarComponent,
    LayoutMenuComponent,
    LayoutFooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent, LayoutMenuComponent, LayoutNavBarComponent, LayoutFooterComponent]
})
export class AppModule { }
