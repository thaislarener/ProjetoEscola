import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';
import { LoginServiceService } from 'src/services/login-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public form!: FormGroup;
  public navegar: boolean = true;

  constructor(
    private api: ApiService,
    private fb: FormBuilder,
    private router: Router,
    private login: LoginServiceService
    ) { }

  get f(): any{
    this.navegar = true;
    return this.form.controls;
  }


  ngOnInit() {
    this.validaForm();
  }
  public validaForm(){
    this.form = this.fb.group({
      nome: [''],
      cpf: ['', Validators.required],
      hash_senha: ['', Validators.required]
    });
  }

  public validar(){
    this.api.post(`login/validar`, this.form.value).subscribe(
      (dados: any) => {
        if(dados){
          this.login.salvaUsuarioLogado(this.form.value);
          this.router.navigate(['/home']);
        }
        else
          alert("Senha incorreta!")
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
    console.log(this.form.value);
  }

  public navega(){
    this.navegar = !this.navegar;
  }

  public cadastro(){
    this.api.post(`login/cadastro`, this.form.value).subscribe(
      (dados: any) => {
        if(dados){
          alert("Usuário cadastrado com sucesso!");
          this.login.salvaUsuarioLogado(this.form.value);
          this.router.navigate(['/home']);
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }
}
