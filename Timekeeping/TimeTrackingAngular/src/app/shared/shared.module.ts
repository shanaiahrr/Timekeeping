import { NgModule } from '@angular/core';

import { MenuItems } from './menu-items/menu-items';
import {
  AccordionAnchorDirective,
  AccordionLinkDirective,
  AccordionDirective
  
} from './accordion';
import { CancelDialogComponent } from './dialog/cancel-dialog/cancel-dialog.component';
import { DemoMaterialModule } from '../demo-material-module';

@NgModule({
  declarations: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    CancelDialogComponent
  ],
  imports:[
    DemoMaterialModule,

  ],
  exports: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    CancelDialogComponent
  ],
  entryComponents: [CancelDialogComponent],
  providers: [MenuItems]
})
export class SharedModule {}
