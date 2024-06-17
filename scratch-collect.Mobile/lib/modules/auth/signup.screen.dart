import 'package:flutter/material.dart';
import 'package:IB210370/modules/auth/widgets/signup_form.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/styles.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

class SignupScreen extends StatefulWidget {
  const SignupScreen({super.key});

  static String routeName = "/auth/signup";

  @override
  SignupScreenState createState() => SignupScreenState();
}

class SignupScreenState extends State<SignupScreen> {
  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return Scaffold(
        appBar: AppBar(title: const Text("Registration")),
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
