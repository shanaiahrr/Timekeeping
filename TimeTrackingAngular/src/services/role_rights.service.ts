import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { PaginationResult } from "../domain/paginationresult";
import { RoleRights } from "../domain/rolerights";


@Injectable()
export class RoleRightsService{

constructor(private http: HttpClient) {

}

getRoleRightswithPagination(page: number, itemsPerPage: number, filter: string){
    return this.http.get("https://localhost:44313/api/RoleRights/" + page + "/" + itemsPerPage + "?filter=" + filter)
    .toPromise()
    .then(data=>{return data as PaginationResult<RoleRights>})
}
getRoleRightWithRoleId(roleId){
    return this.http.get("https://localhost:44313/api/RoleRights/" + roleId)
    .toPromise()
    .then(data=>{return data as RoleRights})
}

// getRoleRightInfo(id){
//     return this.http.get("https://localhost:44313/api/RoleRights/" + id)
//     .toPromise()
//     .then(data=>{return data as RoleRights})
// }

getRoleRights(){
    return this.http.get("https://localhost:44313/api/RoleRights")
    .toPromise()
    .then(data=>{return data as RoleRights[]})
}

addRoleRight(objEntity: RoleRights){
    return this.http.post("https://localhost:44313/api/RoleRights", objEntity)
    .toPromise()
    .then(data=>{return data as RoleRights})
}

editRoleRight(id, objEntity: RoleRights){
    return this.http.put("https://localhost:44313/api/RoleRights/" + id, objEntity)
    .toPromise()
    .then(data=>{return data as RoleRights})
}

deleteRoleRight(id){
    return this.http.delete("https://localhost:44313/api/RoleRights/" + id)
    .toPromise()
    .then(()=>null);
}

}