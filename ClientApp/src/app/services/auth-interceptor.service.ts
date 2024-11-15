import { HttpInterceptorFn } from "@angular/common/http";

export const authInterceptor : HttpInterceptorFn = (req,next) =>{
  // Write your logic 
  console.log("Inside interceptor")
  const token  = localStorage.getItem('access_token');
  const authReq = req.clone({headers : req.headers.set('Authorization',`Bearer ${token}`)})
  return next(authReq);
  };
