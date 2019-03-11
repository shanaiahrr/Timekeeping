import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PaginationResult } from "../domain/paginationresult";
import { Roles } from "../domain/roles";


@Injectable()
export class RoleService{

constructor(private http: HttpClient) {

}

getRoleswithPagination(page: number, itemsPerPage: number, filter: string){
    return this.http.get("https://localhost:44313/api/Roles/" + page + "/" + itemsPerPage + "?filter=" + filter)
    .toPromise()
    .then(data=>{return data as PaginationResult<Roles>})
}

getRole(){
    return this.http.get("https://localhost:44313/api/Roles")
    .toPromise()
    .then(data=>{return data as Roles[]})
}

getRoleID(id){
    return this.http.get("https://localhost:44313/api/Roles/" + id)
    .toPromise()
    .then(data=>{return data as Roles})
}
addRole(objEntity: Roles){
    return this.http.post("https://localhost:44313/api/Roles", objEntity)
    .toPromise()
    .then(data=>{return data as Roles})
}

editRole(id, objEntity: Roles){
    return this.http.put("https://localhost:44313/api/Roles/" + id, objEntity)
    .toPromise()
    .then(data=>{return data as Roles})
}

deleteRole(id){
    return this.http.delete("https://localhost:44313/api/Roles/" + id)
    .toPromise()
    .then(()=>null);
}

}