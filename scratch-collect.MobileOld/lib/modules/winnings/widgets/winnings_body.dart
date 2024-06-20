import 'package:flutter/widgets.dart';
import 'package:IB210370/modules/auth/services/auth.service.dart';
import 'package:IB210370/modules/home/models/offer_search_request.model.dart';
import 'package:IB210370/modules/home/services/offer.service.dart';
import 'package:IB210370/modules/home/widgets/search.dart';
import 'package:IB210370/modules/items/models/user_offer.model.dart';
import 'package:IB210370/modules/profile/models/profile.model.dart';
import 'package:IB210370/modules/shared/theme/size_config.dart';
import 'package:IB210370/modules/shared/theme/utils.dart';
import 'package:IB210370/modules/shared/widgets/error_data.dart';
import 'package:IB210370/modules/shared/widgets/no_data.dart';
import 'package:IB210370/modules/shared/widgets/snackbar.dart';
import 'package:IB210370/modules/winnings/widgets/winnings_body_loading.dart';
import 'package:IB210370/modules/winnings/widgets/winnings_intro.dart';
import 'package:IB210370/modules/winnings/widgets/winnings_list.dart';

class WinningsBody extends StatefulWidget {
  const WinningsBody({
    super.key,
  });

  @override
  WinningsBodyState createState() => WinningsBodyState();
}

class WinningsBodyState extends State<WinningsBody> {
  // Search
  String? query;
  // Data
  late Future<dynamic> winningsFuture;
  List<UserOffer> winnings = [];
  late ProfileResponse user;

  @override
  void initState() {
    super.initState();

    winningsFuture = loadUserAndWinnings();
  }

  // Data
  Future<void> loadUserAndWinnings() async {
    try {
      var profile = await AuthService().getPersistedUser();

      var searchRequest = OfferSearchRequest(
        userId: profile.id,
        query: query,
      );

      var response = await OfferService().userWonOffers(searchRequest);

      setState(() {
        winnings = response;
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

    await loadUserAndWinnings();
  }

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return FutureBuilder(
      future: winningsFuture,
      builder: (context, snapshot) {
        if (snapshot.hasError) {
          return const ErrorData();
        } else if (snapshot.connectionState != ConnectionState.done) {
          return const WinningsBodyLoading();
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
                const WinningsIntro(),
                SizedBox(height: getProportionateScreenHeight(60)),
                Search(
                  onSearch: handleSearch,
                ),
                SizedBox(
                  height: getProportionateScreenHeight(45),
                ),
                winnings.isNotEmpty
                    ? WinningsList(winnings: winnings)
                    : const NoData()
              ],
            ),
          );
        }
      },
    );
  }
}
