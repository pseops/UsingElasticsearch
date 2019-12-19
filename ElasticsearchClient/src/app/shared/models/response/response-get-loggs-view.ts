export class ResponseGetLoggsViewItem {
  id: number;
  creationDate: Date | string;
  request: string;
  source: string;
  message: string;
  stackTrace: string;
  userId: string;

  constructor() {
    this.id = 0;
    this.creationDate = null;
    this.request = '';
    this.source = '';
    this.message = '';
    this.stackTrace = '';
    this.userId = '';
  }
}

export class ResponseGetLoggsView {
 items: ResponseGetLoggsViewItem[];
 count: number;

 constructor() {
  this.items = new Array<ResponseGetLoggsViewItem>();
 }
}
