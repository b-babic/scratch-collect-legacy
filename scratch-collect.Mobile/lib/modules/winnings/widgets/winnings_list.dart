import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/home/widgets/offer_card.dart';
import 'package:scratch_collect/modules/items/models/user_offer.model.dart';
import 'package:scratch_collect/modules/winnings/widgets/winning_card.dart';

class WinningsList extends StatelessWidget {
  final List<UserOffer> winnings;

  const WinningsList({
    Key? key,
    required this.winnings,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        ...List.generate(
          winnings.length,
          (index) {
            return WinningCard(winning: winnings[index], keyPrefix: "winnings");
          },
        )
      ],
    );
  }
}
