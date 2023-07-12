import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/items/models/user_offer.model.dart';
import 'package:IB210370/modules/winnings/widgets/winning_card.dart';

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
