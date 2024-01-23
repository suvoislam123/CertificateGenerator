import { MessageService } from "../Services/MessageService.mjs";
import { AccountService } from "./AccountService.mjs";
import { ValidationService } from "../Services/ValidationServics.mjs";

const _accountService  = new AccountService();
const _validationService = new ValidationService();
const _messageService = new MessageService();


async function login(){
    document.getElementById('submit-button').innerText='Please Wait';
    const model = {
        userNameOrEmail:document.getElementById('username').value,
        password:document.getElementById('password').value
    }
    console.log(model);
    await _accountService.Login(model);
    document.getElementById('submit-button').innerText='Login';
}
document.getElementById('submit-button').addEventListener('click',()=>{
    _validationService.ValidateRequired('username', 'User Name or Email');
    _validationService.ValidateMinimumLength('username','User Name or Email',4);
    _validationService.ValidateMinimumLength('password','Password',6);
    _validationService.ValidateRequired('password','Password');
    _validationService.ValidateMaxLength('password','Password',100);
    if(!_validationService.CheckBuildErrorExist(['username','password'])){
        login();
    }
})