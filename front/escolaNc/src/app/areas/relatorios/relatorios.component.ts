import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-relatorios',
  templateUrl: './relatorios.component.html',
  styleUrls: ['./relatorios.component.css']
})
export class RelatoriosComponent implements OnInit {
  public form!: FormGroup;

  public inadimplente: boolean = false;
  public faturamento: boolean = false;
  public ver = 0;
  public cpf = '';

  public relatorios: any[] = [];
  public verifica: boolean = false;

  constructor(private api: ApiService, private fb: FormBuilder) { }
  get f(): any{
    return this.form.controls;
  }

  ngOnInit() {
    this.iniciarPagina();
  }

  public iniciarPagina(){
    this.api.get(`relatorios/faturamento`).subscribe(
      (dados: any) => {
        this.relatorios = dados;
        console.table(this.relatorios);
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }
  public verificar(){
    if (this.ver == 1){
      this.faturamento = true;
      this.inadimplente = false;
    }
    if(this.ver == 2){
      this.faturamento = false;
      this.inadimplente = true;
    }
  }
  public buscaCpf() {
    this.api.get(`relatorios/inadimplentes/${this.cpf}`).subscribe({
      next: dados => {
        this.relatorios = dados;
        this.verifica = true;
      },
      error: erro => alert(erro.error)
    })
  }
}

