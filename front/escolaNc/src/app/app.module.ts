import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroComponent } from './areas/cadastro/cadastro.component';
import { ContratacaoComponent } from './areas/contratacao/contratacao.component';
import { LoginComponent } from './areas/login/login.component';
import { RelatoriosComponent } from './areas/relatorios/relatorios.component';
import { ServicoComponent } from './areas/servico/servico.component';
import { UsuarioComponent } from './areas/usuario/usuario.component';
import { NavbarComponent } from './shared/navbar/navbar.component';
import { HomeComponent } from './layout/home/home.component';
import { AuthenticationComponent } from './layout/authentication/authentication.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    UsuarioComponent,
    CadastroComponent,
    ServicoComponent,
    ContratacaoComponent,
    RelatoriosComponent,
    LoginComponent,
    HomeComponent,
    AuthenticationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
