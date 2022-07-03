import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/home/models/offer.model.dart';
import 'package:IB210370/modules/home/widgets/offer_card.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

class RecommendedItems extends StatelessWidget {
  const RecommendedItems({
    Key? key,
    required this.items,
  }) : super(key: key);

  final List<Offer> items;

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
                items.length,
                (index) {
                  // TODO: Generate small cards
                  return OfferCard(
                    offer: items[index],
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
