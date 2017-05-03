/**
 * Validates the given email
 * Source: http://stackoverflow.com/questions/46155/validate-email-address-in-javascript
 * @param {string} Email to verify
 * @returns {boolean} Whether or not the email is valid
 */
function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

/**
 * Removes form error classes
 */
function resetForm() {
    $(".form-group").each(function () {
        $(this).removeClass("has-error");
    });
}

$(function () {
    $("#registerForm").submit(function (event) {
        resetForm();
        var valid = true;

        var name = $("#nameField");
        var mail = $("#emailField");
        var pass1 = $("#passField");
        var pass2 = $("#passField2");

        // Validate name:
        if (name.val() == null || name.val() === "") {
            name.parent().addClass("has-error");
            valid = false;
        }

        // Validate email:
        if (!validateEmail(mail.val())) {
            mail.parent().addClass("has-error");
            valid = false;
        }

        // Validate passwords:
        if (pass1.val() === "" || pass2.val() === "" || pass1.val() != pass2.val()) {
            pass1.parent().addClass("has-error");
            pass2.parent().addClass("has-error");
            valid = false;
        }

        if (!valid) {
            event.preventDefault();
        }
    });
});