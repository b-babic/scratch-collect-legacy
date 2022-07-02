import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/widgets/button.dart';

class BuyOfferButton extends StatelessWidget {
  final int? id;

  const BuyOfferButton({
    Key? key,
    required this.id,
  }) : super(key: key);

// TODO Get initial user object initially and handle disabled states if enough money ?
// Handle on press to buy item and redirect back or to bought items screen ?

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: const <Widget>[
        Button(
          text: "Buy this offer",
          disabled: true,
        ),
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
