// Email
final RegExp emailValidatorRegex =
    RegExp(r"^[a-zA-Z0-9.]+@[a-zA-Z0-9]+\.[a-zA-Z]+");
const String emailRequiredError = "Please enter your email";
const String emailValidError = "Please enter valid email";

// Username
const String usernameRequiredError = "Please enter username";
const String usernameLengthError = "Username can have max 20 characters";

// Password
const String passwordRequiredError = "Please enter your password";
const String oldPasswordRequiredError = "Please enter your old password";
const String newPasswordRequiredError = "Please enter your new password";

const String passwordLengthError =
    "Password needs to have minimum 4 characters";
const String oldPasswordLengthError =
    "Old Password needs to have minimum 4 characters";
const String newPasswordLengthError =
    "New Password needs to have minimum 4 characters";

const String passwordConfirmRequiredError =
    "Please enter your password confirmation";
const String passwordConfirmLengthError =
    "Password Confirm needs to have minimum 4 characters";
const String passwordConfirmMatchError = "Your passwords needs to match";

const String oldNewPasswordMatchError =
    "Your new password cannot be the same as the old one";

// First Name
const String firstNameRequiredError = "Please enter first name";
const String firstNameLengthError = "First Name can have max 20 characters";

// Last Name
const String lastNameRequiredError = "Please enter last name";
const String lastNameLengthError = "Last Name can have max 20 characters";

// Address
const String addressRequiredError = "Please enter address";
const String addressLengthError = "Address can have max 30 characters";
