import { Routes } from '@angular/router';
import { Signup } from '../page/signup/signup';
import { Login } from '../page/login/login';
import { Home } from '../page/home/home';

export const routes: Routes = [

  { 
    path: '', 
    redirectTo: 'home', 
    pathMatch: 'full' 
  }, 


  {
    path: 'login',
    component: Login,
  },


  {
    path: 'signup',
    component: Signup
  },

  {
    path: 'home',
    component: Home
  }
];