export class MessageService{
    constructor(){
        
    }
    initError(isSticky){
        document.getElementById('error-toast').addEventListener('click',()=>{
            document.getElementById('error-toast').classList.add('d-none');
        });
        if(!isSticky){
            setTimeout(()=>{
                document.getElementById('error-toast').classList.add('d-none');
            },4000)
        }
    }
    initSuccess(isSticky){
      document.getElementById('success-toast').addEventListener('click',()=>{
        document.getElementById('success-toast').classList.add('d-none');
    });
    if(!isSticky){
        setTimeout(()=>{
            document.getElementById('success-toast').classList.add('d-none');
        },4000)
    }
    }

    initInfo(isSticky){
      document.getElementById('info-toast').addEventListener('click',()=>{
        document.getElementById('info-toast').classList.add('d-none');
    });
    if(!isSticky){
        setTimeout(()=>{
            document.getElementById('info-toast').classList.add('d-none');
        },5000)
    }
    }
    showError(message, title, sticky){
        const errorDivHtml = `<div class="card position-fixed " style="width: 300px; top:100px; right:70px; background-color: darksalmon;min-height: 100px;box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px; ">
        <div class="px-2 py-1">
             <div class="d-flex justify-content-between">
                 <h5 class="fw-bold">${title}</h5>
                 <span class="fw-bold" id="error-toast-close" style="cursor: pointer;">Close</span>
             </div>
             <p>${message}</p>
        </div>
     </div>`;
     let toastDiv = document.getElementById('error-toast');
    
            if (toastDiv) {
                toastDiv.remove();
            }
    
            toastDiv = document.createElement('div');
            toastDiv.innerHTML = errorDivHtml;
            toastDiv.id = 'error-toast';
            document.getElementsByTagName('body')[0].insertAdjacentElement('afterend', toastDiv);
            this.initError(sticky);
    }
    showSuccessMessage(message,title,sticky){
      const successDivHtml = `<div class="card position-fixed " style="width: 300px; top:100px; right:70px; background-color:lightgreen;min-height: 100px;box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px; ">
        <div class="px-2 py-1">
             <div class="d-flex justify-content-between">
                 <h5 class="fw-bold">${title}</h5>
                 <span class="fw-bold" id="error-toast-close" style="cursor: pointer;">Close</span>
             </div>
             <p>${message}</p>
        </div>
     </div>`;
     let toastDiv = document.getElementById('success-toast');
    
            if (toastDiv) {
                toastDiv.remove();
            }
    
            toastDiv = document.createElement('div');
            toastDiv.innerHTML = successDivHtml;
            toastDiv.id = 'success-toast';
            document.getElementsByTagName('body')[0].insertAdjacentElement('afterend', toastDiv);
            this.initSuccess(sticky);
    }
    showInfoMessage(message,title,sticky){
      const successDivHtml = `<div class="card position-fixed " style="width: 300px; top:100px; right:70px; background-color:cyan;min-height: 100px;box-shadow: rgba(0, 0, 0, 0.25) 0px 54px 55px, rgba(0, 0, 0, 0.12) 0px -12px 30px, rgba(0, 0, 0, 0.12) 0px 4px 6px, rgba(0, 0, 0, 0.17) 0px 12px 13px, rgba(0, 0, 0, 0.09) 0px -3px 5px; ">
        <div class="px-2 py-1">
             <div class="d-flex justify-content-between">
                 <h5 class="fw-bold">${title}</h5>
                 <span class="fw-bold" id="error-toast-close" style="cursor: pointer;">Close</span>
             </div>
             <p>${message}</p>
        </div>
     </div>`;
     let toastDiv = document.getElementById('info-toast');
    
            if (toastDiv) {
                toastDiv.remove();
            }
    
            toastDiv = document.createElement('div');
            toastDiv.innerHTML = successDivHtml;
            toastDiv.id = 'info-toast';
            document.getElementsByTagName('body')[0].insertAdjacentElement('afterend', toastDiv);
            this.initInfo(sticky);
    }
    HandleError(error) {
        const status = error.status || 0; // Use 0 if status is undefined
      
        switch (status) {
          case 404:
            this.showError('Could Not Connect To Server', 'Connection Error', true);
            break;
      
          case 0:
            this.showError('Could Not Connect To Server', 'Connection Error', true);
            break;
      
          case 400:
            this.showError('Your provided data is not valid', 'Invalid Data');
            break;
      
          case 405:
            this.showError('Request Method Verb is incorrect', 'Http Error');
            break;
      
          case 415:
            this.showError('Unsupported Media', 'Http Error');
            break;
      
          case 500:
            if (error.error && error.error.message) {
              this.showError(error.error.message, 'Server Error', true);
            } else {
              this.showError('Something went wrong on the server', 'Server Error', true);
            }
            break;
      
          case 401:
            this.showInfo('Session Expired. Please Login again', 'Session Expired');
            // this.router.navigate(['/user/login']);
            break;
      
          case 403:
            this.showInfo('You Do Not have Permission', 'Forbidden');
            break;
      
          default:
            console.log(error);
            this.showError('Unknown Error Occurred');
            break;
        }
      }
      
}