import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/profile/models/edit_password_arguments.dart';
import 'package:scratch_collect/modules/profile/widgets/change_password_form.dart';
import 'package:scratch_collect/modules/shared/theme/styles.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';

import '../shared/theme/size_config.dart';

class ChangePasswordScreen extends StatelessWidget {
  const ChangePasswordScreen({Key? key}) : super(key: key);

  static String routeName = "/profile/password/edit";

  @override
  Widget build(BuildContext context) {
    final routeArguments =
        ModalRoute.of(context)!.settings.arguments as EditPasswordArguments;

    return Scaffold(
      appBar: AppBar(
        title: const Text("Profile"),
      ),
      body: SafeArea(
        child: SizedBox(
          width: double.infinity,
          child: Padding(
            padding: EdgeInsets.symmetric(
                horizontal: getProportionateScreenWidth(20)),
            child: SingleChildScrollView(
              child: Column(
                children: [
                  SizedBox(height: SizeConfig.screenHeight * 0.03),
                  Text("Change password", style: headingStyle),
                  const Text(
                    "Update current password",
                    textAlign: TextAlign.center,
                  ),
                  SizedBox(height: SizeConfig.screenHeight * 0.06),
                  ChangePasswordForm(arguments: routeArguments),
                  SizedBox(height: getProportionateScreenHeight(30)),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
