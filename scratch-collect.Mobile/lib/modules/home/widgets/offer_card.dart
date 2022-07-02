import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/home/details.screen.dart';
import 'package:scratch_collect/modules/home/models/offer.model.dart';
import 'package:scratch_collect/modules/home/models/offer_details_arguments.model.dart';
import 'package:scratch_collect/modules/home/widgets/gradient_background.dart';
import 'package:scratch_collect/modules/items/models/user_offer.model.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/theme/size_config.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';
import 'package:scratch_collect/modules/shared/utils/colors.dart';

enum OfferCardSize { regular, small }

class OfferCard extends StatelessWidget {
  const OfferCard({
    Key? key,
    required this.offer,
    required this.keyPrefix,
    this.cardSize = OfferCardSize.regular,
  }) : super(key: key);

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
              arguments: OfferDetailsArguments(offer.id),
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
                const SizedBox(height: 10),
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
