export class HttpResponseModel {
    statusCode: number = 200;
    wasSuccessful: boolean = false;
    statusMessage: string ="";
    data: any;
}