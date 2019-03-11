import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PaginationResult } from "../domain/paginationresult";
import { Rights } from "../domain/rights";


@Injectable()
export class RightsService{

constructor(private http: HttpClient) {

}

getRightswithPagination(page: number, itemsPerPage: number, filter: string){
    return this.http.get("https://localhost:44313/api/Rights/" + page + "/" + itemsPerPage + "?filter=" + filter)
    .toPromise()
    .then(data=>{return data as PaginationResult<Rights>})
}

getRights(){
    return this.http.get("https://localhost:44313/api/Rights")
    .toPromise()
    .then(data=>{return data as Rights[]})
}

}