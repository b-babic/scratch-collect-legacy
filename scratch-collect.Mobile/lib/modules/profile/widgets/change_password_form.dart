import 'package:flutter/material.dart';
import 'package:IB210370/modules/auth/constants.dart';
import 'package:IB210370/modules/auth/login.screen.dart';
import 'package:IB210370/modules/profile/models/edit_password.request.dart';
import 'package:IB210370/modules/profile/models/edit_password_arguments.dart';
import 'package:IB210370/modules/profile/services/profile.service.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/utils/keyboard.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';
import 'package:IB210370/modules/shared/widgets/form_error.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';

class ChangePasswordForm extends StatefulWidget {
  final EditPasswordArguments arguments;

  const ChangePasswordForm({Key? key, required this.arguments})
      : super(key: key);

  @override
  ChangePasswordFormState createState() => ChangePasswordFormState();
}

class ChangePasswordFormState extends State<ChangePasswordForm> {
  final _formKey = GlobalKey<FormState>();

  // Fields
  String? oldPassword;
  String? newPassword;

  final oldPasswordController = TextEditingController();

  final List<String?> errors = [];

  bool isLoading = false;

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
            buildOldPasswordFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildNewPasswordFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            FormError(errors: errors),
            SizedBox(height: getProportionateScreenHeight(60)),
            Button(
                disabled: isLoading,
                loading: isLoading,
                text: "Change Password",
                press: () async {
                  if (_formKey.currentState!.validate()) {
                    _formKey.currentState!.save();

                    KeyboardUtil.hideKeyboard(context);

                    toggleLoading();

                    final request = EditPasswordRequest(
                        id: widget.arguments.id,
                        oldPassword: oldPassword,
                        newPassword: newPassword);

                    try {
                      var updated =
                          await ProfileService().updatePassword(request);

                      if (!mounted) return;

                      if (updated.id != null) {
                        Snackbar.showSuccess(context, "Password changed !");
                        Navigator.pushNamed(context, LoginScreen.routeName);
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
  TextFormField buildOldPasswordFormField() {
    return TextFormField(
      controller: oldPasswordController,
      obscureText: true,
      onSaved: (newValue) => oldPassword = newValue,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: oldPasswordRequiredError);
        } else if (value.length >= 4) {
          removeError(error: oldPasswordLengthError);
        }

        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: oldPasswordRequiredError);
          return "";
        } else if (value.length < 4) {
          addError(error: oldPasswordLengthError);
          return "";
        }
        return null;
      },
      decoration: const InputDecoration(
        labelText: "Old Password",
        hintText: 'Enter your old password',
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }

  TextFormField buildNewPasswordFormField() {
    return TextFormField(
      obscureText: true,
      onSaved: (newValue) => newPassword = newValue,
      onChanged: (value) {
        if (value.isNotEmpty) {
          removeError(error: newPasswordRequiredError);
        } else if (value.length >= 4) {
          removeError(error: newPasswordLengthError);
        } else if (value != oldPasswordController.text) {
          removeError(error: oldNewPasswordMatchError);
        }

        return;
      },
      validator: (value) {
        if (value!.isEmpty) {
          addError(error: newPasswordRequiredError);
          return "";
        } else if (value.length < 4) {
          addError(error: newPasswordLengthError);
          return "";
        } else if (value == oldPasswordController.text) {
          addError(error: oldNewPasswordMatchError);
          return "";
        }
        return null;
      },
      decoration: const InputDecoration(
        labelText: "New Password",
        hintText: 'Enter your new password',
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }
}
