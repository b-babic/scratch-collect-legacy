import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/items/models/user_offer.model.dart';
import 'package:IB210370/modules/items/widgets/user_offer_card.dart';

class UserOffersList extends StatelessWidget {
  final List<UserOffer> offers;
  final Future<void> Function() refreshData;

  const UserOffersList({
    Key? key,
    required this.offers,
    required this.refreshData,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        ...List.generate(
          offers.length,
          (index) {
            return UserOfferCard(
              userOffer: offers[index],
              keyPrefix: "user-offers",
              refreshData: refreshData,
            );
          },
        )
      ],
    );
  }
}
