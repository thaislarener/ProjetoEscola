import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GuardGuard } from 'src/services/guard.guard';
import { CadastroComponent } from './areas/cadastro/cadastro.component';
import { ContratacaoComponent } from './areas/contratacao/contratacao.component';
import { LoginComponent } from './areas/login/login.component';
import { RelatoriosComponent } from './areas/relatorios/relatorios.component';
import { ServicoComponent } from './areas/servico/servico.component';
import { UsuarioComponent } from './areas/usuario/usuario.component';
import { AuthenticationComponent } from './layout/authentication/authentication.component';
import { HomeComponent } from './layout/home/home.component';

const routes: Routes = [
  {
    path: 'home', component: HomeComponent,canActivate: [GuardGuard],
    children:[
      {path:'usuario', component: UsuarioComponent},
      {path:'cadastro', component: CadastroComponent},
      {path:'servico', component: ServicoComponent},
      {path:'contratacao', component: ContratacaoComponent},
      {path:'relatorio', component: RelatoriosComponent}
    ],

  },
  {
    path:'', component: AuthenticationComponent,
    children:[
      {path: '', redirectTo: 'login', pathMatch: 'full'},
      {path:'login', component: LoginComponent}
    ]
  }
];
// const routes: Routes = [
//   {
//     path: 'home', component: HomeComponent, canActivate: [GuardGuard],
//     children:[
//       {path:'usuario', component: UsuarioComponent},
//       {path:'cadastro', component: CadastroComponent},
//       {path:'servico', component: ServicoComponent},
//       {path:'contratacao', component: ContratacaoComponent},
//       {path:'relatorio', component: RelatoriosComponent}
//     ],

//   },
//   {path:'login', component: LoginComponent}
// ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
