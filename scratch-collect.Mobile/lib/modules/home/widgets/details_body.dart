import 'package:flutter/widgets.dart';
import 'package:scratch_collect/modules/home/models/offer.model.dart';
import 'package:scratch_collect/modules/home/models/offer_details_request.model.dart';
import 'package:scratch_collect/modules/home/models/offer_search_request.model.dart';
import 'package:scratch_collect/modules/home/services/offer.service.dart';
import 'package:scratch_collect/modules/home/widgets/buy_offer_button.dart';
import 'package:scratch_collect/modules/home/widgets/categories.dart';
import 'package:scratch_collect/modules/home/widgets/details_info.dart';
import 'package:scratch_collect/modules/home/widgets/gradient_background.dart';
import 'package:scratch_collect/modules/home/widgets/offer_details_body_loading.dart';
import 'package:scratch_collect/modules/home/widgets/offers_body_loading.dart';
import 'package:scratch_collect/modules/home/widgets/offers_intro.dart';
import 'package:scratch_collect/modules/home/widgets/offers_list.dart';
import 'package:scratch_collect/modules/home/widgets/recommended_items.dart';
import 'package:scratch_collect/modules/home/widgets/rounded_container.dart';
import 'package:scratch_collect/modules/home/widgets/search.dart';
import 'package:scratch_collect/modules/shared/theme/colors.dart';
import 'package:scratch_collect/modules/shared/theme/size_config.dart';
import 'package:scratch_collect/modules/shared/theme/styles.dart';
import 'package:scratch_collect/modules/shared/theme/utils.dart';
import 'package:scratch_collect/modules/shared/widgets/button.dart';
import 'package:scratch_collect/modules/shared/widgets/error_data.dart';
import 'package:scratch_collect/modules/shared/widgets/no_data.dart';
import 'package:scratch_collect/modules/shared/widgets/snackbar.dart';

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
                  vertical: getProportionateScreenHeight(20),
                  horizontal: getProportionateScreenWidth(20),
                ),
                child: ListView(
                  children: <Widget>[
                    GradientBackground(category: offer.category),
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
                          BuyOfferButton(id: offer.id),
                          SizedBox(height: getProportionateScreenHeight(30)),
                          RecommendedItems(),
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
