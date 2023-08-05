import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from '../theme/layout/layout.component';
import { LayoutAccountComponent } from '../theme/layout-account/layout-account.component';
import { LayoutFooterComponent } from '../theme/layout-footer/layout-footer.component';
import { LayoutMenuComponent } from '../theme/layout-menu/layout-menu.component';
import { LayoutNavBarComponent } from '../theme/layout-nav-bar/layout-nav-bar.component';


@NgModule({
  declarations: [
    LayoutComponent,
    LayoutAccountComponent,
    LayoutFooterComponent,
    LayoutMenuComponent,
    LayoutNavBarComponent
  ],
  exports: [
    LayoutComponent,
    LayoutAccountComponent,
    LayoutFooterComponent,
    LayoutMenuComponent,
    LayoutNavBarComponent
  ],
  imports: [
    CommonModule,
  ]
})
export class LayoutModule { }
