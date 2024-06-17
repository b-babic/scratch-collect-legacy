import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

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
    super.key,
    required this.balance,
  });

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
