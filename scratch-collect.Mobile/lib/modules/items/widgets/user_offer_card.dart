import 'package:IB210370/modules/home/widgets/rating_info.dart';
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
                    mainAxisAlignment: MainAxisAlignment.start,
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
                      if (userOffer.alreadyRated ?? false) ...[
                        RatingInfo(rating: userOffer.averageRating ?? 0.0),
                      ],
                      Button(
                        text: "Scratch & Collect",
                        press: () => Navigator.pushNamed(
                          context,
                          PlayScreen.routeName,
                          arguments: PlayScreenArguments(
                            userOffer.id,
                            userOffer.offer?.id,
                            userOffer.offer?.requiredPrice,
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
              SizedBox(height: getProportionateScreenHeight(10)),
            ],
          ),
        ),
        SizedBox(
          height: getProportionateScreenHeight(30),
        )
      ],
    );
  }
}
