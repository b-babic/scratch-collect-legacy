import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';

class WinningsIntro extends StatelessWidget {
  const WinningsIntro({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          "Welcome",
          style: TextStyle(
            color: textColor,
            fontSize: getProportionateScreenWidth(28),
            fontWeight: FontWeight.bold,
          ),
        ),
        Text(
          "Check out all the latest offers",
          style: TextStyle(
            fontSize: getProportionateScreenWidth(16),
          ),
        ),
      ],
    );
  }
}
