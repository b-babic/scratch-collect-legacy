import 'package:flutter/material.dart';
import 'package:IB210370/modules/home/widgets/gradient_background.dart';
import 'package:IB210370/modules/items/models/play_screen_arguments.model.dart';
import 'package:IB210370/modules/items/models/user_offer.model.dart';
import 'package:IB210370/modules/items/play.screen.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';

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
              PlayScreen.routeName,
              arguments: PlayScreenArguments(
                userOffer.id,
                userOffer.offer?.id,
                userOffer.offer?.requiredPrice,
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
                          category: userOffer.offer?.category,
                          tag: keyPrefix.isNotEmpty
                              ? "$keyPrefix-${userOffer.id.toString()}"
                              : userOffer.id.toString(),
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
                          text: "Scratch & Collect",
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
