import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/home/models/offer.model.dart';
import 'package:IB210370/modules/home/widgets/offer_card.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

class RecommendedItems extends StatefulWidget {
  const RecommendedItems({
    super.key,
    required this.items,
  });

  final List<Offer> items;

  @override
  State<RecommendedItems> createState() => _RecommendedItemsState();
}

class _RecommendedItemsState extends State<RecommendedItems> {
  late var hasItems = widget.items.isNotEmpty;

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
        if (hasItems)
          SingleChildScrollView(
            scrollDirection: Axis.horizontal,
            child: Row(
              children: [
                ...List.generate(
                  widget.items.length,
                  (index) {
                    return OfferCard(
                      offer: widget.items[index],
                      keyPrefix: "recommended",
                      cardSize: OfferCardSize.small,
                    );
                  },
                ),
              ],
            ),
          )
        else
          Row(
            mainAxisAlignment: MainAxisAlignment.start,
            children: <Widget>[
              Text(
                "No recommendation criteria yet.",
                style: TextStyle(
                  fontSize: getProportionateScreenWidth(14),
                  color: secondaryColor,
                ),
              ),
            ],
          ),
      ],
    );
  }
}
