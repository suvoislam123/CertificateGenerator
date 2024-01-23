import { apiUrl, clientUrl } from "../main.mjs";
import { MessageService } from "../Services/MessageService.mjs";

export class AccountService{
    apiUrl = apiUrl;
    IsLoggedIn(){
        return !!localStorage.getItem('Token');
    }
    Logout(){
      localStorage.removeItem('Token');
      window.location=clientUrl+'Account/login.html';
    }
    //Return  bolean type 
    Ifuseremailalreadyexists(model){
    const requestUrl = apiUrl+'Accounts/ifuseremailalreadyexists';
        
    fetch(requestUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(model)
    })
    .then(response => {
      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
      return response.json();
    })
    .then(data => {
      return data.value;

    })
    .catch(error => {
      
      console.error("Fetch error:", error);
    });
    }

    async Registration(model){
      const _messageService = new MessageService();
      try {
        //_messageService.HandleError({status:400, message:"Thiss is error"});
        const response = await fetch(apiUrl+'Accounts/registration', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(model),
        });
        console.log(response);
        const data = await response.json();
        console.log(data);
        if (response.ok) {
          if(data.statusCode==200)
          {
            _messageService.showSuccessMessage(data.message,"Registration");
            setTimeout(() => {
              window.location = clientUrl + 'Account/login.html';
          }, 5000);
          }
          else
          {
            _messageService.showInfoMessage(data.message,"Registration");
          }
        } else {
          console.log("From Here")
          _messageService.HandleError(data);
        }
      } catch (error) {
        console.log("From Error")
        _messageService.HandleError(error);
      }
    }

    async Login(model){
      const _messageService = new MessageService();
      try {
        //_messageService.HandleError({status:400, message:"Thiss is error"});
        const response = await fetch(apiUrl+'Accounts/login', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(model),
        });
        console.log(response);
        const data = await response.json();
        console.log(data);
        if (response.ok) {
          if(data.statusCode==200)
          {
            _messageService.showSuccessMessage(data.message,"Login");
            setTimeout(() => {
              //window.location = clientUrl + 'Account/login.html';
          }, 5000);
          }
          else
          {
            console.log(data)
            _messageService.showInfoMessage(data.message,"Login");
          }
        } else {
         
          _messageService.HandleError(data);
        }
      } catch (error) {
        console.log(error);
        _messageService.HandleError(error);
      }
    }

}