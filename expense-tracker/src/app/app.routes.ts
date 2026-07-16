import { Routes } from '@angular/router';
import { Signup } from '../page/signup/signup';
import { Login } from '../page/login/login';

export const routes: Routes = [

  { 
    path: '', 
    redirectTo: 'signup', 
    pathMatch: 'full' 
  }, 


  {
    path: 'login',
    component: Login,
  },


  {
    path: 'signup',
    component: Signup
  }
];