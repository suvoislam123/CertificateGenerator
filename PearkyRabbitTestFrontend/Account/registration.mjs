import { MessageService } from "../Services/MessageService.mjs";
import { ValidationService } from "../Services/ValidationServics.mjs";
import { AccountService } from "./AccountService.mjs";
const _accountService  = new AccountService();
const _validationService = new ValidationService();
const _messageService = new MessageService();

document.getElementById('termsInput').addEventListener('change',()=>{
    if(document.getElementById('termsInput').checked){
        document.getElementById('submit-button').disabled =false;
    }
    else{
        document.getElementById('submit-button').disabled =true;
    }
})
async function regitration() {
    document.getElementById('submit-button').innerText='Please Wait';
    var model = {
      userName:document.getElementById('username').value,
      password:document.getElementById('password').value,
      email:document.getElementById('email').value
    }
    await _accountService.Registration(model);
    document.getElementById('submit-button').innerText='Register';

}
document.getElementById('submit-button').addEventListener('click',()=>{
    _validationService.ValidateRequired('username', 'User Name');
    _validationService.ValidateMinimumLength('username','User Name',4);
    _validationService.ValidateEmail('email','Email');
    _validationService.ValidateRequired('email','Email');
    _validationService.ValidateMinimumLength('password','Password',6);
    _validationService.ValidateMaxLength('password','Password',100);
    _validationService.ValidateExactValue('password','confirmpassword','Password', 'Confirm Password');
    
    if(!_validationService.CheckBuildErrorExist(['username','password','email','confirmpassword'])){
        regitration();
    }
})