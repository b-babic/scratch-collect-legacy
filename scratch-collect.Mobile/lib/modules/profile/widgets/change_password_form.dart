import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/auth/constants.dart';
import 'package:scratch_collect/modules/shared/theme/size_config.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';
import 'package:scratch_collect/modules/shared/utils/keyboard.dart';
import 'package:scratch_collect/modules/shared/widgets/button.dart';
import 'package:scratch_collect/modules/shared/widgets/form_error.dart';

class ChangePasswordForm extends StatefulWidget {
  const ChangePasswordForm({Key? key}) : super(key: key);

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
            buildOldPasswordFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            buildNewPasswordFormField(),
            SizedBox(height: getProportionateScreenHeight(30)),
            FormError(errors: errors),
            SizedBox(height: getProportionateScreenHeight(60)),
            Button(
                text: "Change Password",
                press: () {
                  if (_formKey.currentState!.validate()) {
                    _formKey.currentState!.save();

                    KeyboardUtil.hideKeyboard(context);

                    // TODO: Create model class for signin / signup
                    final state = {
                      oldPassword,
                      newPassword,
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
      },
      decoration: const InputDecoration(
        labelText: "New Password",
        hintText: 'Enter your new password',
        floatingLabelBehavior: FloatingLabelBehavior.always,
      ),
    );
  }
}
