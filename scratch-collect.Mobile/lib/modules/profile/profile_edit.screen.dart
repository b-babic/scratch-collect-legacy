import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/profile/models/edit_profile_arguments.model.dart';
import 'package:scratch_collect/modules/profile/widgets/edit_profile_form.dart';
import 'package:scratch_collect/modules/shared/theme/styles.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';

import '../shared/theme/size_config.dart';

class ProfileEditScreen extends StatelessWidget {
  const ProfileEditScreen({Key? key}) : super(key: key);

  static String routeName = "/profile/edit";

  @override
  Widget build(BuildContext context) {
    // Arguments
    final args =
        ModalRoute.of(context)!.settings.arguments as EditProfileArguments;

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
                  Text("Edit Profile", style: headingStyle),
                  const Text(
                    "Complete your details",
                    textAlign: TextAlign.center,
                  ),
                  SizedBox(height: SizeConfig.screenHeight * 0.06),
                  EditProfileForm(
                    initialValues: args,
                  ),
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
