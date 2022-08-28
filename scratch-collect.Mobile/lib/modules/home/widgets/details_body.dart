import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/home/models/offer.model.dart';
import 'package:IB210370/modules/home/models/offer_details_request.model.dart';
import 'package:IB210370/modules/home/services/offer.service.dart';
import 'package:IB210370/modules/home/widgets/buy_offer_button.dart';
import 'package:IB210370/modules/home/widgets/details_info.dart';
import 'package:IB210370/modules/home/widgets/gradient_background.dart';
import 'package:IB210370/modules/home/widgets/offer_details_body_loading.dart';
import 'package:IB210370/modules/home/widgets/recommended_items.dart';
import 'package:IB210370/modules/home/widgets/rounded_container.dart';
import 'package:IB210370/modules/shared/theme/colors.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/error_data.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';

class DetailsBody extends StatefulWidget {
  final int? id;

  const DetailsBody({
    Key? key,
    required this.id,
  }) : super(key: key);

  @override
  DetailsBodyState createState() => DetailsBodyState();
}

class DetailsBodyState extends State<DetailsBody> {
  // Data
  late Future<dynamic> offerFuture;
  late Offer offer;

  @override
  void initState() {
    super.initState();

    offerFuture = loadOfferDetails();
  }

  // Data
  Future<void> loadOfferDetails() async {
    try {
      var request = OfferDetailsRequest(
        id: widget.id,
      );

      var offersData = await OfferService().getOfferDetails(request);

      setState(() {
        offer = offersData;
      });
    } on Exception catch (_) {
      Snackbar.showError(context, "Error while fetching offer details!");
    }
  }

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return FutureBuilder(
      future: offerFuture,
      builder: (context, snapshot) {
        if (snapshot.hasError) {
          return const ErrorData();
        } else if (snapshot.connectionState != ConnectionState.done) {
          return const OfferDetailsBodyLoading();
        } else {
          return SafeArea(
            child: SizedBox(
              width: double.infinity,
              child: Padding(
                padding: EdgeInsets.symmetric(
                  vertical: getProportionateScreenHeight(10),
                  horizontal: getProportionateScreenWidth(20),
                ),
                child: ListView(
                  children: <Widget>[
                    GradientBackground(
                      category: offer.category,
                      tag: "recommended-${offer.id.toString()}",
                    ),
                    RoundedContainer(
                      color: whiteColor,
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.start,
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: <Widget>[
                          DetailsInfo(
                            title: offer.title,
                            description: offer.description,
                          ),
                          SizedBox(height: getProportionateScreenHeight(30)),
                          BuyOfferButton(
                            offerId: offer.id,
                            requiredPrice: offer.requiredPrice,
                          ),
                          SizedBox(height: getProportionateScreenHeight(30)),
                          RecommendedItems(items: offer.recommendedItems ?? []),
                        ],
                      ),
                    )
                  ],
                ),
              ),
            ),
          );
        }
      },
    );
  }
}
