import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FormLogin } from '../../models/form-login.model';
import { Login } from '../../models/login.model';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public formLogin!: FormGroup<FormLogin>;
  public authLogin!: Login;

  public constructor(private authenticationService: AuthService,
    private router: Router,
    private formBuilder: FormBuilder,
    private snackBar: MatSnackBar) {

  }

  public ngOnInit(): void {
    this.criarFormulario();
  }

  public login(): void {
    // assign faz um mapper do objeto
    this.authLogin = Object.assign('', this.authLogin, this.formLogin.value);

    this.authLogin.login = this.authLogin.login.toLowerCase();

    this.authenticationService.login({...this.authLogin})
      .subscribe({
        next: (response) => {
          if (response) {
            this.router.navigateByUrl('dashboard');
          }
        }, 
        error: (error) => {
          console.log(error);
          this.snackBar.open('Ocorreu um erro no login!');
        }
      });
  }

  public logout() {
    this.authenticationService.logOut();
    this.router.navigate(['auth', 'login']);
  }

  private criarFormulario(): void {
    // Serve para validar em conjunto ao mesmo tempo o compose
    //Validators.compose([Validators.required, Validators.email]);
    this.formLogin = this.formBuilder.group<FormLogin>({
      login: new FormControl<string>('', {nonNullable: true, validators: [ Validators.required ]}),
      password: new FormControl<string>('', {nonNullable: true, validators: Validators.compose([ Validators.required, Validators.minLength(4) ]) })
    })
  }

  // Guarda de rotas
  // Can Activate // verifica se pode ativar a rota
  // CanDeActivate // verifica se pode desativar a rota 
}