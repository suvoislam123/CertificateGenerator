export class ValidationService{
    ValidateRequired(inputElementId, fieldName) {
        const value = document.getElementById(inputElementId).value;
        const errorDivHtml = `<span class="text-danger">${!fieldName ? 'This Field' : fieldName} is required</span>`;
    
        if (value === '') {
            let errorDiv = document.getElementById(inputElementId + 'RequiredError');
    
            if (errorDiv) {
                // Remove the existing error div
                errorDiv.remove();
            }
    
            // Create a new error div
            errorDiv = document.createElement('div');
            errorDiv.innerHTML = errorDivHtml;
            errorDiv.id = inputElementId + 'RequiredError';
    
            // Append the error div after the input element
            document.getElementById(inputElementId).insertAdjacentElement('afterend', errorDiv);
        } else {
            // Remove the error div if the value is not empty
            const errorDiv = document.getElementById(inputElementId + 'RequiredError');
            if (errorDiv) {
                errorDiv.remove();
            }
        }
    }

    ValidateEmail(inputElementId, fieldName) {
        const value = document.getElementById(inputElementId).value;
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        const isValidEmail = emailRegex.test(value);
    
        const errorDivHtml = `<span class="text-danger">${!fieldName ? 'This Field' : fieldName} should be a valid Email</span>`;
    
        let errorDiv = document.getElementById(inputElementId + 'EmailError');
    
        if (!isValidEmail) {
            if (errorDiv) {
                errorDiv.remove();
            }
            errorDiv = document.createElement('div');
            errorDiv.innerHTML = errorDivHtml;
            errorDiv.id = inputElementId + 'EmailError';
            document.getElementById(inputElementId).insertAdjacentElement('afterend', errorDiv);
        } else {
            if (errorDiv) {
                errorDiv.remove();
            }
        }
    }
    ValidateMinimumLength(inputElementId, fieldName, minLength) {
        const value = document.getElementById(inputElementId).value;
        const errorDivHtml = `<span class="text-danger">${!fieldName ? 'This Field' : fieldName} should have a minimum length of ${minLength} characters</span>`;
    
        if (value.length < minLength) {
            let errorDiv = document.getElementById(inputElementId + 'MinLengthError');
    
            if (errorDiv) {
                // Remove the existing error div
                errorDiv.remove();
            }
    
            // Create a new error div
            errorDiv = document.createElement('div');
            errorDiv.innerHTML = errorDivHtml;
            errorDiv.id = inputElementId + 'MinLengthError';
    
            // Append the error div after the input element
            document.getElementById(inputElementId).insertAdjacentElement('afterend', errorDiv);
        } else {
            // Remove the error div if the value meets the minimum length requirement
            const errorDiv = document.getElementById(inputElementId + 'MinLengthError');
            if (errorDiv) {
                errorDiv.remove();
            }
        }
    }
    ValidateExactLength(inputElementId, fieldName, exactLength) {
        const value = document.getElementById(inputElementId).value;
        const errorDivHtml = `<span class="text-danger">${!fieldName ? 'This Field' : fieldName} should have an exact length of ${exactLength} characters</span>`;
    
        if (value.length !== exactLength) {
            let errorDiv = document.getElementById(inputElementId + 'ExactLengthError');
    
            if (errorDiv) {
                // Remove the existing error div
                errorDiv.remove();
            }
    
            // Create a new error div
            errorDiv = document.createElement('div');
            errorDiv.innerHTML = errorDivHtml;
            errorDiv.id = inputElementId + 'ExactLengthError';
    
            // Append the error div after the input element
            document.getElementById(inputElementId).insertAdjacentElement('afterend', errorDiv);
        } else {
            // Remove the error div if the value has the exact length
            const errorDiv = document.getElementById(inputElementId + 'ExactLengthError');
            if (errorDiv) {
                errorDiv.remove();
            }
        }
    }
    ValidateMaxLength(inputElementId, fieldName, maxLength) {
        const value = document.getElementById(inputElementId).value;
        const errorDivHtml = `<span class="text-danger">${!fieldName ? 'This Field' : fieldName} should not exceed a maximum length of ${maxLength} characters</span>`;
    
        if (value.length > maxLength) {
            let errorDiv = document.getElementById(inputElementId + 'MaxLengthError');
    
            if (errorDiv) {
                // Remove the existing error div
                errorDiv.remove();
            }
    
            // Create a new error div
            errorDiv = document.createElement('div');
            errorDiv.innerHTML = errorDivHtml;
            errorDiv.id = inputElementId + 'MaxLengthError';
    
            // Append the error div after the input element
            document.getElementById(inputElementId).insertAdjacentElement('afterend', errorDiv);
        } else {
            // Remove the error div if the value does not exceed the maximum length
            const errorDiv = document.getElementById(inputElementId + 'MaxLengthError');
            if (errorDiv) {
                errorDiv.remove();
            }
        }
    }

    ValidateExactValue(inputElementId1, inputElementId2, fieldName1, fieldName2){
        const value1 = document.getElementById(inputElementId1).value;
        const value2 = document.getElementById(inputElementId2).value;
        const errorDivHtml = `<span class="text-danger">${fieldName1} should be equal to ${fieldName2}</span>`;
        if(value1 !==value2)
        {
            let errorDiv = document.getElementById(inputElementId2 + 'CompareError');
            if (errorDiv) {
                errorDiv.remove();
            }
            errorDiv = document.createElement('div');
            errorDiv.innerHTML = errorDivHtml;
            errorDiv.id = inputElementId2 + 'CompareError';
            document.getElementById(inputElementId2).insertAdjacentElement('afterend', errorDiv);
        }else{
            const errorDiv = document.getElementById(inputElementId2 + 'CompareError');
            if (errorDiv) {
                errorDiv.remove();
            }
        }
    }
    CheckBuildErrorExist(inputIds){
        let buildErros=['RequiredError','MaxLengthError','ExactLengthError','MinLengthError','EmailError','CompareError'];
        for(let i=0;i<inputIds.length;i++){
            for(let j=0;j<buildErros.length;j++)
            {
                if(document.getElementById(inputIds[i]+buildErros[j]))
                    return true;
            }
        }
        return false;
    }
    
    
}