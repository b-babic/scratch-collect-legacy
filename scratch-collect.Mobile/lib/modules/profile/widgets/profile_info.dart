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

class ProfileInfo extends StatelessWidget {
  final String name;
  final String username;
  final String balance;

  const ProfileInfo(
      {Key? key,
      required this.name,
      required this.username,
      required this.balance})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: <Widget>[
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            Text(
              "NAME",
              style: infoLabelStyle,
            ),
            Text(
              name,
              style: infoTextStyle,
            )
          ],
        ),
        SizedBox(width: getProportionateScreenWidth(20)),
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            Text(
              "USERNAME",
              style: infoLabelStyle,
            ),
            Text(
              username,
              style: infoTextStyle,
            )
          ],
        ),
        SizedBox(width: getProportionateScreenWidth(20)),
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
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
