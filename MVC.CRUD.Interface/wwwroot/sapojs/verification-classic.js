$(document).ready(function () {
    checkIE();
})

function checkIE() {

    var ua = window.navigator.userAgent;
    var msie = ua.indexOf("MSIE ");

    if (!(msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)))  // If Internet Explorer, return version number
    {
        showErrorModal('Unsupported Browser', 'The current device configuration (classic) will only work with internet explorer 11+.')
    }
}

//function CancelCapture() {
//    document.getElementById('verifyButton').style.display = 'none';
//    document.getElementById('validateButton').style.display = 'inline';
//    document.getElementById('cancelCaptureButton').style.display = 'none';
//    $('#IdNumber').removeAttr('readonly');
//}

function CancelVeify() {
    /* showSpinner();*/
   
    document.getElementById('IdNumber').value = '';
    document.getElementById('verificationBiometricsContainer').style.display = 'none';
    document.getElementById('identityNumberContainer').style.display = 'inline';

    document.getElementById('verifyButton').style.display = 'none';
    document.getElementById('validateButton').style.display = 'inline';
    document.getElementById('cancelCaptureButton').style.display = 'none';
    $('#viewButton').css('display', 'none');
    /*hideSpinner();*/
   
}

function ValidateId() {
    if (!$('#ConsentAccepted').is(':checked')) {
        showErrorModal('Consent Not Acceped', 'Please obtain consent before verifying an ID');
        return;
    }

    var idNumber = document.getElementById('IdNumber').value;
    var validationControl = document.getElementById('validationControl');
    $(validationControl).text('Validating ID Number...');
    $(validationControl).removeClass('text-danger');
    $(validationControl).removeClass('text-success');
    $('#validateButton').css('display', 'none');
    $('#verifyButton').css('display', 'none');
    $('#viewButton').css('display','none');
    $(validationControl).css('display', 'inline');
    $.post('/Account/validateIdNumber', { IdNumber: idNumber })
        .done(function (jsonData) {
            console.log(jsonData);
            if (jsonData && jsonData.isValid) {
               
                $(validationControl).addClass('text-white bg-success');
                $(validationControl).text(jsonData.message);
                $('#verifyButton').css('display', 'inline');
                $('#IdNumber').attr('readonly', 'readonly');
                $('#cancelCaptureButton').css('display', 'inline');
                if (jsonData.isIdVerified) {
                    $('#viewButton').css('display','inline');
                    var redirect = '/VerifiedUserDetails/ViewVerifiedUser?pid=' + jsonData.personId;
                    $('#viewButton').attr('href', redirect);
                }
                
            } else if (jsonData){
                $('#verifyButton').css('display', 'none');
                $('#validateButton').css('display', 'inline');
                $(validationControl).addClass('text-white bg-danger');
                $(validationControl).text(jsonData.errorMessage);
                $('#cancelCaptureButton').css('display','none');
            }
        })
        .fail(function (err) {
            $('#verifyButton').css('display', 'none');
            $('#validateButton').css('display', 'inline');
            $(validationControl).addClass('text-danger');
            $(validationControl).text('error with validation, contact technical support');
        });
}
function VerifyPerson() {
    var idNumber = document.getElementById('IdNumber').value;
    $('#viewButton').css('display', 'none');
   
    $('validationControl').css('display', 'none');
    doVerification(idNumber);
    
}

function doVerification(idNumber) {
    try {
        activeXRequestModel = {
            ClientIdNumber: idNumber
        };
        activeXcontrol = new ActiveXObject("BiometricsAXControl.BiometricActiveXCom");

        var jsonRequest = JSON.stringify(activeXRequestModel);
        var responseJson = activeXcontrol.VerifyPerson(jsonRequest);

        var response = JSON.parse(responseJson);

        if (response.ApplicationErrors && response.ApplicationErrors.length > 0) {
           
            showErrorModal('Error: Biometrics Control', response.ApplicationErrors[0]);
            return;
        } else if (response.VerificationErrors && response.VerificationErrors.length > 0) {
          
            showErrorModal('Error: Biometrics Control', response.VerificationErrors[0]);
            return;
        }

        setFormFields(response);
        $('#verifyForm').submit();
    } catch (err) {
        showErrorModal('Application Error', err.message);
       
    }
}

function setFormFields(response) {
   // document.getElementById('DeviceFirmwareVersion').value = response.DeviceFirmwareVersion;
   // document.getElementById('DeviceModel').value = response.DeviceModel;
   // document.getElementById('DeviceSerialNumber').value = response.DeviceSerialNumber;
    document.getElementById('FingerPrint1Index').value = response.Finger1Index;
    document.getElementById('FingerPrint2Index').value = response.Finger2Index;
   // document.getElementById('Finger1Name').value = response.Finger1Name;
   // document.getElementById('Finger2Name').value = response.Finger2Name;
   // document.getElementById('Finger1NameString').value = response.Finger1NameString;
    //document.getElementById('Finger2NameString').value = response.Finger2NameString;
    document.getElementById('LeftFingerPrint').value = response.Finger1WsqImage;
    document.getElementById('RightFingerPrint').value = response.Finger2WsqImage;
   // document.getElementById('WorkstationLoggedInUserName').value = response.WorkstationLoggedInUserName;
   // document.getElementById('WorkStationName').value = response.WorkStationName;
}