import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {
  public  nome = '';
  public idade = 0;
  public cpf = '';
  public rg = '';
  public data_nasc = '';
  public endereco = '';
  public cidade = '';

  public usuarios: any[] = [];
  public edita: boolean = false;

  constructor(private api: ApiService) { }

  ngOnInit() {
    this.iniciarPagina();
  }

  public iniciarPagina(){
    this.edita = false;
    this.api.get(`usuarios`).subscribe(
      (dados: any) => {
        this.usuarios = dados;
        console.table(this.usuarios);
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

  public editar(item: any){
    this.edita = !this.edita;

    this.nome = item.nome;
    this.idade = item.idade;
    this.cpf = item.cpf;
    this.rg = item.rg;
    this.data_nasc = item.data_nasc;
    this.endereco = item.endereco;
    this.cidade = item.cidade;
  }


  public setCpf(item: any){
    this.cpf = item.cpf;
    this.nome = item.nome;
  }

  public salvar(){
    let item = {
      nome: this.nome,
      idade: this.idade,
      cpf: this.cpf,
      rg: this.rg,
      data_nasc: this.data_nasc,
      endereco: this.endereco,
      cidade: this.cidade,
    };

    this.api.post(`usuarios/atualizar`, item).subscribe(
      (dados: any) => {
        if(dados !== null || dados !== undefined ){
          alert(`Dados do usuário ${dados.nome} salvos com sucesso`);
          this.iniciarPagina();
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

  public excluir(){
    this.api.delete('usuarios', this.cpf!).subscribe(
      (dados: any) => {
        if(dados){
          alert('Usuário removido.');
          this.iniciarPagina();
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    );
  }

  public imprimir(obj: string){

  }
}
