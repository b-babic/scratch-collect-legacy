import 'package:flutter/material.dart';
import 'package:scratch_collect/modules/home/details.screen.dart';
import 'package:scratch_collect/modules/items/models/user_offer.model.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/theme/size_config.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';
import 'package:scratch_collect/modules/shared/utils/colors.dart';
import 'package:scratch_collect/modules/shared/widgets/button.dart';

class UserOfferCard extends StatelessWidget {
  const UserOfferCard({
    Key? key,
    required this.userOffer,
    required this.keyPrefix,
  }) : super(key: key);

  final UserOffer userOffer;
  final String keyPrefix;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: <Widget>[
        SizedBox(
          width: SizeConfig.screenWidth,
          child: GestureDetector(
            onTap: () => Navigator.pushNamed(
              context,
              // TODO: Add play offer screen
              DetailsScreen.routeName,
              // arguments: OfferDetailsArguments(offer.id),
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
                        // TODO: Replace with GradientBackground widget
                        AspectRatio(
                          aspectRatio: 2,
                          child: Hero(
                            tag: keyPrefix.isNotEmpty
                                ? "$keyPrefix-${userOffer.id.toString()}"
                                : userOffer.id.toString(),
                            child: Container(
                              decoration: BoxDecoration(
                                gradient: LinearGradient(
                                  begin: Alignment.topRight,
                                  end: Alignment.bottomLeft,
                                  // Add one stop for each color. Stops should increase from 0 to 1
                                  stops: const [0.1, 0.9],
                                  colors: [
                                    colorFromHex(userOffer
                                            .offer?.category?.gradientStart ??
                                        ""),
                                    colorFromHex(userOffer
                                            .offer?.category?.gradientStop ??
                                        ""),
                                  ],
                                ),
                              ),
                            ),
                          ),
                        ),
                        SizedBox(
                          height: getProportionateScreenHeight(15),
                        ),
                        Text(
                          userOffer.offer?.title ?? "",
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
                        const Button(
                          text: "Try your luck",
                        ),
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
