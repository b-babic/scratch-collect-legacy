import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/auth/widgets/signup_form.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/theme/size_config.dart';
import 'package:scratch_collect/modules/shared/theme/styles.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';

class SignupScreen extends StatefulWidget {
  const SignupScreen({Key? key}) : super(key: key);

  static String routeName = "/auth/signup";

  @override
  SignupScreenState createState() => SignupScreenState();
}

class SignupScreenState extends State<SignupScreen> {
  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return Scaffold(
        backgroundColor: whiteColor,
        body: SafeArea(
          child: SizedBox(
              width: double.infinity,
              child: Padding(
                  padding: EdgeInsets.symmetric(
                      horizontal: getProportionateScreenWidth(20)),
                  child: SingleChildScrollView(
                      child: Column(children: [
                    SizedBox(height: SizeConfig.screenHeight * 0.04), // 4%
                    Text("Register Account", style: headingStyle),
                    const Text(
                      "Please fill out all all the fields in order to continue",
                      textAlign: TextAlign.center,
                    ),
                    SizedBox(height: SizeConfig.screenHeight * 0.08),
                    const SignupForm(),
                    SizedBox(height: SizeConfig.screenHeight * 0.08),
                  ])))),
        ));
  }
}
