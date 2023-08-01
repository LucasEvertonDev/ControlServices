import { Component, OnInit, AfterViewInit } from '@angular/core';
import { SCRIPTS } from 'src/app/common/constants/scripts-constants';
import { ScriptsService } from 'src/app/common/services/scripts/scripts.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit, AfterViewInit{

  public constructor(private _scripts:ScriptsService) {
  }

  public ngAfterViewInit(): void {
    this._scripts.load(SCRIPTS.THEME_HELPERS, SCRIPTS.THEME_CONFIG, SCRIPTS.JQUERY, SCRIPTS.POPPER, SCRIPTS.BOOTSTRAP, SCRIPTS.PERFECT_SCROOL_BAR, SCRIPTS.THEME_MENU, SCRIPTS.THEME_MAIN, SCRIPTS.THEME_BUTTON);
  }

  public ngOnInit(): void {
  }
}
