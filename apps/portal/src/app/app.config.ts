import { HttpClient, provideHttpClient, withInterceptors } from '@angular/common/http';
import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { provideAnimations } from '@angular/platform-browser/animations';
import {
  provideRouter,
  withEnabledBlockingInitialNavigation,
  withHashLocation,
} from '@angular/router';
import { Ability, PureAbility } from '@casl/ability';
import { createPrismaAbility } from '@casl/prisma';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { authInterceptorFn, token } from '@zen/auth';
import { Environment } from '@zen/common';
import { ZenGraphQLModule } from '@zen/graphql';
import { possibleTypes, typePolicies } from '@zen/graphql/client';

import { environment } from '../environments/environment';
import { APP_ROUTES } from './app.routes';

export function createTranslateLoader(http: HttpClient) {
  return new TranslateHttpLoader(http, '/assets/i18n/', '.json');
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideAnimations(),
    provideHttpClient(withInterceptors([authInterceptorFn])),
    provideRouter(APP_ROUTES, withEnabledBlockingInitialNavigation(), withHashLocation()),
    { provide: Environment, useValue: environment },
    { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'outline' } },
    {
      provide: Ability,
      useValue: createPrismaAbility(undefined, {
        detectSubjectType: object => object['__typename'],
      }),
    },
    { provide: PureAbility, useExisting: Ability },
    importProvidersFrom(
      ZenGraphQLModule.forRoot({
        cacheOptions: {
          possibleTypes,
          typePolicies,
        },
        batchOptions: {
          uri: environment.url.graphql,
          batchMax: 250,
        },
        uploadOptions: {
          uri: environment.url.graphql,
          mutationNames: ['SampleUpload', 'SampleUploadMany'],
          headers: { 'Apollo-Require-Preflight': 'true' },
          fetch: (input: any, init: any) => {
            init.headers['Authorization'] = 'Bearer ' + token();
            return fetch(input, init);
          },
        },
        websocketOptions: {
          url: environment.url.graphqlSubscriptions,
          connectionParams: () => ({ token: token() }),
          shouldRetry: () => true,
          retryAttempts: Infinity,
        },
      }),
      TranslateModule.forRoot({
        defaultLanguage: environment.defaultLanguage,
        loader: {
          provide: TranslateLoader,
          useFactory: createTranslateLoader,
          deps: [HttpClient],
        },
      })
    ),
  ],
};
