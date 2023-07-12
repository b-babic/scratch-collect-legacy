import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';

class OfferButtonInfo extends StatelessWidget {
  const OfferButtonInfo({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return const Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Text(
          "*You don't have enough money to buy this!",
          style: TextStyle(
            color: secondaryColor,
          ),
        ),
        Text(
          "*Please fill the wallet up.",
          style: TextStyle(
            color: secondaryColor,
          ),
        ),
      ],
    );
  }
}
