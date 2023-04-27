import { Component, Inject } from '@angular/core';
import { SERVER_SIDE } from '@mintplayer/ng-server-side';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  /**
   *
   */
  constructor(@Inject(SERVER_SIDE) serverSide: boolean) {
    this.serverSide = serverSide;
  }

  title = 'ClientApp';
  serverSide: boolean;
}
