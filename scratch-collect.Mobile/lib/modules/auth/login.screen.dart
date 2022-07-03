import 'package:flutter/material.dart';
import 'package:IB210370/modules/auth/widgets/intro.dart';
import 'package:IB210370/modules/auth/widgets/signin_form.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/logo.dart';

import 'widgets/no_account_text.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({Key? key}) : super(key: key);

  static String routeName = "/auth/login";

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
              width: double.infinity,
              child: Padding(
                  padding: EdgeInsets.symmetric(
                      horizontal: getProportionateScreenWidth(20)),
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
                        const NoAccountText(),
                        SizedBox(height: SizeConfig.screenHeight * 0.04),
                      ],
                    ),
                  ))),
        ));
  }
}
