import 'package:IB210370/modules/profile/profile.screen.dart';
import 'package:flutter/material.dart';
import 'package:IB210370/modules/profile/models/edit_profile_arguments.model.dart';
import 'package:IB210370/modules/profile/widgets/edit_profile_form.dart';
import 'package:IB210370/modules/shared/theme/styles.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

import '../shared/theme/size_config.dart';

class ProfileEditScreen extends StatelessWidget {
  const ProfileEditScreen({super.key});

  static String routeName = "/profile/edit";

  @override
  Widget build(BuildContext context) {
    // Arguments
    final args =
        ModalRoute.of(context)!.settings.arguments as EditProfileArguments;

    return Scaffold(
      appBar: AppBar(
        leading: BackButton(
          onPressed: () {
            Navigator.pushReplacement(
              context,
              MaterialPageRoute(
                builder: (context) => const ProfileScreen(),
              ),
            );
          },
        ),
        title: const Text(
          "Profile",
        ),
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
