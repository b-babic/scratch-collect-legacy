import 'package:flutter/material.dart';
import 'package:ib210370_desktop/modules/auth/widgets/intro.dart';
import 'package:ib210370_desktop/modules/auth/widgets/signin_form.dart';
import 'package:ib210370_desktop/modules/shared/theme/colors.dart';
import 'package:ib210370_desktop/modules/shared/theme/size_config.dart';
import 'package:ib210370_desktop/modules/shared/theme/utils.dart';
import 'package:ib210370_desktop/modules/shared/widgets/logo.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({super.key});

  static String routeName = "/auth/signin";

  @override
  LoginScreenState createState() => LoginScreenState();
}

class LoginScreenState extends State<LoginScreen> {
  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return Scaffold(
      backgroundColor: whiteColor,
      body: SafeArea(
        child: SizedBox(
          width: getProportionateScreenWidth(768),
          child: Padding(
            padding: EdgeInsets.symmetric(
              horizontal: getProportionateScreenWidth(80),
            ),
            child: SingleChildScrollView(
              child: Column(
                children: [
                  SizedBox(height: SizeConfig.screenHeight * 0.04),
                  const LogoWidget(),
                  SizedBox(height: SizeConfig.screenHeight * 0.04),
                  const Intro(),
                  SizedBox(height: SizeConfig.screenHeight * 0.08),
                  const SigninForm(),
                  SizedBox(height: SizeConfig.screenHeight * 0.08),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
