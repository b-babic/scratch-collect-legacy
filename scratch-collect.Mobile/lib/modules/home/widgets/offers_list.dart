import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/home/models/offer.model.dart';
import 'package:scratch_collect/modules/home/widgets/offer_card.dart';

class OffersList extends StatelessWidget {
  final List<Offer> offers;

  const OffersList({
    Key? key,
    required this.offers,
  }) : super(key: key);

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
