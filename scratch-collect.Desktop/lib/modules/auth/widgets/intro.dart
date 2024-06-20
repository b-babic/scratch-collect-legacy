import 'package:flutter/widgets.dart';
import 'package:ib210370_desktop/modules/shared/theme/colors.dart';
import 'package:ib210370_desktop/modules/shared/theme/utils.dart';

class Intro extends StatelessWidget {
  const Intro({super.key});

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
