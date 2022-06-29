import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';

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
            const Text(
              "NAME",
              style: TextStyle(
                fontWeight: FontWeight.bold,
                color: primaryColor,
                fontSize: 14,
              ),
            ),
            Text(
              name,
              style: const TextStyle(
                fontSize: 18,
              ),
            )
          ],
        ),
        SizedBox(width: getProportionateScreenWidth(20)),
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            const Text(
              "USERNAME",
              style: TextStyle(
                fontWeight: FontWeight.bold,
                color: primaryColor,
                fontSize: 14,
              ),
            ),
            Text(
              username,
              style: const TextStyle(
                fontSize: 18,
              ),
            )
          ],
        ),
        SizedBox(width: getProportionateScreenWidth(20)),
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            const Text("BALANCE",
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: primaryColor,
                  fontSize: 14,
                )),
            Text(
              balance,
              style: const TextStyle(
                fontSize: 18,
              ),
            )
          ],
        )
      ],
    );
  }
}
