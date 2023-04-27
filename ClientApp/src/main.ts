import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { SERVER_SIDE } from '@mintplayer/ng-server-side';
import { StaticProvider } from '@angular/core';

function bootstrap() {
  const providers: StaticProvider[] = [
    { provide: SERVER_SIDE, useValue: false },
  ];

  platformBrowserDynamic(providers)
    .bootstrapModule(AppModule)
    .catch((err) => console.error(err));
}

if (document.readyState === 'complete') {
  bootstrap();
} else {
  document.addEventListener('DOMContentLoaded', bootstrap);
}
