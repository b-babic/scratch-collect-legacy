import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';

class Intro extends StatelessWidget {
  const Intro({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(children: [
      Text(
        "Welcome Back",
        style: TextStyle(
          color: textColor,
          fontSize: getProportionateScreenWidth(28),
          fontWeight: FontWeight.bold,
        ),
      ),
      const Text(
        "Sign in with your email and password",
        textAlign: TextAlign.center,
      ),
    ]);
  }
}
