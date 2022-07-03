import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/auth/services/auth.service.dart';
import 'package:IB210370/modules/home/models/offer_search_request.model.dart';
import 'package:IB210370/modules/home/services/offer.service.dart';
import 'package:IB210370/modules/home/widgets/categories.dart';
import 'package:IB210370/modules/home/widgets/offers_body_loading.dart';
import 'package:IB210370/modules/home/widgets/search.dart';
import 'package:IB210370/modules/items/models/user_offer.model.dart';
import 'package:IB210370/modules/items/widgets/user_offers_intro.dart';
import 'package:IB210370/modules/items/widgets/user_offers_list.dart';
import 'package:IB210370/modules/profile/models/profile.model.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/error_data.dart';
import 'package:IB210370/modules/shared/widgets/no_data.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';

class UserOffersBody extends StatefulWidget {
  const UserOffersBody({
    Key? key,
  }) : super(key: key);

  @override
  UserOffersBodyState createState() => UserOffersBodyState();
}

class UserOffersBodyState extends State<UserOffersBody> {
  // Search
  String? query;
  int? categoryId;
  // Data
  late Future<dynamic> userOffersFuture;
  List<UserOffer> userOffers = [];
  late ProfileResponse user;

  @override
  void initState() {
    super.initState();

    userOffersFuture = loadUserAndOffers();
  }

  // Data
  Future<void> loadUserAndOffers() async {
    try {
      var profile = await AuthService().getPersistedUser();

      var searchRequest = OfferSearchRequest(
        userId: profile.id,
        query: query,
        categoryId: categoryId,
      );

      var offersData = await OfferService().userOffers(searchRequest);

      setState(() {
        userOffers = offersData;
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

    await loadUserAndOffers();
  }

  void handleCategoryChange(int selectedCategory) async {
    setState(() {
      categoryId = selectedCategory;
    });

    await loadUserAndOffers();
  }

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return FutureBuilder(
      future: userOffersFuture,
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
                const UserOffersIntro(),
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
                userOffers.isNotEmpty
                    ? UserOffersList(offers: userOffers)
                    : const NoData()
              ],
            ),
          );
        }
      },
    );
  }
}
