import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Shifts } from '../domain/shifts';
import { PaginationResult } from "../domain/paginationresult";


@Injectable()
export class ShiftsService{

constructor(private http: HttpClient) {

}

getShiftswithPagination(page: number, itemsPerPage: number, filter: string){
    return this.http.get("https://localhost:44313/api/Shiftss/" + page + "/" + itemsPerPage + "?filter=" + filter)
    .toPromise()
    .then(data=>{return data as PaginationResult<Shifts>})
}
    
getShifts(){
    return this.http.get("https://localhost:44313/api/Shifts")
    .toPromise()
    .then(data=>{return data as Shifts[]})
}

addShifts(objEntity: Shifts){
    return this.http.post("https://localhost:44313/api/Shifts", objEntity)
    .toPromise()
    .then(data=>{return data as Shifts})
}

editShifts(id, objEntity: Shifts){
    return this.http.put("https://localhost:44313/api/Shifts/" + id, objEntity)
    .toPromise()
    .then(data=>{return data as Shifts})
}

deleteShifts(id){
    return this.http.delete("https://localhost:44313/api/Shifts/" + id)
    .toPromise()
    .then(()=>null);
}

}