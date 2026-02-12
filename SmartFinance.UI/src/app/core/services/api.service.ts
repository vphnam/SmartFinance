import { HttpClient } from "@angular/common/http";
import { environment } from "../../../environments/environment"

export class ApiService {
  
    private baseUrl = environment.apiUrl;

    constructor(private http: HttpClient) {}

    get<T>(endpoint: string){
        return this.http.get<T>(`${this.baseUrl}/{endpoint}`);
    }

    post<T>(endpoint: string, postData: any){
        return this.http.post<T>(`${this.baseUrl}/${endpoint}`, postData);
    }

    put<T>(endpoint: string, putData: any){
        return this.http.put<T>(`${this.baseUrl}/${endpoint}`, putData);
    }

    delete<T>(endpoint: string){
        return this.http.delete<T>(`${this.baseUrl}/${endpoint}`);
    }
}