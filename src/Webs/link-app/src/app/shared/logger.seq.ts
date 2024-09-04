import { Injectable } from "@angular/core";
// import winston, { Logger } from 'winston';
// import { SeqTransport } from '@datalust/winston-seq';

@Injectable({ providedIn: "root" })
export class LoggerSeqService {
  // logger: Logger | undefined = undefined;
  // constructor() {
  //   this.logger = winston.createLogger({
  //     level: 'info',
  //     format: winston.format.combine(  /* This is required to get errors to log with stack traces. See https://github.com/winstonjs/winston/issues/1498 */
  //       winston.format.errors({ stack: true }),
  //       winston.format.json(),
  //     ),
  //     defaultMeta: { application: "Web Angular" },
  //     transports: [
  //       new winston.transports.Console({
  //         format: winston.format.simple(),
  //       }),
  //       new SeqTransport({
  //         serverUrl: '/seq',
  //         onError: (e => { console.error(e) }),
  //         handleExceptions: true,
  //         handleRejections: true,
  //       })
  //     ]
  //   });
  // }

  // logInfo(message: any) {
  // this.logger?.info(message);
  // }

  // logDebug(message:any) {
  //   // this.logger?.debug(message);
  // }

  // logError(message: any) {
  //   // this.logger?.error(message);
  // }
}
