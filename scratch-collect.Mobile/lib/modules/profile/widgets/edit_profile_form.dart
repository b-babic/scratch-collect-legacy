import 'package:flutter/material.dart';
import 'package:IB210370/modules/auth/constants.dart';
import 'package:IB210370/modules/home/home.screen.dart';
import 'package:IB210370/modules/profile/models/edit_profile_arguments.model.dart';
import 'package:IB210370/modules/profile/models/edit_profile_request.dart';
import 'package:IB210370/modules/profile/services/profile.service.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/utils/keyboard.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';
import 'package:IB210370/modules/shared/widgets/form_error.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';

class EditProfileForm extends StatefulWidget {
  final EditProfileArguments initialValues;

  const EditProfileForm({Key? key, required this.initialValues})
      : super(key: key);

  @override
  EditProfileFormState createState() => EditProfileFormState();
}

class EditProfileFormState extends State<EditProfileForm> {
  final _formKey = GlobalKey<FormState>();

  // Fields
  String? email;
  String? username;
  String? firstName;
  String? lastName;
  String? address;

  // Controllers
  late TextEditingController _emailController;
  late TextEditingController _usernameController;
  late TextEditingController _firstNameController;
  late TextEditingController _lastNameController;
  late TextEditingController _addressController;

  final List<String?> errors = [];

  bool isLoading = false;

  @override
  void initState() {
    super.initState();

    _emailController = TextEditingController(text: widget.initialValues.email);
    _usernameController =
        TextEditingController(text: widget.initialValues.username);
    _firstNameController =
        TextEditingController(text: widget.initialValues.firstName);
    _lastNameController =
        TextEditingController(text: widget.initialValues.lastName);
    _addressController =
        TextEditingController(text: widget.initialValues.address);
  }

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
                text: "Update Profile",
                press: () async {
                  if (_formKey.currentState!.validate()) {
                    _formKey.currentState!.save();

                    KeyboardUtil.hideKeyboard(context);

                    toggleLoading();

                    try {
                      var request = EditProfileRequest(
                        id: widget.initialValues.id,
                        email: email,
                        username: username,
                        firstName: firstName,
                        lastName: lastName,
                        address: address,
                      );

                      var updated =
                          await ProfileService().updateProfile(request);

                      if (!mounted) return;

                      if (updated.id != null) {
                        Snackbar.showSuccess(context, "Profile updated!");
                        Navigator.pushNamed(context, HomeScreen.routeName);
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

  // Builders
  TextFormField buildEmailFormField() {
    return TextFormField(
      controller: _emailController,
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
      controller: _usernameController,
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
      controller: _firstNameController,
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
      controller: _lastNameController,
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
      controller: _addressController,
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
