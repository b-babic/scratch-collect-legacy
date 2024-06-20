import 'package:flutter/material.dart';
import 'package:IB210370/modules/auth/constants.dart';
import 'package:IB210370/modules/auth/login.screen.dart';
import 'package:IB210370/modules/auth/models/signup_request.model.dart';
import 'package:IB210370/modules/auth/services/auth.service.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/utils/keyboard.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';
import 'package:IB210370/modules/shared/widgets/form_error.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';

class SignupForm extends StatefulWidget {
  const SignupForm({super.key});

  @override
  SignupFormState createState() => SignupFormState();
}

class SignupFormState extends State<SignupForm> {
  final _formKey = GlobalKey<FormState>();

  // Fields
  String? email;
  String? username;
  String? password;
  String? passwordConfirm;
  String? firstName;
  String? lastName;
  String? address;

  bool isLoading = false;

  // Controllers
  final passwordController = TextEditingController();

  final List<String?> errors = [];

  void addError({String? error}) {
    if (!errors.contains(error)) {
      setState(() {
        errors.add(error);
      });
    }
  }

  void removeError({String? error}) {
    if (errors.contains(error)) {
      setState(() {
        errors.remove(error);
      });
    }
  }

  void toggleLoading() {
    setState(() {
      isLoading = !isLoading;
    });
  }

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return Form(
        key: _formKey,
        child: Column(
          children: [
            buildEmailFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildUsernameFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildPasswordFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildPasswordConfirmFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildFirstNameFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildLastNameFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildAddressFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            FormError(errors: errors),
            SizedBox(height: getProportionateScreenHeight(60)),
            Button(
                disabled: isLoading,
                loading: isLoading,
                text: "Create Account",
                press: () async {
                  if (_formKey.currentState!.validate()) {
                    _formKey.currentState!.save();

                    KeyboardUtil.hideKeyboard(context);

                    toggleLoading();

                    final request = SignupRequest(
                        email: email,
                        password: password,
                        passwordConfirm: passwordConfirm,
                        username: username,
                        firstName: firstName,
                        lastName: lastName,
                        address: address);

                    try {
                      var loggedIn = await AuthService().signup(request);

                      if (!mounted) return;

                      if (loggedIn.id != null) {
                        Snackbar.showSuccess(context, "User created!");

                        Navigator.pushNamed(context, LoginScreen.routeName);
                      } else {
                        Snackbar.showError(context, "Something went wrong!");
                      }
                    } on Exception catch (e) {
                      Snackbar.showError(context, e.toString());
                    } finally {
                      toggleLoading();
                    }
                  }
                })
          ],
        ));
  }

  @override
  void dispose() {
    // Dispose all controllers
    passwordController.dispose();

    super.dispose();
  }

  // Input field builders
  TextFormField buildEmailFormField() {
    return TextFormField(
      keyboardType: TextInputType.emailAddress,
      onSaved: (newValue) => email = newValue,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: emailRequiredError);
        } else if (emailValidatorRegex.hasMatch(value)) {
          removeError(error: emailValidError);
        }
        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: emailRequiredError);
          return "";
        } else if (!emailValidatorRegex.hasMatch(value)) {
          addError(error: emailValidError);
          return "";
        }
        return null;
      },
      decoration: const InputDecoration(
        labelText: "Email",
        hintText: "Enter your email",
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildUsernameFormField() {
    return TextFormField(
      keyboardType: TextInputType.text,
      onSaved: (newValue) => username = newValue,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: usernameRequiredError);
        } else if (value.length < 20) {
          removeError(error: usernameLengthError);
        }
        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: usernameRequiredError);
          return "";
        } else if (value.length > 20) {
          addError(error: usernameLengthError);
          return "";
        }
        return null;
      },
      decoration: const InputDecoration(
        labelText: "Username",
        hintText: "Enter username",
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildPasswordFormField() {
    return TextFormField(
      controller: passwordController,
      obscureText: true,
      onSaved: (newValue) => password = newValue,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: passwordRequiredError);
        } else if (value.length >= 4) {
          removeError(error: passwordLengthError);
        }

        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: passwordRequiredError);
          return "";
        } else if (value.length < 4) {
          addError(error: passwordLengthError);
          return "";
        }
        return null;
      },
      decoration: const InputDecoration(
        labelText: "Password",
        hintText: 'Enter your password',
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildPasswordConfirmFormField() {
    return TextFormField(
      obscureText: true,
      onSaved: (newValue) => passwordConfirm = newValue,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: passwordConfirmRequiredError);
        } else if (value.length >= 4) {
          removeError(error: passwordConfirmLengthError);
        } else if (value == passwordController.text) {
          removeError(error: passwordConfirmMatchError);
        }

        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: passwordConfirmRequiredError);
          return "";
        } else if (value.length < 4) {
          addError(error: passwordConfirmLengthError);
          return "";
        } else if (value != passwordController.text) {
          addError(error: passwordConfirmMatchError);
          return "";
        }
        return null;
      },
      decoration: const InputDecoration(
        labelText: "Password Confirm",
        hintText: 'Enter Password Confirmation',
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildFirstNameFormField() {
    return TextFormField(
      keyboardType: TextInputType.text,
      onSaved: (newValue) => firstName = newValue,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: firstNameRequiredError);
        } else if (value.length < 20) {
          removeError(error: firstNameLengthError);
        }
        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: firstNameRequiredError);
          return "";
        } else if (value.length > 20) {
          addError(error: firstNameLengthError);
          return "";
        }
        return null;
      },
      decoration: const InputDecoration(
        labelText: "First Name",
        hintText: "Enter First Name",
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildLastNameFormField() {
    return TextFormField(
      keyboardType: TextInputType.text,
      onSaved: (newValue) => lastName = newValue,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: lastNameRequiredError);
        } else if (value.length < 20) {
          removeError(error: lastNameLengthError);
        }
        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: lastNameRequiredError);
          return "";
        } else if (value.length > 20) {
          addError(error: lastNameLengthError);
          return "";
        }
        return null;
      },
      decoration: const InputDecoration(
        labelText: "Last Name",
        hintText: "Enter Last Name",
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildAddressFormField() {
    return TextFormField(
      keyboardType: TextInputType.text,
      onSaved: (newValue) => address = newValue,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: addressRequiredError);
        } else if (value.length < 30) {
          removeError(error: addressLengthError);
        }
        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: addressRequiredError);
          return "";
        } else if (value.length > 30) {
          addError(error: addressLengthError);
          return "";
        }
        return null;
      },
      decoration: const InputDecoration(
        labelText: "Address",
        hintText: "Enter your address",
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }
}
