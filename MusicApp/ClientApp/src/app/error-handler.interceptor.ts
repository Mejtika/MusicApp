import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { MessageService } from 'primeng/api';

@Injectable({
  providedIn: 'root',
})
export class ErrorHandlerInterceptor implements HttpInterceptor {
  constructor(private messageService: MessageService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((errorResponse: HttpErrorResponse) => {
        const errors: string[] = errorResponse.error.errors.reduce((messages: string[], error: any) =>{
            messages.push(error.message);
            return messages;
        }, []).join("\r\n");
        this.messageService.add({
          severity: 'error',
          summary: 'Wystąpił błąd',
          detail: `${errors}`,
        });
        return throwError(errorResponse);
      })
    );
  }
}
