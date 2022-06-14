import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, Validators } from '@angular/forms';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})

export class CadastroComponent implements OnInit {
  public form!: FormGroup;

  constructor(private api: ApiService, private fb: FormBuilder) { }

  get f(): any{
    return this.form.controls;
  }

  ngOnInit() {
    this.validaForm();
  }

  public validaForm(){
    this.form = this.fb.group({
      nome: ['', Validators.required],
      idade: ['', Validators.required],
      cpf: ['', Validators.required],
      rg: ['', Validators.required],
      data_nasc: ['', Validators.required],
      endereco: ['', Validators.required],
      cidade: ['', Validators.required]
    });
  }

  public incluir(){
    this.api.post(`usuarios/inserir`, this.form.value).subscribe(
      (dados: any) => {
        if(dados !== null || dados !== undefined ){
          alert(`Cadastro do usuário ${dados.nome} salvos com sucesso`);
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }
}
