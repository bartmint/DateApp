import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

@Injectable({
  providedIn: 'root'
})
export class PreventUnsavedChangesGuard implements CanDeactivate<unknown> {
  canDeactivate(component: MemberEditComponent): boolean {
    if(component.editForm.dirty){
      return confirm('Are you sure you want to continute? Any unsaved changes will be lost');
    }
   return true;
  }
  
}
//guard sprawdza wartosc formularza na editprofile, 
//czy zostalo cos zmienione, jesli tak to po probie wyjscia bez zapisania informacji spowodouje pojawienie sie komunikatu