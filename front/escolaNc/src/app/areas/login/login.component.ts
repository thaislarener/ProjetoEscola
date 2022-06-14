import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ApiService } from 'src/services/api.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public form!: FormGroup;

  constructor( private api: ApiService, private fb: FormBuilder, private router: Router) { }

  get f(): any{
    return this.form.controls;
  }


  ngOnInit() {
  }
  public validaForm(){
    this.form = this.fb.group({
      nome: '',
      cpf: ['', Validators.required],
      hash_senha: ['', Validators.required]
    });
  }

  public validar(){
    this.api.post(`login/validar`, this.form.value).subscribe(
      (dados: any) => {
        if(dados !== null || dados !== undefined ){
          this.router.navigate(['/usuario']);
        }
      },
      (erro: any) => {
        alert(erro.error);
      }
    )
  }
}
