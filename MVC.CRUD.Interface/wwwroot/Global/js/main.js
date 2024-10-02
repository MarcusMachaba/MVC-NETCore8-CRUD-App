
 /* Delete function
 */
function Delete(id) {
   // var txt;
   // var r = confirm("Are you sure you want to Delete?");

   // if (r == true) {

        try {
            $.ajax({
                type: "POST",
                url: '@Url.Action("Delete", "ApplicationConfiguration")',
                data: {
                    id: id

                },
                success: function (res) {
                    window.location.reload(true);

                },
                error: function (err) {
                    console.log(err);
                }
            })
        } catch (e) {
            console.log(e);
        }
   // }
    return false;
}

/*==================================================================
    [Popup] */

showInPopup = (Url, title) => {
    $.ajax({
        type: 'GET',
        url: Url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#myModal').mymodal('show');
            // to make popup draggable
            $('.modal-dialog').draggable({
                handle: ".modal-header"
            });
        }
    })
}


(function ($) {
    "use strict";

    /*==================================================================
    [ Validate ]*/
    var input = $('.validate-input .input100');

    $('.validate-form').on('submit',function(){
        var check = true;

        for(var i=0; i<input.length; i++) {
            if(validate(input[i]) == false){
                showValidate(input[i]);
                check=false;
            }
        }

        return check;
    });


    $('.validate-form .input100').each(function(){
        $(this).focus(function(){
           hideValidate(this);
        });
    });

    function validate (input) {
        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if($(input).val().trim() == ''){
                return false;
            }
        }
    }

    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }

    function hideValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).removeClass('alert-validate');
    }
    
    

})(jQuery);