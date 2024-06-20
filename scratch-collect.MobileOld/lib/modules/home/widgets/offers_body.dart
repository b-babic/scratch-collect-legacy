import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/home/models/offer.model.dart';
import 'package:IB210370/modules/home/models/offer_search_request.model.dart';
import 'package:IB210370/modules/home/services/offer.service.dart';
import 'package:IB210370/modules/home/widgets/categories.dart';
import 'package:IB210370/modules/home/widgets/offers_body_loading.dart';
import 'package:IB210370/modules/home/widgets/offers_intro.dart';
import 'package:IB210370/modules/home/widgets/offers_list.dart';
import 'package:IB210370/modules/home/widgets/search.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/error_data.dart';
import 'package:IB210370/modules/shared/widgets/no_data.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';

class OffersBody extends StatefulWidget {
  const OffersBody({
    super.key,
  });

  @override
  OffersBodyState createState() => OffersBodyState();
}

class OffersBodyState extends State<OffersBody> {
  // Search
  String? query;
  int? categoryId;
  // Data
  late Future<dynamic> offersFuture;
  List<Offer> offers = [];

  @override
  void initState() {
    super.initState();

    offersFuture = loadRecentOffers();
  }

  // Data
  Future<void> loadRecentOffers() async {
    try {
      var searchRequest = OfferSearchRequest(
        query: query,
        categoryId: categoryId,
      );

      var offersData = await OfferService().getOffers(searchRequest);

      setState(() {
        offers = offersData;
      });
    } on Exception catch (_) {
      Snackbar.showError(context, "Error while fetching data!");
    }
  }

  // Search
  void handleSearch(String searcedQuery) async {
    setState(() {
      query = searcedQuery;
    });

    await loadRecentOffers();
  }

  void handleCategoryChange(int selectedCategory) async {
    setState(() {
      categoryId = selectedCategory;
    });

    await loadRecentOffers();
  }

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return FutureBuilder(
      future: offersFuture,
      builder: (context, snapshot) {
        if (snapshot.hasError) {
          return const ErrorData();
        } else if (snapshot.connectionState != ConnectionState.done) {
          return const OffersBodyLoading();
        } else {
          return SingleChildScrollView(
            padding: EdgeInsets.symmetric(
              vertical: getProportionateScreenHeight(20),
              horizontal: getProportionateScreenWidth(20),
            ),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: <Widget>[
                SizedBox(height: getProportionateScreenHeight(60)),
                const OffersIntro(),
                SizedBox(height: getProportionateScreenHeight(60)),
                Categories(
                  selectedCategory: categoryId ?? 0,
                  onCategoryChange: handleCategoryChange,
                ),
                Search(
                  onSearch: handleSearch,
                ),
                SizedBox(
                  height: getProportionateScreenHeight(45),
                ),
                offers.isNotEmpty ? OffersList(offers: offers) : const NoData()
              ],
            ),
          );
        }
      },
    );
  }
}
