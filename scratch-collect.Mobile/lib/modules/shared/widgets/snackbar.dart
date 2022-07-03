import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

class Snackbar {
  Snackbar._();

  static showError(BuildContext context, String message) {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Row(
          children: [
            SvgPicture.asset("lib/modules/shared/assets/icons/error.svg",
                height: getProportionateScreenWidth(14),
                width: getProportionateScreenWidth(14),
                color: Colors.red[200],
                semanticsLabel: 'A red error sign'),
            SizedBox(
              width: getProportionateScreenWidth(10),
            ),
            Text(message)
          ],
        ),
      ),
    );
  }

  static showSuccess(BuildContext context, String message) {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Row(
          children: [
            SvgPicture.asset("lib/modules/shared/assets/icons/check.svg",
                height: getProportionateScreenWidth(14),
                width: getProportionateScreenWidth(14),
                color: Colors.green[200],
                semanticsLabel: 'A green check sign'),
            SizedBox(
              width: getProportionateScreenWidth(10),
            ),
            Text(message)
          ],
        ),
      ),
    );
  }

  static showInfo(BuildContext context, String message) {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(
        content: Row(
          children: [
            SvgPicture.asset("lib/modules/shared/assets/icons/info.svg",
                height: getProportionateScreenWidth(14),
                width: getProportionateScreenWidth(14),
                color: Colors.blue[200],
                semanticsLabel: 'A blue info sign'),
            SizedBox(
              width: getProportionateScreenWidth(10),
            ),
            Text(message)
          ],
        ),
      ),
    );
  }
}
