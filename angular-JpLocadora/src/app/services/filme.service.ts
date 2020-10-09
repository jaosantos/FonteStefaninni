import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Filme } from '../models/filme';

@Injectable({
  providedIn: 'root'
})
export class FilmeService {

  url = 'https://localhost:44346/api/Filme';
  constructor(private httpClient: HttpClient) { }

  // Headers
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  // Obtem todos os filmes
  getFilmes(): Observable<Filme[]> {
    return this.httpClient.get<Filme[]>(this.url)
      .pipe(
        retry(2),
        catchError(this.handleError))
  }

  // Obtem um filme pelo id
  getFilmeById(id: number): Observable<Filme> {
    return this.httpClient.get<Filme>(this.url + '/' + id)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // salva um filme
  saveFilme(filme: Filme): Observable<Filme> {
    return this.httpClient.post<Filme>(this.url, JSON.stringify(filme), this.httpOptions)
      .pipe(
        retry(2),
        catchError(this.handleError)
      )
  }

  // utualiza um filme
  updateFilme(filme: Filme): Observable<Filme> {
    return this.httpClient.put<Filme>(this.url, JSON.stringify(filme), this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }


  // deleta um filme
  deleteFilme(filme: Filme) {
    return this.httpClient.delete<Filme>(this.url + '/' + filme.Id, this.httpOptions)
      .pipe(
        retry(1),
        catchError(this.handleError)
      )
  }

  // Manipulação de erros
  handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do client
      errorMessage = error.error.message;
    } else {
      // Erro ocorreu no lado do servidor
      errorMessage = `Código do erro: ${error.status}, ` + `menssagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  };

}
