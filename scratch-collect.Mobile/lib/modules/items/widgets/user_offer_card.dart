import 'package:IB210370/modules/home/widgets/rating_info.dart';
import 'package:IB210370/modules/items/models/rating_request.model.dart';
import 'package:IB210370/modules/items/services/rating.service.dart';
import 'package:IB210370/modules/items/widgets/rating_dialog.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';
import 'package:flutter/material.dart';
import 'package:IB210370/modules/home/widgets/gradient_background.dart';
import 'package:IB210370/modules/items/models/play_screen_arguments.model.dart';
import 'package:IB210370/modules/items/models/user_offer.model.dart';
import 'package:IB210370/modules/items/play.screen.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/button.dart';

class UserOfferCard extends StatefulWidget {
  const UserOfferCard({
    Key? key,
    required this.userOffer,
    required this.keyPrefix,
    required this.refreshData,
  }) : super(key: key);

  final UserOffer userOffer;
  final String keyPrefix;
  final Future<void> Function() refreshData;

  @override
  UserOfferCardState createState() => UserOfferCardState();
}

class UserOfferCardState extends State<UserOfferCard> {
  bool isLoading = false;

  void toggleLoading() {
    setState(() {
      isLoading = !isLoading;
    });
  }

  void onRatingSubmit(RatingDialogResponse response) async {
    var rating = response.rating;
    var userId = widget.userOffer.userId;
    var offerId = widget.userOffer.offer!.id;

    toggleLoading();

    try {
      var model = RatingRequest(
        userId: userId,
        offerId: offerId,
        rateCount: rating,
      );

      var response = await RatingService().rate(model);
      if (!mounted) return;

      if (response.id != null) {
        Snackbar.showSuccess(context, "Rating saved!");

        await widget.refreshData();
      } else {
        Snackbar.showError(context, "Something went wrong!");
      }
    } catch (e) {
      Snackbar.showError(context, e.toString());
    } finally {
      toggleLoading();
    }
  }

  @override
  void dispose() {
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final dialog = RatingDialog(
      title: Text(
        'Rate this item',
        textAlign: TextAlign.center,
        style: TextStyle(
          fontSize: getProportionateScreenWidth(25),
          fontWeight: FontWeight.bold,
        ),
      ),
      message: Text(
        'Tap a star to set your rating.',
        textAlign: TextAlign.center,
        style: TextStyle(fontSize: getProportionateScreenWidth(15)),
      ),
      initialRating: 0.0,
      showCloseButton: true,
      onCancelled: toggleLoading,
      submitButtonText: isLoading ? 'Please wait...' : 'Submit',
      onSubmitted: onRatingSubmit,
    );

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
                        category: widget.userOffer.offer?.category,
                        tag: widget.keyPrefix.isNotEmpty
                            ? "$widget.keyPrefix-${widget.userOffer.id.toString()}"
                            : widget.userOffer.id.toString(),
                      ),
                      SizedBox(
                        height: getProportionateScreenHeight(15),
                      ),
                      Text(
                        widget.userOffer.offer?.title ?? "",
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
                      if (widget.userOffer.alreadyRated ?? false) ...[
                        RatingInfo(
                            rating: widget.userOffer.averageRating ?? 0.0),
                      ],
                      Button(
                        text: "Scratch & Collect",
                        press: () => Navigator.pushNamed(
                          context,
                          PlayScreen.routeName,
                          arguments: PlayScreenArguments(
                            widget.userOffer.id,
                            widget.userOffer.offer?.id,
                            widget.userOffer.offer?.requiredPrice,
                          ),
                        ),
                      ),
                      if (!(widget.userOffer.alreadyRated ?? false)) ...[
                        SizedBox(
                          height: getProportionateScreenHeight(15),
                        ),
                        TextButton(
                          onPressed: () => showDialog(
                            context: context,
                            barrierDismissible: true,
                            builder: (context) => dialog,
                          ),
                          child: Text(
                            "Rate now",
                            style: TextStyle(
                              color: isLoading ? tertiaryColor : primaryColor,
                            ),
                          ),
                        ),
                      ],
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
