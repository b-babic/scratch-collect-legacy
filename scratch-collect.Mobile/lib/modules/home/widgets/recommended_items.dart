import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/home/models/offer.model.dart';
import 'package:scratch_collect/modules/home/widgets/offer_card.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';

class RecommendedItems extends StatelessWidget {
  RecommendedItems({Key? key}) : super(key: key);

  // TODO: Feature builder and get list of recommended items ?
  // Or return initial one inside the offer details response
  final List<Offer> dummyOffers = [
    Offer(id: 1, title: 'test', description: 'test'),
    Offer(id: 2, title: 'test 2', description: 'test3'),
    Offer(id: 3, title: 'test 3', description: 'test 3')
  ];

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: <Widget>[
        Text(
          "Recommended items:",
          style: TextStyle(
            fontSize: getProportionateScreenWidth(18),
            fontWeight: FontWeight.bold,
          ),
        ),
        SizedBox(height: getProportionateScreenHeight(20)),
        SingleChildScrollView(
          scrollDirection: Axis.horizontal,
          child: Row(
            children: [
              ...List.generate(
                3,
                (index) {
                  // TODO: Generate small cards
                  return OfferCard(
                    offer: dummyOffers[index],
                    keyPrefix: "recommended",
                    cardSize: OfferCardSize.small,
                  );
                },
              ),
            ],
          ),
        ),
      ],
    );
  }
}
