// ignore_for_file: use_build_context_synchronously

import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/auth/constants.dart';
import 'package:scratch_collect/modules/auth/models/signin_request.model.dart';
import 'package:scratch_collect/modules/auth/services/auth.service.dart';
import 'package:scratch_collect/modules/home/home.screen.dart';
import 'package:scratch_collect/modules/shared/theme/size_config.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';
import 'package:scratch_collect/modules/shared/utils/keyboard.dart';
import 'package:scratch_collect/modules/shared/utils/storage.dart';
import 'package:scratch_collect/modules/shared/widgets/button.dart';
import 'package:scratch_collect/modules/shared/widgets/form_error.dart';
import 'package:scratch_collect/modules/shared/widgets/snackbar.dart';

class SigninForm extends StatefulWidget {
  const SigninForm({Key? key}) : super(key: key);

  @override
  SigninFormState createState() => SigninFormState();
}

class SigninFormState extends State<SigninForm> {
  final _formKey = GlobalKey<FormState>();

  String? email;
  String? password;

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
            buildPasswordFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            FormError(errors: errors),
            SizedBox(height: getProportionateScreenHeight(60)),
            Button(
                text: "Continue",
                press: () async {
                  if (_formKey.currentState!.validate()) {
                    _formKey.currentState!.save();

                    KeyboardUtil.hideKeyboard(context);

                    var model = SigninRequest(email: email, password: password);

                    try {
                      var response = await AuthService().signin(model);

                      var token = response.token;

                      if (token != null) {
                        await Storage()
                            .write("user", json.encode(response.toJson()));

                        var persisted = await AuthService().getPersistedUser();
                        var savedToken = persisted.token;

                        if (savedToken != null) {
                          Snackbar.showSuccess(
                              context, "Successfully logged in!");

                          Navigator.pushNamed(context, HomeScreen.routeName);
                        } else {
                          Snackbar.showError(context, "Something went wrong!");
                        }
                      }
                    } on Exception catch (e) {
                      Snackbar.showError(context, e.toString());
                    }
                  }
                })
          ],
        ));
  }

  TextFormField buildPasswordFormField() {
    return TextFormField(
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
      },
      decoration: const InputDecoration(
        labelText: "Password",
        hintText: 'Enter your password',
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

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
}
