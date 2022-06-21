import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/auth/constants.dart';
import 'package:scratch_collect/modules/shared/theme/size_config.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';
import 'package:scratch_collect/modules/shared/utils/keyboard.dart';
import 'package:scratch_collect/modules/shared/widgets/button.dart';
import 'package:scratch_collect/modules/shared/widgets/form_error.dart';

class EditProfileForm extends StatefulWidget {
  const EditProfileForm({Key? key}) : super(key: key);

  @override
  EditProfileFormState createState() => EditProfileFormState();
}

class EditProfileFormState extends State<EditProfileForm> {
  final _formKey = GlobalKey<FormState>();

  // Fields
  String? email;
  String? username;
  String? password;
  String? passwordConfirm;
  String? firstName;
  String? lastName;
  String? address;

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

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return Form(
        key: _formKey,
        child: Column(
          children: [
            buildEmailFormField(),
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
                text: "Update Profile",
                press: () {
                  if (_formKey.currentState!.validate()) {
                    _formKey.currentState!.save();

                    KeyboardUtil.hideKeyboard(context);

                    // TODO: Create model class for signin / signup
                    final state = {
                      email,
                      username,
                      firstName,
                      lastName,
                      address
                    };

                    print("state: $state");

                    // TODO: Implement API service and redirect network call
                    // Navigator.pushNamed(context, HomeScreen.routeName);
                  }
                })
          ],
        ));
  }

  // Builders
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
