import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ManageLeaves } from "../domain/manage-leaves";


@Injectable()
export class ManageLeavesService {
    constructor(private http: HttpClient) {} 

    getManageLeaves() {
        return this.http.get("https://localhost:44313/api/ManageLeaves")
            .toPromise()
            .then(data => { return data as ManageLeaves[] })
    }

    getManageLeavesInfo(id) {
        return this.http.get("https://localhost:44313/api/ManageLeaves/" + id)
            .toPromise()
            .then(data => { return data as ManageLeaves })
    }

    addManageLeaves(objEntity: ManageLeaves) {
        return this.http.post("https://localhost:44313/api/ManageLeaves/", objEntity)
            .toPromise()
            .then(data => { return data as ManageLeaves })
    }

    editManageLeaves(id, objEntity: ManageLeaves) {
        return this.http.put("https://localhost:44313/api/ManageLeaves/" + id, objEntity)
            .toPromise()
            .then(data => { return data as ManageLeaves })
    }

    deleteManageLeaves(id) {
        return this.http.delete("https://localhost:44313/api/ManageLeaves/" + id)
            .toPromise()
            .then(() => null);
    }
}