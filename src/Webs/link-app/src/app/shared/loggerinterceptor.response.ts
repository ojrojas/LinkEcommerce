import { HttpErrorResponse, HttpInterceptorFn } from "@angular/common/http";
import { inject } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { LoggerSeqService } from "./logger.seq";

export const LoggerErrorResponseInterceptor: HttpInterceptorFn = (req, next) => next(req).pipe(catchError(handleErrorResponse));

function handleErrorResponse(error: HttpErrorResponse): ReturnType<typeof throwError> {
  // const logger = inject(LoggerSeqService);
  const errorResponse = `{Error: {
    code: ${error.status},
    type: ${error.type},
    message: ${error.message},
    thing: ${error.headers.keys() + error.statusText}
  }}`;

  // logger.logError(errorResponse);
  return throwError(() => errorResponse);
}
