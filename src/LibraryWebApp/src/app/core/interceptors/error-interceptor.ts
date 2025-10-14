import { HttpErrorResponse, HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { AuthService } from "../../feature/auth/services/auth-service";
import { catchError, throwError } from "rxjs";

export const errorInterceptor: HttpInterceptorFn = (req, next) => {

//   const notificationService = inject(NotificationService);
  const authService = inject(AuthService); 

  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      switch (error.status) {
        case 401:
          console.error('NO Autorizado', error.message);
          break;
        case 404:
          console.error('Recurso no encontrado', error.message);
          //notificationService.notify("No se encontró el recurso solicitado, estamos trabajando para solucionarlo");
          break;
        case 0:
          console.error('No hay conexion con el servidor', error.message);
          //notificationService.notify("No hay conexion con el servidor");
          break;
      }
      return throwError(() => error);
    }));
};
