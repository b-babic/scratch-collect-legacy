import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';

// Shared styles
final infoLabelStyle = TextStyle(
  fontSize: getProportionateScreenWidth(16),
  fontWeight: FontWeight.bold,
  color: textColor,
  height: 1.5,
);

final infoTextStyle = TextStyle(
  fontSize: getProportionateScreenWidth(14),
  color: textColor,
  height: 1.5,
);

class ProfileBalance extends StatelessWidget {
  final String balance;

  const ProfileBalance({
    Key? key,
    required this.balance,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: <Widget>[
        Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: <Widget>[
            Text(
              "BALANCE",
              style: infoLabelStyle,
            ),
            Text(
              balance,
              style: infoTextStyle,
            )
          ],
        )
      ],
    );
  }
}
