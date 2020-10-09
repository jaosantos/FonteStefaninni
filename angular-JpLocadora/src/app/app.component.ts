
import { Component } from '@angular/core';
import { FilmeService } from './services/filme.service';
import { GeneroService } from './services/genero.service';
import { Filme } from './models/filme';
import { Genero } from './models/genero';
import { NgForm } from '@angular/forms';
import { NgxMaskModule, IConfig } from 'ngx-mask'

export const options: Partial<IConfig> | (() => Partial<IConfig>) = null;


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-JpLocadora';

  filme = {} as Filme;
  filmes: Filme[];
  generos: Genero[];

  constructor(private filmeService: FilmeService,
              private generoService: GeneroService) {}

  ngOnInit() {
    this.getFilmes();
    this.getGeneros();
  }

  // defini se um filme será criado ou atualizado
  saveFilme(form: NgForm) {
    if (this.filme.Id !== undefined) {
      this.filmeService.updateFilme(this.filme).subscribe(() => {
        this.cleanForm(form);
      });
    } else {
      this.filmeService.saveFilme(this.filme).subscribe(() => {
        this.cleanForm(form);
      });
    }
  }

  // Chama o serviço para obtém todos os filmes
  getFilmes() {
    this.filmeService.getFilmes().subscribe((filmes: Filme[]) => {
      this.filmes = filmes;
    });
  }

  getGeneros() {
    this.generoService.getGeneros().subscribe((generos: Genero[]) => {
      this.generos = generos;
    });
  }

  // deleta um filme
  deleteFilme(filme: Filme) {
    this.filmeService.deleteFilme(filme).subscribe(() => {
      this.getFilmes();
    });
  }

  // copia o filme para ser editado.
  editFilme(filme: Filme) {
    this.filme = { ...filme };
  }

  // limpa o formulario
  cleanForm(form: NgForm) {
    this.getFilmes();
    form.resetForm();
    this.filme = {} as Filme;
  }

}
