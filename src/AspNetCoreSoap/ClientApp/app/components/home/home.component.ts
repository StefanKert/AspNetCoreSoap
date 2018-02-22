import { Component, Inject, EventEmitter } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/finally';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent {
    keyUp = new EventEmitter<string>();


    public isLoading: boolean;
    public error: string;
    public whoIsInformation: string;
    public hostName: string;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }


    ngOnInit() {
        var source = this.keyUp
            .do(x => {
                this.whoIsInformation = "";
                this.error = "";
            })
            .debounceTime(500)
            .distinctUntilChanged()
            .do(x => this.isLoading = true)
            .switchMap(hostName => this.getWhoIsInformation(hostName).catch(err => {
                this.error = err.statusText;
                console.log(this.error);
                this.isLoading = false;
                return Observable.of<Error>(err)
            }))
            .do(() => this.isLoading = false);

        source.subscribe(whoisInfo => {
            if (!this.error) {
                this.whoIsInformation = whoisInfo;
            }
        });
    }

    private getWhoIsInformation(hostName: string): Observable<any> {
        return this.http.get(this.baseUrl + "api/whois/" + hostName)
            .map(response => response.text());
    }
}
