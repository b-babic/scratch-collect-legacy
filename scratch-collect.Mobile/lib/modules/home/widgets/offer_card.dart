import 'package:flutter/material.dart';
import 'package:IB210370/modules/home/details.screen.dart';
import 'package:IB210370/modules/home/models/offer.model.dart';
import 'package:IB210370/modules/home/models/offer_details_arguments.model.dart';
import 'package:IB210370/modules/home/widgets/gradient_background.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';

enum OfferCardSize { regular, small }

class OfferCard extends StatelessWidget {
  const OfferCard({
    super.key,
    required this.offer,
    required this.keyPrefix,
    this.cardSize = OfferCardSize.regular,
  });

  final Offer offer;
  final String keyPrefix;
  final OfferCardSize? cardSize;

  double calculateCardSize(double screenWidth) {
    final isRegular = cardSize == OfferCardSize.regular;

    return isRegular ? screenWidth : screenWidth / 2;
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        SizedBox(
          width: calculateCardSize(SizeConfig.screenWidth),
          child: GestureDetector(
            onTap: () => Navigator.pushNamed(
              context,
              DetailsScreen.routeName,
              arguments: OfferDetailsArguments(
                offer.id,
                offer.averageRating,
              ),
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Card(
                  elevation: 3,
                  child: Padding(
                    padding: EdgeInsets.all(
                      getProportionateScreenWidth(20),
                    ),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        GradientBackground(
                          category: offer.category,
                          tag: keyPrefix.isNotEmpty
                              ? "$keyPrefix-${offer.id.toString()}"
                              : offer.id.toString(),
                        ),
                        SizedBox(
                          height: getProportionateScreenHeight(15),
                        ),
                        Text(
                          offer.title ?? "",
                          style: TextStyle(
                            color: textColor,
                            fontWeight: FontWeight.bold,
                            fontSize: getProportionateScreenWidth(16),
                          ),
                          maxLines: 2,
                        ),
                        SizedBox(
                          height: getProportionateScreenHeight(30),
                        ),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.spaceBetween,
                          children: [
                            Text(
                              "\$${offer.requiredPrice}",
                              style: TextStyle(
                                fontSize: getProportionateScreenWidth(18),
                                fontWeight: FontWeight.w600,
                                color: primaryColor,
                              ),
                            ),
                            Text(
                              "qty: ${offer.quantity}",
                              style: TextStyle(
                                fontSize: getProportionateScreenWidth(18),
                                color: secondaryColor,
                              ),
                            ),
                          ],
                        )
                      ],
                    ),
                  ),
                ),
                SizedBox(height: getProportionateScreenHeight(10)),
              ],
            ),
          ),
        ),
        SizedBox(
          height: getProportionateScreenHeight(30),
        )
      ],
    );
  }
}
