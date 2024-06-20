import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/home/models/offer.model.dart';
import 'package:IB210370/modules/home/widgets/offer_card.dart';

class OffersList extends StatelessWidget {
  final List<Offer> offers;

  const OffersList({
    super.key,
    required this.offers,
  });

  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        ...List.generate(
          offers.length,
          (index) {
            return OfferCard(offer: offers[index], keyPrefix: "main-offers");
          },
        )
      ],
    );
  }
}
