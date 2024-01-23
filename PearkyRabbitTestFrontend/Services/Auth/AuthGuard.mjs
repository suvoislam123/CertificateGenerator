import { AccountService } from "../../Account/AccountService.mjs";
import { clientUrl } from "../../main.mjs";
export class AuthGuard{
    _accountService  = new AccountService();
    ShouldPersistThePage(){
        if(!this._accountService.IsLoggedIn()){
            window.location=clientUrl+'Account/login.html';
        }
    }
    Init(){
        document.getElementById('logout-button').addEventListener('click',()=>{
            this._accountService.Logout();
        });
        this.ShouldPersistThePage();
    }
}