import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { TypeOfRights } from "../domain/typeofrights";

@Injectable()
export class TypeOfRightsService{

constructor(private http: HttpClient) {

}


getTypeOfRights(){
    return this.http.get("https://localhost:44313/api/TypeofRights")
    .toPromise()
    .then(data=>{return data as TypeOfRights[]})
}


}