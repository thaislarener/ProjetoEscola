import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/services/api.service';
import { FormBuilder, FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-servico',
  templateUrl: './servico.component.html',
  styleUrls: ['./servico.component.css']
})
export class ServicoComponent implements OnInit {
  public form!: FormGroup;

  public servicos: any[] = [];
  public insere: boolean = false;

  constructor(private api: ApiService, private fb: FormBuilder) { }

  get f(): any{
    return this.form.controls;
  }

  ngOnInit() {
    this.iniciarPagina();
  }

  public iniciarPagina(){
    this.insere = false;
    this.api.get(`servicos`).subscribe(
      (dados: any) => {
        this.servicos = dados;
        console.table(this.servicos);
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }

  public inserir(){
    this.validaForm();
    this.insere = !this.insere;
  }

  public validaForm(){
    this.form = this.fb.group({
      id: [0, Validators.required],
      descricao: ['', Validators.required],
      preco: ['', [Validators.required, Validators.pattern('[0-9]+(.([0-9])+)*')]],
    });
  }

  public incluir(){
    this.api.post(`servicos/inserir`, this.form.value).subscribe(
      (dados: any) => {
        if(dados !== null || dados !== undefined ){
          alert(`Cadastro do serviços ${dados.descricao} salvo com sucesso`);
          this.iniciarPagina();
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }
  public excluir(id: string){
    this.api.delete('servicos', id).subscribe(
      (dados: any) => {
        if(dados){
          alert('Serviço removido.');
          this.iniciarPagina();
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    );
  }
  public editar(item: any){
    // this.insere = !this.insere;

    // this.descricao = item.descricao;
    // this.preco = item.idade;
  }

  public setCpf(item: any){
    descricao: item.descricao;
    preco: item.preco;
  }
}
